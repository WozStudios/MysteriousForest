using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class Pedestal : MonoBehaviour
{
	public void Start()
	{
		//TogglePedestal();
	}

	public void EnablePedestal()
	{
		var renderers = GetComponentsInChildren<MeshRenderer>();

		foreach (var meshRenderer in renderers)
		{
			meshRenderer.enabled = true;
		}
	}
}
