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
            if (Me != null)
            {
                Destroy(this.gameObject);
            } else
            {
                Me = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        public void LevelFinished()
        {
            EndLevelOutro outro = GetComponentInChildren<EndLevelOutro>();
            int nextLevelIndex = ++actualLevel;
            if (nextLevelIndex >= levelNames.Length)
            {
                outro.EndGame();
            } else
            {
                outro.EndLevel(levelNames[actualLevel]);
            }
        }
    }
}