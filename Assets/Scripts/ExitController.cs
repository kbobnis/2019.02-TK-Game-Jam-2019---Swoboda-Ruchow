using UnityEngine;

public delegate void ExitEvent();

public class ExitController : MonoBehaviour
{
    private const string PlayerTag = "Player";

    [SerializeField] private int partsNeededToWin = 8;

    private int partsIn = 0;

    public event ExitEvent OnPlayerExit;

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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(PlayerTag)) partsIn--;
    }

    private void SendExitEvent()
    {
        Debug.Log("Player exited");
        OnPlayerExit?.Invoke();
    }
}