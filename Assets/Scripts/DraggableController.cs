using UnityEngine;

namespace DefaultNamespace
{
    public class DraggableController : MonoBehaviour
    {
        private Vector3 screenPoint;
        private Vector3 offset;

        private Transform transform;

        private Camera mainCamera;

        private void Start()
        {
            this.transform = GetComponent<Transform>();
            this.mainCamera = Camera.main;
        }

        private void OnMouseDown()
        {
            screenPoint = mainCamera.WorldToScreenPoint(transform.position);
            offset = transform.position -
                     mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                         screenPoint.z));
        }

        private void OnMouseDrag()
        {
            var cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            var cursorPosition = mainCamera.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }
    }
}