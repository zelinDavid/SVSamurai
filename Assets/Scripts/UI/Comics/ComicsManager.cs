using System;
using System.Collections.Generic;
using System.Linq;
using Const;
using Manager;
using UnityEngine;
using Util;

namespace UIFrame {
    public class ComicsManager : MonoBehaviour {
        private Dictionary<ComicsParentId, Transform> _parentDic = new Dictionary<ComicsParentId, Transform>();
        private Stack<ComicsItem> _leftStack = new Stack<ComicsItem>();
        private Stack<ComicsItem> _rightStack = new Stack<ComicsItem>();
        private ComicsPage _comicsPage;
        public void Start() {
            InitParent();
            InitButtons();
            SpawnItem();
            InitPage();
            InitBgAudio();

        }

        private void InitBgAudio() {
            UIAudioManager audioManager = gameObject.AddComponent<UIAudioManager>();
            audioManager.Init(Path.BG_AUDIO_PATH, LoadManager.Single.LoadAll<AudioClip>);
            audioManager.PlayBg(BgAudioName.Level_Bg.ToString());
        }

        private void InitPage() {
            _comicsPage = transform.GetByName("Page").gameObject.AddComponent<ComicsPage>();

        }

        private void SpawnItem() {
            var sprites = GetSprites();
            SpawnCurrentItem(sprites);
            SpawnRightItem(sprites);
        }

        private void SpawnCurrentItem(List<Sprite> sprites) {
            if (_parentDic[ComicsParentId.CurrentComics].childCount == 0) {
                InitItem(_parentDic[ComicsParentId.CurrentComics], sprites[0], 0);
            }
        }

        private void SpawnRightItem(List<Sprite> sprites) {
            for (int i = sprites.Count - 1; i > 0; i--) {
                var item = InitItem(_parentDic[ComicsParentId.RightComics], sprites[i], i);
                _rightStack.Push(item);
            }
        }

        private ComicsItem InitItem(Transform parent, Sprite sprite, int index) {
            GameObject temp = LoadManager.Single.LoadAndInstaniate(Path.COMICS_ITEM_PREFAB_PATH, parent);
            ComicsItem item = temp.AddComponent<ComicsItem>();
            item.Init(sprite, index);
            return item;
        }

        private List<Sprite> GetSprites() {
            var path = Path.COMICS_PATH + ((int)DataManager.Single.LevelIndex).ToString("00");
            var sprits = LoadManager.Single.LoadAll<Sprite>(path).ToList();
            Debug.Log("getSprites" + sprits.Count);
            return sprits;
        }

        private void InitParent() {
            Transform parent = transform.GetByName("Parent");
            if (parent == null) {
                return;
            }

            Transform tem;
            foreach (ComicsParentId id in Enum.GetValues(typeof(ComicsParentId))) {
                var list = from Transform child in parent where child.name.Contains(id.ToString()) select child;
                tem = list.FirstOrDefault();
                if (tem == null) {
                    Debug.LogError("can not find child name:" + id);
                    return;
                }
                _parentDic[id] = tem;
            }

        }

        private void InitButtons() {
      
            transform.AddBtnListener("Back", Back);
            transform.AddBtnListener("Left", RightBtn);
            transform.AddBtnListener("Right", LeftBtn);
            transform.AddBtnListener("Done", () => {
                StartCoroutine(LoadSceneManager.Single.LoadSceneAsync(DataManager.Single.GetSceneName()));
                LoadSceneManager.Single.AllowSwitchScene();
            });
        }

        private void LeftBtn() {
            if(_rightStack.Count == 0)
                return;

            var item = Move(ComicsParentId.LeftComics);
            _comicsPage.ShowNum(item.Page);
        }

        private void RightBtn() {
            if (_leftStack.Count == 0)
            {
                return;
            }

            var item = Move(ComicsParentId.RightComics);
            _comicsPage.ShowNum(item.Page);

        }

        private void Back() {
            ComicsItem tem;

            int Count = _leftStack.Count;
            for (int i = 0; i < Count; i++) {
                tem = _leftStack.Pop();
                ResetToRight(tem);
            }

            tem = _rightStack.Pop();
            tem.SetParnetAndPosition(_parentDic[ComicsParentId.CurrentComics]);
            _comicsPage.ShowNum(tem.Page);

        }

        private void ResetToRight(ComicsItem item) {
            item.SetParnetAndPosition(_parentDic[ComicsParentId.RightComics]);
            _rightStack.Push(item);
        }

        private ComicsItem Move(ComicsParentId id) {
            ComicsItem current = GetCurrntItem();
            ComicsItem side = null;

            switch (id) {
                case ComicsParentId.LeftComics:
                    _leftStack.Push(current);
                    side = _rightStack.Pop();

                    break;
                case ComicsParentId.RightComics:
                    _rightStack.Push(current);
                    side = _leftStack.Pop();
                    break;
            }
            current.Move(_parentDic[id]);
            side.Move(_parentDic[ComicsParentId.CurrentComics]);
            return side;
        }

        private ComicsItem GetCurrntItem() {
            return _parentDic[ComicsParentId.CurrentComics].GetChild(0).GetComponent<ComicsItem>();
        }
    }
}