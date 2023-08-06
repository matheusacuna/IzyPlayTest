using UnityEngine;

public class DATASounds : MonoBehaviour
{
    public float VolumeSoundEffect { get { return volumeSoundEffect; } }
    public float VolumeMusic { get { return volumeMusic; } }

    float volumeSoundEffect;
    float volumeMusic;

    public static DATASounds instance;

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


        if (PlayerPrefs.HasKey("SaveVolumeMusic"))
            volumeMusic = PlayerPrefs.GetFloat("SaveVolumeMusic");
        else
            PlayerPrefs.SetFloat("SaveVolumeMusic", volumeMusic);


        if (PlayerPrefs.HasKey("SaveVolumeSoundEffect"))
            volumeSoundEffect = PlayerPrefs.GetFloat("SaveVolumeSoundEffect");
        else
            PlayerPrefs.SetFloat("SaveVolumeSoundEffect", volumeSoundEffect);
    }

    public void SetVolumeMusic(float newVolume)
    {
        volumeMusic = newVolume;
        PlayerPrefs.SetFloat("SaveVolumeMusic", volumeMusic);
    }

    public void SetVolumeSFX(float newVolume)
    {
        volumeSoundEffect = newVolume;
        PlayerPrefs.SetFloat("SaveVolumeMusic", volumeSoundEffect);
    }
}

