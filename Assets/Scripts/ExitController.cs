using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void ExitEvent();

public class ExitController : MonoBehaviour
{
    public const string PlayerTag = "Player";

    private bool finishedInThisScene = false;
    private Part[] parts;
    private double? counter;
    [SerializeField]
    private double counterLimit = 1.0;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        this.parts = this.transform.GetComponentsInChildren<Part>();
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        finishedInThisScene = false;
    }

    private void Update()
    {
        var allPartsCovered = parts.All(p => p.IsCovered);

        if (!allPartsCovered)
        {
            counter = null;
            return;
        }

        if (counter == null)
        {
            this.counter = counterLimit;
        }
        else
        {
            this.counter -= Time.deltaTime;
            if (counter.Value < 0)
            {
                SendExitEvent();
            }
        }
    }

    private void SendExitEvent()
    {
        if (!finishedInThisScene)
        {
            Game.Me.LevelFinished();
            this.finishedInThisScene = true;
        }
    }
}