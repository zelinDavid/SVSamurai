using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Module.Timer {

    /// <summary>
    /// 计时器接口
    /// </summary>
    public interface ITimer {
        /// <summary>
        /// 计时器唯一标识
        /// </summary>
        string ID { get; }

        /// <summary>
        /// 当前的时间
        /// </summary>
        float CurrentTime { get; }
        /// <summary>
        /// 运行百分比
        /// </summary>
        float Percent { get; }
        /// <summary>
        /// 单次循环持续时间
        /// </summary>
        float Duration { get; }
        /// <summary>
        /// 是否循环执行
        /// </summary>
        bool IsLoop { get; }
        /// <summary>
        /// 是否正在计时
        /// </summary>
        bool IsTiming { get; }
        /// <summary>
        /// 是否完成
        /// </summary>
        bool IsComplete { get; }
        /// <summary>
        /// 重置数据
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        void ResetData(string id, float duration, bool loop);
        /// <summary>
        /// 帧函数
        /// </summary>
        void Update();
        /// <summary>
        /// 继续计时
        /// </summary>
        void Continue();
        /// <summary>
        /// 暂停计时
        /// </summary>
        void Pause();
        /// <summary>
        /// 停止计时
        /// </summary>
        void Stop(bool isComplete);

        ITimer AddUpdateListener(Action update);
        ITimer AddCompleteListener(Action complete);
    }

    public interface ITimerManager {
        /// <summary>
        /// 创建计时器，如当前指定名称计时器正在计时，返回null
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(string id, float duration, bool loop);

        /// <summary>
        /// 重置指定ID的Timer数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer ResetTimerData(string id, float duration, bool loop);
        /// <summary>
        /// 指定ID的timer为空，创建timer，不为空，重新启动timer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreatOrRestartTimer(string id, float duration, bool loop);
        /// <summary>
        /// 通过标识获取计时器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ITimer GeTimer(string id);

        void StopTimer(ITimer timer, bool isComplete);

        /// <summary>
        /// 帧函数
        /// </summary>
        void Update();
        /// <summary>
        /// 继续执行所有计时器
        /// </summary>
        void ContinueAll();

        /// <summary>
        /// 暂停所有计时器
        /// </summary>
        void PauseAll();
        /// <summary>
        /// 关闭所有计时器
        /// </summary>
        void StopAll();
    }

    /// <summary>
    /// 计时器管理类
    /// </summary>

    public class Timer : ITimer {

        private float _duration;

        private Action _onUpate;
        private Action _onComplete;
        private DateTime _startTime;
        //总运行时间
        private float _runTimeTotal;
        //刷新间隔帧数
        private int _offsetFrame = 5;
        private int _frameTimes;

        public string ID { get; private set; }

        public float CurrentTime => _runTimeTotal;

        public float Percent => _runTimeTotal / _duration;

        public float Duration => _duration;

        public bool IsLoop { get; private set; }

        public bool IsTiming { get; private set; }

        public bool IsComplete { get; private set; }

        public Timer(string id, float duration, bool loop) {
            InitData(id, duration, loop);
        }

        public ITimer AddCompleteListener(Action complete) {
            _onComplete += complete;
            return this;
        }

        public ITimer AddUpdateListener(Action update) {
            _onUpate += update;
            return this;
        }

        public void Continue() {
            IsTiming = true;
            _startTime = DateTime.Now;

        }

        public void Pause() {
            IsTiming = false;
            _runTimeTotal += GetCurrentTimingTime();
        }

        public void ResetData(string id, float duration, bool loop) {
            InitData(id, duration, loop);
        }

        private void InitData(string id, float duration, bool loop) {
            ID = id;
            _duration = duration;
            IsLoop = loop;
            ResetData();
        }

        private void ResetData() {
            IsComplete = false;
            IsTiming = true;
            _startTime = DateTime.Now;
            _runTimeTotal = 0;
            _onUpate = null;
            _onComplete = null;
        }

        public void Stop(bool isComplete) {
       
             if (_onComplete != null && isComplete)
                {
                    _onComplete?.Invoke();
                }
                _onComplete = null;
                _runTimeTotal = 0;
                IsTiming = false;
        }

        public void Update() {

            if (!IsTiming || IsComplete) {
                return;
            }

            _frameTimes++;
            if (_frameTimes < _offsetFrame) {
                return;
            }
            _frameTimes = 0;

            IsComplete = JudgeIsComplete();

            if (IsLoop) {
                Loop();
            } else {
                NotLoop();
            }

            _onUpate?.Invoke();

        }

        private void Loop() {
            if (IsComplete) {
                IsComplete = false;
                _onComplete?.Invoke();
                ResetData();
            }
        }

        private void NotLoop() {
            if (IsComplete) {
                _onComplete?.Invoke();
                _onComplete = null;
            }
        }

        private bool JudgeIsComplete() {

            return (CurrentTime + GetCurrentTimingTime()) >= Duration;
        }

        private float GetCurrentTimingTime() {
            var time = DateTime.Now - _startTime;
            return (float) time.TotalSeconds;
        }
    }

    /// <summary>
    /// 计时器管理类
    /// </summary>
    public class TimerManager : ITimerManager {
        private HashSet<ITimer> _activeTimers;
        private HashSet<ITimer> _inactiveTimers;
        private HashSet<ITimer>.Enumerator _activeEnum;
        private Dictionary<string, ITimer> _timersDic;

        public TimerManager() {
            _activeTimers = new HashSet<ITimer>();
            _inactiveTimers = new HashSet<ITimer>();
            _timersDic = new Dictionary<string, ITimer>();
        }

        public ITimer CreateTimer(string id, float duration, bool loop) {
            ITimer timer = null;
            if (_timersDic.ContainsKey(id)) {
                 timer = _timersDic[id];
                if (!timer.IsTiming)
                {
                    ResetTimer(timer,id, duration, loop);
                }
                else
                {
                    return null;
                }
            } else {
                if (_inactiveTimers.Count > 0)
                {
                    timer = _inactiveTimers.First();
                    _timersDic.Remove(timer.ID);
                    _inactiveTimers.Remove(timer);
                    ResetTimer(timer, id,duration, loop);
                }else {
                    timer = new Timer(id, duration, loop);
                }
                _timersDic.Add(timer.ID, timer);
                _activeTimers.Add(timer);
            }

            timer.AddCompleteListener(() => TimerCompleter(timer));
            return timer;
        }

        private void TimerCompleter(ITimer timer) {
            if (!timer.IsLoop) {
                SetInactiveTimer(timer);
            }
        }

        private void SetInactiveTimer(ITimer timer) {
            if (_activeTimers.Contains(timer)) {
                _activeTimers.Remove(timer);
                _inactiveTimers.Add(timer);
            }
        }

        private void ResetTimer(ITimer timer, string id, float duration, bool loop) {
            if (_inactiveTimers.Contains(timer)) {
                _inactiveTimers.Remove(timer);
                _activeTimers.Add(timer);
            }

            timer.ResetData(id, duration, loop);
        }

        public void ContinueAll() {
            foreach (ITimer timer in _activeTimers) {
                timer.Continue();
            }
        }

        public ITimer CreatOrRestartTimer(string id, float duration, bool loop) {
            var timer = CreateTimer(id, duration, loop);
            if (timer == null) {
                timer = ResetTimerData(id, duration, loop);
            }
            return timer;
        }

        public ITimer GeTimer(string id) {
            if (_timersDic.ContainsKey(id)) {
                return _timersDic[id];
            }
            // Debug.LogError("fail getTimer:" + id);
            return null;
        }

        public void PauseAll() {
            foreach (ITimer timer in _activeTimers) {
                timer.Pause();
            }
        }

        public ITimer ResetTimerData(string id, float duration, bool loop) {
            if (_timersDic.ContainsKey(id)) {
                var timer = _timersDic[id];
                if (timer.IsTiming) {
                    ResetTimer(timer, id, duration, loop);
                }

                return timer;
            }

            return null;
        }

        public void StopAll() {
            foreach (ITimer timer in _activeTimers) {
                StopTimer(timer, false);
            }
        }

        public void StopTimer(ITimer timer, bool isComplete) {
            timer.Stop(isComplete);
            SetInactiveTimer(timer);
        }

        public void Update() {
            _activeEnum = _activeTimers.GetEnumerator();
            int count = _activeTimers.Count;
            try {
                for (int i = 0; i < count; i++) {
                    if (!_activeEnum.MoveNext()) {
                        continue;
                    } else {
                        _activeEnum.Current.Update();
                    }
                }
            } catch (System.Exception) {

            }
        }

    }

}