using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineView : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private LineRenderer lineRenderer;
    private Transform transform;

    private void Start()
    {
        this.lineRenderer = GetComponent<LineRenderer>();
        this.transform = GetComponent<Transform>();
    }

    private void Update()
    {
        var vertices = GetConnectionPoints();

        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);
    }

    private Vector3[] GetConnectionPoints()
    {
        return new [] { transform }.Concat(this.points).Select(t => t.position).ToArray();
    }
}
