using UnityEngine;
using Managers;

namespace Player
{
    public class Blade : MonoBehaviour
    {
        //Caso a faca esteja encostando em um objeto com a tag ObjectsToSlicer ele chama a função responsável
        //por dividi-los ao meio.
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
