using UnityEngine;
using System.Collections;

public class InitialPush : MonoBehaviour
{
    public float PushForce;
    public float Decceleration;

	private bool _isPushing;

	private Vector3 _pushVector;

	public void Start()
	{
        //StartCoroutine("Push");

		_isPushing = false;

		_pushVector = new Vector3(0.0f, 0.0f, PushForce);
	}
	
	public void Update()
	{
        if (_isPushing && PushForce > 0)
        {
            transform.position += transform.rotation * _pushVector;
        }
	}

	public void PushPlayer()
	{
		StartCoroutine("Push");
	}

    public IEnumerator Push()
	{
		//Debug.Log("Pushing Player");

		_isPushing = true;

	    var currentPushForce = PushForce;

        while (currentPushForce > 0)
        {
            //Debug.Log("PushForce: " + PushForce);

            currentPushForce -= Decceleration * Time.deltaTime;

            yield return null;
        }

		_isPushing = false;
    }
}
