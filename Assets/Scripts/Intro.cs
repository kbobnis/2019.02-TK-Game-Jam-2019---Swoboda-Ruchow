using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Intro : MonoBehaviour
    {
        public PlayableDirector director;

        void OnEnable()
        {
            director.stopped += OnPlayableDirectorStopped;
        }

        void OnPlayableDirectorStopped(PlayableDirector aDirector)
        {
            if (director == aDirector)
            {
                Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
                SceneManager.LoadScene("Level1");
            }
        }

        void OnDisable()
        {
            director.stopped -= OnPlayableDirectorStopped;
        }
    }
}