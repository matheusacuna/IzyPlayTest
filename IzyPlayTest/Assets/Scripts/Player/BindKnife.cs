using UnityEngine;

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
    }
}
