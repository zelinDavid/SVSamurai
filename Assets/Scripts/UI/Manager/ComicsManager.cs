using System;
using System.Linq;
using System.Collections.Generic;

using Const;

using Manager;

using UnityEngine;

using Util;

namespace UIFrame {
    public class ComicsManager : MonoBehaviour {
        private Dictionary<ComicsParentId, Transform> _parentDic = new Dictionary<ComicsParentId, Transform>();
        private Stack<ComicsItem> _leftStack = new Stack<ComicsItem>();
        private Stack<ComicsItem> _rightStack = new Stack<ComicsItem>();
        private ComicsItem _item;
        public void Start() {
            InitBgAudio();

        }

        private void InitBgAudio() {
            UIAudioManager audioManager = gameObject.AddComponent<UIAudioManager>();
            audioManager.Init(Path.BG_AUDIO_PATH, LoadManager.Single.LoadAll<AudioClip>);
            audioManager.PlayBg(BgAudioName.Level_Bg.ToString());
        }

        private void InitPage() {
            _item = transform.GetByName("Page").gameObject.AddComponent<ComicsItem>();
        }

        private void SpawnItem() {
            var sprites = GetSprites();
            SpawnCurrentItem(sprites);

        }

        private void SpawnCurrentItem(List<Sprite> sprites) {

        }

        private void SpawnRightItem(List<Sprite> sprites) {

        }

        private ComicsItem InitItem(Transform parnet, Sprite sprite, int index) {

        }

        private List<Sprite> GetSprites() {
            var path = Path.COMICS_PATH + DataManager.Single.LevelIndex.ToString("00");
            return LoadManager.Single.LoadAll<Sprite>(path).ToList();
        }

        private void InitParent() {
            Transform parent = transform.GetByName("Parent");
            if (parent == null)
            {
                return;
            }

            Transform tem;
            foreach (ComicsParentId id in Enum.GetValues(typeof(ComicsParentId)))
            {
                var list = from Transform child in parent where child.name.Contains(id.ToString()) select child;
                tem = list.FirstOrDefault();
                if(tem == null){
                    Debug.LogError("can not find child name:" + id);
                    return;
                }
                _parentDic[id] = tem;
            }
            //TODO:你上次写到这里
        }

        private void InitButtons() {

        }

        private void LeftBtn() { }

        private void RightBtn() { }

        private void Back() {

        }

        private void ResetToRight(ComicsItem item) {

        }

        private ComicsItem Move(ComicsParentId id) {

        }

        private ComicsItem GetCurrntItem() {

        }
    }
}