using UnityEngine;
using System.Collections;

public class BirdWing : MonoBehaviour
{
	public float FlapSpeed;
	private float _wingAngle;
	private const float MaxAngle = 45.0f;

	public void Start()
	{
		_wingAngle = 0.0f;
	}

	public void Update()
	{
		FlapWing();
	}

	private void FlapWing()
	{
		_wingAngle = Mathf.Sin(Time.timeSinceLevelLoad * FlapSpeed) * MaxAngle;
		//Debug.Log("WingAngle = " + _wingAngle);

		transform.localRotation = Quaternion.AngleAxis(_wingAngle, Vector3.forward);
	} 
}
