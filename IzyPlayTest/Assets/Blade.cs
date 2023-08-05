using UnityEngine;
using Managers;

public class Blade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ObjectsToSlicer"))
        {
            other.GetComponent<CutObjects>().ApplyDestroyEffect();
            ScoreManager.ACT_IncrementScore(10);
        }
    }
}
