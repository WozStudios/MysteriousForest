using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject BeachSound;
	public GameObject BeachLight;

	public GameObject ForestSound;
	public GameObject ForestLight;

	public GameObject PlayerRain;

	public GameObject[] DoorsToClose;

	public void Start()
	{
		Screen.showCursor = false;
	}
	
	public void Update()
	{
		if (Input.GetButtonDown("Exit"))
		{
			Application.Quit();
		}

        if (Input.GetButtonDown("NextLevel"))
        {
            Application.LoadLevel("Beach");
        }
	}

	public void SetupBeach()
	{
		//Debug.Log("Setting up Beach");

		var beachSound = BeachSound.GetComponent<AudioSource>();
		beachSound.enabled = !beachSound.enabled;

		var beachLight = BeachLight.GetComponent<Light>();
		beachLight.enabled = !beachLight.enabled;

		var forestSound = ForestSound.GetComponent<AudioSource>();
		forestSound.enabled = !forestSound.enabled;

		var forestLights = ForestLight.GetComponentsInChildren<Light>();
		foreach (var forestLight in forestLights)
		{
			forestLight.enabled = !forestLight.enabled;
		}

		var playerRain = PlayerRain.GetComponent<ParticleSystem>();
		playerRain.enableEmission = !playerRain.enableEmission;

		var ambientColor = beachLight.enabled ? new Color(0.343f, 0.328f, 0.293f) : new Color();
		RenderSettings.ambientLight = ambientColor;

		foreach (var door in DoorsToClose)
		{
			door.transform.localRotation = new Quaternion();
		}
	}
}
