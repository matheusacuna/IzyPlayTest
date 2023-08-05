using UnityEngine;

namespace Managers 
{
    public class MyInputsManager : MonoBehaviour
    {
        public MyInputs myInputs;

        private void Awake()
        {
            myInputs = new MyInputs();
        }

        private void OnEnable()
        {
            myInputs.Enable();
        }

        private void OnDisable()
        {
            myInputs.Disable();
        }
    }
}
