using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float Speed = 10.0f;

	public void Start()
    {
        Debug.Log(string.Format("Bullet y-rotation: {0}", transform.localEulerAngles.y - 90.0f));

        var theta = (transform.localEulerAngles.y - 90.0f) * Mathf.Deg2Rad;
        Debug.Log(string.Format("Theta: {0}", theta));

        var direction = new Vector3();
        direction.x = -Mathf.Sin(theta);
        direction.z = Mathf.Cos(theta);

        transform.position += direction * 2.0f;


        //var direction = (Quaternion.Euler(0, , 0) * Vector3.right);
        
        Debug.Log(string.Format("Bullet Direction: ({0}, {1}, {2})", direction.x, direction.y, direction.z));
        

        rigidbody.AddForce(direction * Speed);
	}
	
	public void Update()
	{
	
	}
}
