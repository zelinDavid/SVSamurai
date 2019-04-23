using System;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace UIFrame {
    public class UIAudioManager : MonoBehaviour {
        private AudioSource _source;
        private Func<string, AudioClip[]> _loadAudioFunc;
        private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip> ();

        public void Init (string audioPath, Func<string, AudioClip[]> loadFunc) {
            _source = transform.getOrAddComponent<AudioSource>();
            AddLoadListener (loadFunc);
            LoadAllAudioClip (audioPath);
        }

        private void AddLoadListener (Func<string, AudioClip[]> loadFunc) {
            if (loadFunc == null) {
                Debug.LogError ("loadFunc can't be null");
                return;
            }
            _loadAudioFunc = loadFunc;

        }

        private void LoadAllAudioClip (string audioPath) {
            var audioClips = _loadAudioFunc.Invoke (audioPath);
            foreach (AudioClip clip in audioClips) {
                if (!_audioClips.ContainsKey (clip.name)) {
                    _audioClips.Add (clip.name, clip);
                }
            }
        }

        public void Play (string name) {
            AudioClip clip = GetClip(name);
            if (clip != null)
            {
                _source.PlayOneShot(clip,0.5f);
            }

        }

        private AudioClip GetClip (string name) {
            if (_audioClips.TryGetValue(name,out AudioClip clip))
            {
                return clip; 
            }
            Debug.LogError("audioManager don't contain the clip:"+ name);
            return null;
        }

        public void PlayBg (string name) {
             AudioClip clip = GetClip(name);
            if (clip != null)
            {   _source.clip = clip;
                _source.loop = true;
                _source.volume = 0.6f;
                _source.Play();
            }
        }
    }
}