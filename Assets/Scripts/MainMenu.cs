using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class MainMenu : MonoBehaviour
    {
        public void OnClickPlay()
        {
            SceneManager.LoadScene("Intro");
        }
    }
}