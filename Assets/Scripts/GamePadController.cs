using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GamePadController : MonoBehaviour
    {
        private List<GamePadControllsMe> playerControllers = new List<GamePadControllsMe>();
        int currentIndex = -1;
        private GamePadControllsMe current;

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

            if (foundObjects.Length > 0)
            {
                playerControllers[0].Activate(true);
                current = playerControllers[0];
            }
        }

        void Update()
        {
            if (current != null)
            {
                float LY = GamePad.GetAxis(CAxis.LY);
                float LX = GamePad.GetAxis(CAxis.LX);

                var s = GamePad.GetState();

                if (s.AnyButton)
                {
                    var f = playerControllers.Find(c => c.controller == s.GetAnyButton());
                    ChangeController(f);
                }

//                bool isAPressed = GamePad.GetState().Pressed(CButton.A);
//                if (isAPressed)
//                {
//                    ChangeController();
//                }

                current.Move(LX, LY);
            }
        }

        private void ChangeController(GamePadControllsMe f)
        {
            current.Activate(false);
            f.Activate(true);
            current = f;
        }
    }
}