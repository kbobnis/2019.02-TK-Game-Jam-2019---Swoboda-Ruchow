using System.Collections;
using UB;
using UnityEngine;

[RequireComponent(typeof(D2FogsPE))]
public class FogRandomizer : MonoBehaviour
{
    public D2FogsPE fog;

    private void Awake()
    {
        fog = GetComponent<D2FogsPE>();
    }

    private void Start()
    {
        var windDir = Random.insideUnitCircle;
        var widnStr = Random.Range((float) 0.3, (float) 0.7);
        var nextChange = Random.Range((float) 4.0, (float) 15.0);

        fog.VerticalSpeed = windDir.x * widnStr;
        fog.HorizontalSpeed = windDir.y * widnStr;
    }
}