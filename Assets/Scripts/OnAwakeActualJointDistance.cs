using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(DistanceJoint2D))]
    public class OnAwakeActualJointDistance : MonoBehaviour
    {
        private void Awake()
        {
            DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
            joint.distance = Vector2.Distance(transform.position, joint.connectedBody.transform.position);

        }
    }
}