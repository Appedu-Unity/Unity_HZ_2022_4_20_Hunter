using UnityEngine;

namespace WEI
{
    /// <summary>
    /// 音效系統:提供播放聲音的功能
    /// </summary>
    /// 要求元件(類型(元件1)，類型(元件2))
    /// 套用此腳本至遊戲物件時候會執行
    [RequireComponent(typeof(AudioSource))]
    public class SystemSound : MonoBehaviour
    {

        public static SystemSound instance;

        private AudioSource aud;

        private void Awake()
        {
            instance = this;
            aud = GetComponent<AudioSource>();
        }
        public void PlaySound(AudioClip sound, Vector2 rangeVolume)
        {
            float volume = Random.Range(rangeVolume.x, rangeVolume.y);

            aud.PlayOneShot(sound, volume);
        }
    }
}
