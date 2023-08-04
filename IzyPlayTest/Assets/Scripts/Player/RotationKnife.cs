using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationKnife : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] private MyInputsManager myInputsManager;

    public float impulseForce;
    public float rotationSpeed;
    private bool canImpulse = false;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myInputsManager.myInputs.Knife.Rotation.triggered)
        {
            canImpulse = true;
        }
    }

    public void FixedUpdate()
    {
        if(canImpulse)
        {
            KickAndFlip();
        }
    }
    private void KickAndFlip()
    {
        Vector3 moveY = new Vector3(1,3,0) * impulseForce;
        rig.AddForce(moveY, ForceMode.Impulse);
        canImpulse = false;

        //transform.Rotate(Vector3.forward, 180f * Time.time);
    }
}
