using UnityEngine;

namespace DefaultNamespace
{
    public class GamePadControllsMe : MonoBehaviour
    {
        public void Activate(bool activate)
        {
            GetComponent<SpriteRenderer>().color = activate ? Color.red : Color.white;
        }

        public void Move(float lx, float ly)
        {
            Vector3 transformPosition = transform.position;
            transformPosition.x += lx / 10f;
            transformPosition.y += -ly / 10f;
            transform.position = transformPosition;
        }
    }
}