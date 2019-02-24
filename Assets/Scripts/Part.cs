using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Part : MonoBehaviour
{
    private int howMany = 0;
    public bool IsCovered => howMany > 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ExitController.PlayerTag))
        {
            howMany++;
            UpdateSprite();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(ExitController.PlayerTag))
        {
            howMany--;
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().color = IsCovered ? Color.green : Color.white;
    }
}