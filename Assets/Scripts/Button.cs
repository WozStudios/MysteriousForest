using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
	public GameObject Explosions;
	public GameObject Player;
	public float Speed;
	public float DetonationDistance;

	private bool _hasExploded;

	public void Start()
	{
		_hasExploded = false;
	}

	public void Update()
	{
		if (_hasExploded)
			return;

		var distance = (transform.position - Player.transform.position).magnitude;

		if (distance > DetonationDistance)
		{ 
			//Debug.Log("Distance: " + distance);
			return;
		}
		
		if (Input.GetButtonDown("Explode"))
		{
			_hasExploded = true;
			StartCoroutine("Press");
		}
	}

	private IEnumerator Press()
	{
		transform.position += transform.rotation * Vector3.down * Speed; // * Time.deltaTime;

		GetComponent<AudioSource>().Play();

		yield return new WaitForSeconds(1.0f);
		
		Explosions.GetComponent<Explosion>().Explode();
	}
}
