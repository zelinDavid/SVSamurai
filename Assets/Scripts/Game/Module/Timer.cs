
using System;

namespace Module.Timer
{


   /// <summary>
    /// 计时器接口
    /// </summary>
    public interface ITimer
    {
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

    public interface ITimerManager
    {
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

    public class Timer : ITimer
    {
        public string ID {get; private set;}

        private float _runTime;

        public float CurrentTime => _runTime;  

        public float Percent => throw new NotImplementedException();

        public float Duration => throw new NotImplementedException();

        public bool IsLoop => throw new NotImplementedException();

        public bool IsTiming => throw new NotImplementedException();

        public bool IsComplete => throw new NotImplementedException();

        public ITimer AddCompleteListener(Action complete)
        {
            throw new NotImplementedException();
        }

        public ITimer AddUpdateListener(Action update)
        {
            throw new NotImplementedException();
        }

        public void Continue()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void ResetData(string id, float duration, bool loop)
        {
            throw new NotImplementedException();
        }

        public void Stop(bool isComplete)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }









}