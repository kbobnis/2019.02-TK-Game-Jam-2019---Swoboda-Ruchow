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
    }

    public void Update()
    {
        lineRenderer.SetPositions(new [] { transform.position }.Concat(points.Select(t => t.position)).ToArray());
    }
}
