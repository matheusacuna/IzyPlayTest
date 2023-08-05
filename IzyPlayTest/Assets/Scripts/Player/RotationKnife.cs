using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


namespace Player
{
    public class RotationKnife : MonoBehaviour
    {
        [Header("Scripts Reference")]
        [SerializeField] private MyInputsManager myInputsManager;
        [SerializeField] private BindKnife bindKnife;

        [Header("Values Knife")]    
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

            rig.isKinematic = true;     
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
                KickAndFlip();
            }      
        }
        private void KickAndFlip()
        {
            rig.velocity = Vector3.up * jumpForce;

            canImpulse = false;
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
                SceneManager.LoadScene("Gameplay");
            }
        }
    }
}

