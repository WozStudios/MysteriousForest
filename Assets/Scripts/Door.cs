using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	public GameObject Player;
	public float TriggerArea;
	public float DoorOpenAngle;
	public float DoorOpenSpeed;
	public int RightLeft;

	private bool _hasOpened;

	public void Start()
	{
		_hasOpened = false;

		DoorOpenAngle *= RightLeft;
	}
	
	public void Update()
	{
		var distance = (Player.transform.position - transform.position).magnitude;
		
		//Debug.Log("Distance to Door: " + distance);
		
		if (distance < TriggerArea && !_hasOpened)
		{
			StartCoroutine("OpenDoor");
		}
	}

	private IEnumerator OpenDoor()
	{
		//Debug.Log("Opening Door");

		//Player.GetComponent<Teleporter>().TeleportPlayer();
		//Player.GetComponent<InitialPush>().PushPlayer();

		_hasOpened = true;

		var doorAngle = 0.0f;

		while (Mathf.Abs(doorAngle - DoorOpenAngle) > 20.0f)
		{
			doorAngle += DoorOpenSpeed * Time.deltaTime * RightLeft;

			transform.localRotation = Quaternion.AngleAxis(doorAngle, Vector3.up);

			yield return null;
		}
	}
}
