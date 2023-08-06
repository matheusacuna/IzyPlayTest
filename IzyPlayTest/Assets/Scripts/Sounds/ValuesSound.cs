using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ValuesSound : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] Slider sliderVolumeMusic, sliderVolumeSoundEffect;

    private void Start()
    {
        if (DATASounds.instance == null)
            return;

        audioMixer.SetFloat("volumeMusic", DATASounds.instance.VolumeMusic);
        audioMixer.SetFloat("volumeSoundEffect", DATASounds.instance.VolumeSoundEffect);

        sliderVolumeMusic.value = DATASounds.instance.VolumeMusic;
        sliderVolumeSoundEffect.value = DATASounds.instance.VolumeSoundEffect;
    }

    public void SetVolumeMusic(float volumeMusic)
    {
        audioMixer.SetFloat("volumeMusic", volumeMusic);
        DATASounds.instance.SetVolumeMusic(volumeMusic);
    }

    public void SetVolumeSoundEffect(float volumeSoundEffect)
    {
        audioMixer.SetFloat("volumeSoundEffect", volumeSoundEffect);
        DATASounds.instance.SetVolumeSFX(volumeSoundEffect);
    }
}
