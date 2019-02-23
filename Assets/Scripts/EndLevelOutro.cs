using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlayableDirector))]
    public class EndLevelOutro : MonoBehaviour
    {

        private string nextSceneName;
        
        private PlayableDirector director
        {
            get { return GetComponentInChildren<PlayableDirector>(); }
        }
        
        void Start()
        {
            GetComponentInChildren<Canvas>(true).gameObject.SetActive(false);
        }
        
        public void EndLevel(string nextSceneName)
        {
            this.nextSceneName = nextSceneName;
            GetComponentInChildren<Canvas>(true).gameObject.SetActive(true);
            GetComponentInChildren<PlayableDirector>().Play();
        }
        
        public void EndGame()
        {
            EndLevel(null);
        }
        
        void OnEnable()
        {
            director.stopped += OnPlayableDirectorStopped;
        }

        void OnPlayableDirectorStopped(PlayableDirector aDirector)
        {
            if (director == aDirector)
            {
                Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped. next scene is " + this.nextSceneName);
                GetComponentInChildren<Canvas>(true).gameObject.SetActive(false);

                if (string.IsNullOrWhiteSpace(this.nextSceneName))
                {
                    SceneManager.LoadScene("MainMenu");
                } else
                {
                    SceneManager.LoadScene(this.nextSceneName);
                }
            }
        }

        void OnDisable()
        {
            director.stopped -= OnPlayableDirectorStopped;
        }
    }
}