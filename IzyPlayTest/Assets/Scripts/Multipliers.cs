using Managers;
using UnityEngine;

public class Multipliers : MonoBehaviour
{
    public int valueMultiplier;
    private void OnTriggerEnter(Collider other)
    {
        //Caso um objeto com a tag Player encoste nos objetos multiplicadores ele chama
        //a Action responsável por calcular o ScoreFinal.
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.ACT_ScoreFinal(valueMultiplier);
        }
    }
}
