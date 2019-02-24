using UnityEngine;

namespace DefaultNamespace
{
    public class GamePadControllsMe : MonoBehaviour
    {
        public CButton controller;
        public Color activeColor = Color.red;
        private Color inactiveColor;

        public void Awake()
        {
            inactiveColor = GetComponent<SpriteRenderer>().color;
        }

        public void Activate(bool activate)
        {
            GetComponent<SpriteRenderer>().color = activate ? activeColor : inactiveColor;
        }

        public void Move(float lx, float ly)
        {
            Vector3 transformPosition = transform.position;
            transformPosition.x += lx / 40f;
            transformPosition.y += -ly / 40f;
            transform.position = transformPosition;
        }
    }
}