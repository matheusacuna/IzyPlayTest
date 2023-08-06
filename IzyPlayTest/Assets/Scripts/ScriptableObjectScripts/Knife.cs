using UnityEngine;

[CreateAssetMenu(fileName = "KnifeSO", menuName = "ScriptableObject/Knife", order = 1)]
public class Knife : ScriptableObject
{
    [Header("Values Knife")]    
    public GameObject prefabKnife;
    public Vector3 directionKnife;
    public float jumpForce;
    public float xDirection;
    public float speedXDirection;
    public string knifeName;
    //public Sprite iconKnife;
    

}
