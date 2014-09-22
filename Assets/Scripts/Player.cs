using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float WalkSpeed;
	public float RunSpeed;

	private Vector3 _inputVector;

	private const float DeadZone = 0.2f;

	public void Start()
	{
		_inputVector = new Vector3();
	}
	
	public void Update()
	{
		_inputVector.x = Input.GetAxis("Horizontal");
		_inputVector.z = Input.GetAxis("Vertical");

		_inputVector = transform.rotation * _inputVector;

		if (_inputVector.magnitude > DeadZone)
		{
			if (Input.GetButton("Run"))
			{
				transform.position += _inputVector * RunSpeed * Time.deltaTime;
			}
			else
			{
				transform.position += _inputVector * WalkSpeed * Time.deltaTime;
			}
		}
	}
}
