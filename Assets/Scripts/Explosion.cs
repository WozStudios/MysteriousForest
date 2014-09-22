using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    public float ExplosionForce;
    public float ExplosionRadius;
    public float UpwardsModifier;

	public GameObject[] ObjectsToDestroy;

    private List<GameObject> _explodables;
 
	public void Start()
	{
        //_explodables = new List<GameObject>(GameObject.FindGameObjectsWithTag("Explodable"));
        //Debug.Log(string.Format("# of Explodables: {0}", _explodables.Count));
	}
	
	public void Update()
	{
		//foreach (GameObject go in _explodables)
		//{
		//	Rigidbody body = go.GetComponentInChildren<Rigidbody>();
		//	body.useGravity = true;
		//	body.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius, UpwardsModifier);
		//}
}

	public void Explode()
	{
		//Debug.Log("Exploding!");

		GetComponent<AudioSource>().Play();

		var detonators = GetComponentsInChildren<Detonator>();
		foreach (var detonator in detonators)
			detonator.Explode();

		foreach (var go in ObjectsToDestroy)
		{
			Destroy(go);
		}
	}
}
