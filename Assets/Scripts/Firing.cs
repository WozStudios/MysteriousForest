using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour
{
    public GameObject Bullet;

    private GameObject _bullets;

	public void Start()
	{
        _bullets = new GameObject("Bullets");
	}
	
	public void Update()
	{
        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("Firing");

            var bullet = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
            bullet.transform.Rotate(Vector3.up, 90);
            bullet.transform.parent = _bullets.transform;
        }
	}
}
