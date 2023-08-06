using UnityEngine;
using DG.Tweening;
using Managers;
using Cinemachine;

namespace Player
{
    public class RotationKnife : MonoBehaviour
    {
        [Header("Virtual Camera")]
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        [Header("Scripts Reference")]
        public MyInputsManager myInputsManager;
        public BindKnife bindKnife;

        [Header("Values Knife")]
        public Knife knife;
        public Vector3 directionKnife;
        public float jumpForce;
        public float xDirection;
        public float speedXDirection;
    
        private bool canImpulse = false;
        private Rigidbody rig;
        private bool isRotating;
        private float initialRotationZ;

        void Start()
        {
            rig = GetComponent<Rigidbody>();
            virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            rig.isKinematic = true;

            SetupKnife();
        }

        void Update()
        {
            if (myInputsManager.myInputs.Knife.Rotation.triggered && !isRotating)
            {
                initialRotationZ = transform.localEulerAngles.z;
                canImpulse = true;
                isRotating = true;
                rig.isKinematic = false;  
                RotateKnife();
            }       
        }

        public void FixedUpdate()
        {
            rig.velocity = new Vector3(speedXDirection * xDirection, rig.velocity.y, 0f);

            if (canImpulse)
            {
                Kick();
            }      
        }

        private void SetupKnife()
        {
            directionKnife = knife.directionKnife;
            jumpForce = knife.jumpForce;
            xDirection = knife.xDirection;
            speedXDirection = knife.speedXDirection;
            virtualCamera.Follow = transform;
        }
        private void Kick()
        {
            rig.velocity = Vector3.up * jumpForce;

            canImpulse = false;
            SoundManager.PlaySoundEffect(SoundsType.SoundEffect, "KnifeWhoosh");
        }


        public Quaternion GetTransformRotation()
        {
            return transform.rotation;
        }

        private void RotateKnife()
        {
            float targetRotationZ = initialRotationZ - 360f;
            
            transform.DOLocalRotate(new Vector3(0f, 0f, targetRotationZ), .7f, RotateMode.FastBeyond360)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => {
                transform.localEulerAngles = new Vector3(0f, 0f, targetRotationZ);
                isRotating = false;
            });
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Ground"))
            {
                GameManager.ACT_LoserGame();
            }
        }
    }
}

