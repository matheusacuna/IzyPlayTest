using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneHandle : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
