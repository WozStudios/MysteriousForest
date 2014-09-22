using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
	public GameObject Player;
	public GameObject Manager;
	public GameObject BeachStartPoint;
	public GameObject Pedestal;

	public float BlindingFadeSpeed;
	public float DelayTime;

	private bool _hasTeleported;

	public void Start()
	{
		_hasTeleported = false;
	}

	private IEnumerator Teleport()
	{
		var blindingLight = Player.GetComponentInChildren<Light>();

		while (blindingLight.intensity < 8)
		{
			blindingLight.intensity += BlindingFadeSpeed * Time.deltaTime;

			yield return null;
		}

		if (Pedestal != null)
			Pedestal.GetComponent<Pedestal>().EnablePedestal();

		Manager.GetComponent<GameManager>().SetupBeach();

		Player.transform.position = BeachStartPoint.transform.position;
		Player.GetComponent<InitialPush>().PushPlayer();

		while (blindingLight.intensity > 0)
		{
			blindingLight.intensity -= BlindingFadeSpeed * Time.deltaTime;

			yield return null;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (_hasTeleported)
			return;

		_hasTeleported = true;

		//Debug.Log("Transporting Player...");
		StartCoroutine("Teleport");
	}
}
