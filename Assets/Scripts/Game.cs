using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        public static Game Me;

        private int actualLevel;
        [SerializeField] private string[] levelNames;

        void Awake()
        {
            Me = this;
            DontDestroyOnLoad(this.gameObject);
        }


        public void LevelFinished()
        {
            GetComponentInChildren<EndLevelOutro>().EndLevel(levelNames[++actualLevel]);
        }
    }
}