using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GamePadController : MonoBehaviour
    {
        private List<GamePadControllsMe> playerControllers = new List<GamePadControllsMe>();
        int currentIndex = -1;

        void Awake()
        {
            RegisterAll();
            SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
        }

        private void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            RegisterAll();
        }

        private void RegisterAll()
        {
            Debug.Log("Registering all");
            playerControllers.Clear();
            GamePadControllsMe[] foundObjects = FindObjectsOfType<GamePadControllsMe>();
            foreach (GamePadControllsMe controllsMe in foundObjects)
            {
                playerControllers.Add(controllsMe);
            }
            playerControllers[0].Activate(true);
            currentIndex = 0;
        }

        void Update()
        {
            if (currentIndex != -1)
            {
                float LY = GamePad.GetAxis(CAxis.LY);
                float LX = GamePad.GetAxis(CAxis.LX);

                bool isAPressed = GamePad.GetState().Pressed(CButton.A);
                if (isAPressed)
                {
                    ChangeController();
                }

                playerControllers[currentIndex].Move(LX, LY);
            }
        }

        private void ChangeController()
        {
            playerControllers[currentIndex].Activate(false);
            currentIndex++;
            if (currentIndex >= playerControllers.Count)
            {
                currentIndex = 0;
            }

            playerControllers[currentIndex].Activate(true);

            Debug.Log("Changed controller to " + currentIndex);
        }
    }
}