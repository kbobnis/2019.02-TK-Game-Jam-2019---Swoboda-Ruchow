using UnityEngine;

namespace DefaultNamespace
{
    //[RequireComponent(typeof(DistanceJoint2D))]
    public class OnAwakeActualJointDistance : MonoBehaviour
    {
        private void Awake()
        {
            DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
            if (joint != null)
            {
                joint.distance = Vector2.Distance(transform.position, joint.connectedBody.transform.position);
            }
            
            if (joint == null)
            {
                SpringJoint2D sjoint = GetComponent<SpringJoint2D>();
                sjoint.distance = Vector2.Distance(transform.position, sjoint.connectedBody.transform.position);
            }
        }
    }
}