using UnityEngine;
using Managers;

namespace Player
{
    public class Blade : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("ObjectsToSlicer"))
            {
                other.GetComponent<CutObjects>().ApplyDestroyEffect();

                SoundManager.PlaySoundEffect(SoundsType.SoundEffect, "BrickBreaking", .9f,.2f);

                if(!other.GetComponent<CutObjects>().isDivided)
                { 
                    ScoreManager.ACT_IncrementScore(10);
                    other.GetComponent<CutObjects>().isDivided = true;
                }      
            }
        }
    }
}
