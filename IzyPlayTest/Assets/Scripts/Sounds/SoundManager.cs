using UnityEngine;
using UnityEngine.Audio;

public enum SoundsType
{
    Music,
    SoundEffect,
}

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] Sound[] soundsDatabase;
        public AudioMixerGroup[] audioMixer;
        private AudioSource audioSourceSFX, audioSourceMusic;

        public static SoundManager instance;
        private void Start()
        {
            audioSourceSFX = GetComponent<AudioSource>();
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

            }
            else
            {
                Destroy(gameObject);
            }
        }
        //Função estatica responsável por tocar sons, seja do tipo Music ou SoundEffect
        public static void PlaySoundEffect(SoundsType soundsType, string name, float pitch = 1f, float volume = 0.5f)
        {
            if (instance == null)
                return;

            switch (soundsType)
            {
                case SoundsType.SoundEffect:
                    instance.audioSourceSFX.outputAudioMixerGroup = instance.audioMixer[0];
                    break;
                case SoundsType.Music:
                    instance.audioSourceMusic.outputAudioMixerGroup = instance.audioMixer[1];
                    break;
            }

            for (int i = 0; i < instance.soundsDatabase.Length; i++)
            {
                if (instance.soundsDatabase[i].soundsType == soundsType && instance.soundsDatabase[i].nameSound == name)
                {
                    instance.audioSourceSFX.pitch = pitch;
                    instance.audioSourceSFX.volume = volume;
                    instance.audioSourceSFX.clip = instance.soundsDatabase[i].audioClip;
                    instance.audioSourceSFX.PlayOneShot(instance.soundsDatabase[i].audioClip);
                }
            }
        }
    }
}


