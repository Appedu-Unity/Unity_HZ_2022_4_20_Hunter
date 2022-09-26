using UnityEngine;

namespace WEI
{
    /// <summary>
    /// ���Ĩt��:���Ѽ����n�����\��
    /// </summary>
    /// �n�D����(����(����1)�A����(����2))
    /// �M�Φ��}���ܹC������ɭԷ|����
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
