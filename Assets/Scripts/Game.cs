using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        public static Game Me;

        [SerializeField] private Scene[] levels;
        public ExitController exitController;

        void Awake()
        {
            Me = this;
            DontDestroyOnLoad(this.gameObject);
            
        }
        
        
    }
}