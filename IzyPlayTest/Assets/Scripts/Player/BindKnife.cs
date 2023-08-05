using Manager;
using UnityEngine;

namespace Player
{
    public class BindKnife : MonoBehaviour
    {
        private Rigidbody rig;
    
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
            }
        }
    }
}
