using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BirdGenerator : MonoBehaviour
{
	public GameObject Bird;
	public int NumberOfBirds;

	private Queue<GameObject> _birds;
	private GameObject _birdsParent;
	private const float BoundSize = 600.0f;


	public void Start()
	{
		_birds = new Queue<GameObject>();
		_birdsParent = new GameObject("Birds");

		for (var i = 0; i < NumberOfBirds; i++)
		{
			CreateBird();
		}
	}

	private void CreateBird()
	{
		var xOffset = Random.Range(-BoundSize/2, BoundSize/2);
		var yOffset = 100.0f + Random.Range(-10.0f, 10.0f);
		var zOffset = Random.Range(-BoundSize * 0.8f, BoundSize * 0.8f);
		var position = transform.position + new Vector3(xOffset, yOffset, zOffset);
		var rotation = Quaternion.AngleAxis(Random.Range(0, 360.0f), Vector3.up);

		var bird = Instantiate(Bird, position, rotation) as GameObject;
		bird.transform.parent = _birdsParent.transform;
		_birds.Enqueue(bird);
	}

	public void Update()
	{
		//foreach (var bird in _birds)
		//{
		//	if (!InBounds(bird))
		//	{
		//		var birdComponent = bird.GetComponent<Bird>();
		//		birdComponent.DestroyBird();
		//	}
		//}

		//Debug.Log("Number Of Birds: " + NumberOfBirds);
	}

	private bool InBounds(GameObject bird)
	{
		return Mathf.Abs(bird.transform.position.x - transform.position.x) < BoundSize &&
		       Mathf.Abs(bird.transform.position.y - transform.position.y) < BoundSize;
	}
}
