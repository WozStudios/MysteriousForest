using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour
{
    public GameObject WarpPointA;
    public GameObject WarpPointB;

    public GameObject WarpCamera;


    

	public void Start()
	{
	
	}
	
	public void Update()
	{
        GameObject closerWarpPoint;
        GameObject furtherWarpPoint;

        var distanceA = (Camera.main.transform.position - WarpPointA.transform.position).magnitude;
        var distanceB = (Camera.main.transform.position - WarpPointB.transform.position).magnitude;

        if (distanceA <= distanceB)
        {
            closerWarpPoint = WarpPointA;
            furtherWarpPoint = WarpPointB;
        }

        else
        {
            closerWarpPoint = WarpPointB;
            furtherWarpPoint = WarpPointA;
        }

        var offset = Camera.main.transform.position - closerWarpPoint.transform.position;

        //WarpCamera.transform.position = furtherWarpPoint.transform.position + offset;
        //WarpCamera.transform.rotation = Camera.main.transform.rotation;
        
        WarpCamera.transform.position = furtherWarpPoint.transform.position;
        //WarpCamera.transform.rotation = Camera.main.transform.rotation;
        //WarpCamera.transform.Rotate(Vector3.up, 180);
        WarpCamera.transform.LookAt(WarpCamera.transform.position + offset);
	}
}
