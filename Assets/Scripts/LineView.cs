using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineView : MonoBehaviour
{
    [SerializeField]
    private Transform[]  points;
    private LineRenderer lineRenderer;
    private Transform    transform;

    private void Start()
    {
        this.lineRenderer = GetComponent<LineRenderer>();
        this.transform = GetComponent<Transform>();

        if (this.points.Length != 0) return;

        this.points = this.transform.GetComponentsInChildren<Transform>();

        Debug.Log(string.Concat(points.Select(p => p.name)));

        var joints = this.transform.GetComponentsInChildren<DistanceJoint2D>();
        var rigidBodies = this.transform.GetComponentsInChildren<Rigidbody2D>();
        for (var i = 0; i < rigidBodies.Length - 1; i++)
        {
            joints[i + 1].connectedBody = rigidBodies[i];
        }
    }

    private void Update()
    {
        var vertices = GetConnectionPoints();

                                  lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);
    }

    private Vector3[] GetConnectionPoints()
    {
        return this.points.Select(t => t.position).ToArray();
    }
}
