using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
	public float Speed;
	public float FadeSpeed;
	public float TurnSpeed;

	private float _heading;

	private float _headingSpeed;

	public void Start()
	{
		_heading = Random.Range(0, 360.0f);
		_headingSpeed = 0.0f;

		StartCoroutine("FadeIn");
	}
	
	public void Update()
	{
		transform.Translate(Vector3.forward * Speed * Time.deltaTime);

		_headingSpeed = Mathf.Sin(Time.timeSinceLevelLoad * TurnSpeed) * 45.0f + Random.Range(-10.0f, 10.0f);
		_heading += _headingSpeed * Time.deltaTime;
		transform.localRotation = Quaternion.AngleAxis(_heading, Vector3.up);
	}

	public void DestroyBird()
	{
		StartCoroutine("FadeOut");
	}

	private IEnumerator FadeIn()
	{
		var renderers = GetComponentsInChildren<MeshRenderer>();

		var alpha = 0.0f;
		while (alpha < 1.0f)
		{
			foreach (var meshRenderer in renderers)
			{
				var color = meshRenderer.material.color;
				meshRenderer.material.color = new Color(color.r, color.g, color.b, alpha);
			}

			alpha += FadeSpeed * Time.deltaTime;

			yield return null;
		}
	}

	private IEnumerator FadeOut()
	{
		var renderers = GetComponentsInChildren<MeshRenderer>();

		var alpha = 1.0f;
		while (alpha >0.0f)
		{
			foreach (var meshRenderer in renderers)
			{
				var color = meshRenderer.material.color;
				meshRenderer.material.color = new Color(color.r, color.g, color.b, alpha);
			}

			alpha += FadeSpeed * Time.deltaTime;

			yield return null;
		}

		//Debug.Log("Bird Destroyed");
		Destroy(gameObject);
	}


}
