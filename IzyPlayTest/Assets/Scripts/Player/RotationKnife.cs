using UnityEngine;
using UnityEngine.SceneManagement;


namespace Player
{
    public class RotationKnife : MonoBehaviour
    {
        [Header("Inputs")]
        [SerializeField] private MyInputsManager myInputsManager;

        [Header("Values Knife")]
        public float rotationDuration;
        public float torqueValue;    
        public Vector2 jumpForce;
        private bool canImpulse = false;
    
        private Rigidbody rig;
        private bool canRotate = false;
        private Quaternion targetRotation;
    
        void Start()
        {
            rig = GetComponent<Rigidbody>();

            rig.isKinematic = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (myInputsManager.myInputs.Knife.Rotation.triggered)
            {
                canImpulse = true;
                rig.isKinematic = false;
                //canRotate = true;
            }

            //if(canRotate)
            //{   
            //    RotateKnife(); 
            //}
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
            //targetRotation = GetTransformRotation() * Quaternion.Euler(0f, 0f, 180f);

            rig.velocity = jumpForce;
            rig.AddTorque(Vector3.forward * -torqueValue);

            canImpulse = false;
        
        }

        public Quaternion GetTransformRotation()
        {
            return transform.rotation;
        }


        //private void RotateKnife()
        //{
        //    Debug.Log("entrou");
        //    // Calcula o progresso da animação de rotação (0 a 1) com base no tempo passado desde o início da animação.
        //    float progress = Mathf.Clamp01(Time.deltaTime / rotationDuration);

        //    // Utiliza a função Quaternion.RotateTowards para rotacionar gradualmente a faca em direção à rotação inicial.
        //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, progress);

        //    // Verifica se a rotação foi concluída (quando a rotação é quase igual à rotação inicial).
        //    if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        //    {
        //        // Define a rotação exata para a rotação inicial quando a animação estiver concluída.
        //        transform.rotation = targetRotation;
        //        canRotate = false;
        //    }
        //}

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Ground"))
            {
                rig.isKinematic = true;
            }

            SceneManager.LoadScene("Gameplay");
        }

}
}
