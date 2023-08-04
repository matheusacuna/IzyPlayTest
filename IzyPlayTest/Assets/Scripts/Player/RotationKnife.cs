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
        //    // Calcula o progresso da anima��o de rota��o (0 a 1) com base no tempo passado desde o in�cio da anima��o.
        //    float progress = Mathf.Clamp01(Time.deltaTime / rotationDuration);

        //    // Utiliza a fun��o Quaternion.RotateTowards para rotacionar gradualmente a faca em dire��o � rota��o inicial.
        //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, progress);

        //    // Verifica se a rota��o foi conclu�da (quando a rota��o � quase igual � rota��o inicial).
        //    if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        //    {
        //        // Define a rota��o exata para a rota��o inicial quando a anima��o estiver conclu�da.
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
