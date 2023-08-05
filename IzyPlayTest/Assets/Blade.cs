using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
