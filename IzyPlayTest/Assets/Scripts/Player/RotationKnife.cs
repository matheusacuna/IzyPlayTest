using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


namespace Player
{
    public class RotationKnife : MonoBehaviour
    {
        [Header("Inputs")]
        [SerializeField] private MyInputsManager myInputsManager;

        [Header("Values Knife")]    
        public Vector3 directionKnife;
        public float jumpForce;
        private bool canImpulse = false;
        public Quaternion targetRotation;
        public float rotationSpeed;
    
        private Rigidbody rig;
        private bool canRotate = false;
        [SerializeField]private bool isRotating;

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
                //rig.isKinematic = false;  

                RotateKnife();
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
            rig.AddForce(jumpForce * directionKnife, ForceMode.Impulse);

            canImpulse = false;    
        }

        public Quaternion GetTransformRotation()
        {
            return transform.rotation;
        }


        private void RotateKnife()
        {
            Debug.Log("ta rodando a faca");

            float targetRotationZ = initialRotationZ - 360f;
            // Gira a faca no local com uma rotação de 360 graus em torno do eixo Z.
            transform.DOLocalRotate(new Vector3(0f, 0f, targetRotationZ), .5f, RotateMode.FastBeyond360)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => {
                transform.localEulerAngles = new Vector3(0f, 0f, targetRotationZ);
                isRotating = false;
            });
        }
    }
}

