using Managers;
using UnityEngine;

namespace Player
{
    public class BindKnife : MonoBehaviour
    {
        private Rigidbody rig;
        public ParticleSystem confettiVFX;
    
        private void Start()
        {
            rig = GetComponentInParent<Rigidbody>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("MultiplierObject"))
            {
                rig.isKinematic = true;
            
            }

            if(other.gameObject.CompareTag("MultiplierObject"))
            {
                GameManager.ACT_VictoryGame();
                confettiVFX.Play();
            }
        }
    }
}
