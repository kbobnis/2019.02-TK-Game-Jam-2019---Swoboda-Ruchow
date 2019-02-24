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
    private float? counter;
    private float counterLimit = 3.0f;
    private SpriteRenderer[] children;
    

    void Awake()
    {
        children = GetComponentsInChildren<SpriteRenderer>();
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
        bool allPartsCovered = parts.All(p => p.IsCovered);

        Color toSetColor  = Color.white;
        
        if (!allPartsCovered)
        {
            counter = null;
        } else
        {
            if (counter == null)
            {
                this.counter = counterLimit;
            } else
            {
                this.counter -= Time.deltaTime;
                if (counter.Value < 0)
                {
                    SendExitEvent();
                }
            }

            toSetColor = new Color(0 / 255f, counter.Value / (float) counterLimit, 0);
        }
        
        foreach (SpriteRenderer componentsInChild in children)
        {
            //componentsInChild.color = toSetColor;
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