using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	public void Start()
	{
		
	}
	
	public void Update()
	{
		transform.position = new Vector3(transform.position.x, transform.localScale.y * 0.5f, transform.position.z);
	}
}
