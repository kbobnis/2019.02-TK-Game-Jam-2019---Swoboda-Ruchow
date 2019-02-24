using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] SinusoidalBlink;

    public Transform[] PoliceLights;

    public double BlinkSpeed;
    public double BlinkMultiplier;
    public double BaseBlinkIntensity;

    public double PoliceSpeed;

    private double acc;


    public void Update()
    {
        acc += Time.deltaTime;

        foreach (var light1 in SinusoidalBlink)
        {
            light1.intensity = (float) (BaseBlinkIntensity + Mathf.Sin((float) (acc * BlinkSpeed)) * BlinkMultiplier);
        }

        foreach (var t in PoliceLights)
        {
            t.localEulerAngles = new Vector3(
                t.localEulerAngles.x,
                t.localEulerAngles.y,
                (float) (t.localEulerAngles.z + PoliceSpeed * Time.deltaTime)
            );
        }
    }
}
