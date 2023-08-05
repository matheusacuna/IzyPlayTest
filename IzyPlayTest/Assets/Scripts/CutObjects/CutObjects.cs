using UnityEngine;

public class CutObjects : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rig;
    [SerializeField] private Transform center;
    public bool isDivided;

    private void Start()
    {
        isDivided = false;
    }
    public void ApplyDestroyEffect()
    {
        foreach (Rigidbody rigs in rig)
        {
            rigs.isKinematic = false;
            rigs.AddExplosionForce(100, center.position, 5, 1, ForceMode.Acceleration);
        }
    }
}
