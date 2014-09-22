using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour
{
    public float TimeBetweenStrikes = 2.0f;
    public int NumberOfFlashes = 10;
    public float FlashLength = 0.1f;

    public float MinIntensity = 0f;
    public float MaxIntensity = 0.9f;

    public float MinWaitTime = 0.05f;
    public float MaxWaitTime = 0.8f;

    private Light _light;
    private float _lastLightning;

	public void Start()
	{
        _lastLightning = 0f;

        _light = gameObject.GetComponent<Light>() as Light;
	}
	
	public void Update()
	{
        if (Time.timeSinceLevelLoad - _lastLightning > TimeBetweenStrikes)
        {
            _lastLightning = Time.timeSinceLevelLoad;

            StartCoroutine("LightningStrike");
        }
	}

    private IEnumerator LightningStrike()
    {
        for (var i = 0; i < NumberOfFlashes; i++)
        {
            //Debug.Log("Lightning Strike!");

            _light.intensity = MaxIntensity;

            yield return new WaitForSeconds(FlashLength);

            _light.intensity = MinIntensity;

            var timeToWait = Random.Range(MinWaitTime, MaxWaitTime);
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
