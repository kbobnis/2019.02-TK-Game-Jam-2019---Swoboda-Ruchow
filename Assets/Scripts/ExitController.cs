using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void ExitEvent();

public class ExitController : MonoBehaviour
{
    private const string PlayerTag = "Player";

    [SerializeField] private int partsNeededToWin = 8;

    private int partsIn = 0;
    private bool finishedInThisScene = false;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        finishedInThisScene = false;
        partsIn = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(PlayerTag))
        {
            return;
        }

        partsIn++;
        if (partsIn >= partsNeededToWin)
        {
            SendExitEvent();
            Destroy(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(PlayerTag))
        {
            partsIn--;
        }
    }

    private void SendExitEvent()
    {
        if (!finishedInThisScene)
        {
            Debug.Log("Player exited");
            Game.Me.LevelFinished();
            this.finishedInThisScene = true;
        }
    }
}