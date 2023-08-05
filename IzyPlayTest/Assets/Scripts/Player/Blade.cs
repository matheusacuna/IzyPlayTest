using UnityEngine;
using Managers;

public class Blade : MonoBehaviour
{
    private Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ObjectsToSlicer"))
        {
            other.GetComponent<CutObjects>().ApplyDestroyEffect();

            if(!other.GetComponent<CutObjects>().isDivided)
            { 
                ScoreManager.ACT_IncrementScore(10);
                other.GetComponent<CutObjects>().isDivided = true;
            }      
        }
    }
}
