using UnityEngine;
using System.Collections;

public class Skydome : MonoBehaviour
{

    public float Speed = 1.0f;

	public void Start()
	{
	
	}
	
	public void Update()
	{
        transform.Rotate(Vector3.up, Speed * Time.deltaTime);
	}
}
