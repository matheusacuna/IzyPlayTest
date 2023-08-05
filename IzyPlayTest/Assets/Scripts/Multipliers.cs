using Managers;
using UnityEngine;

public class Multipliers : MonoBehaviour
{
    public int valueMultiplier;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.ACT_ScoreFinal(valueMultiplier);
        }
    }
}
