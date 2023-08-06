using UnityEngine;

[CreateAssetMenu(fileName = "SoundSO", menuName = "ScriptableObject/Sound", order = 1)]
public class Sound : ScriptableObject
{
    [Header("Values Sound")]
    public SoundsType soundsType;
    public string nameSound;
    public AudioClip audioClip;

}
