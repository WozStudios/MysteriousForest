using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour
{
    public GameObject Plank;
    public GameObject PlankMesh;
    public int NumberOfPlanks = 10;
    public float PlankWidth = 0.3f;
    public float GapWidth = 0.02f;
    
	public void Start()
	{
        var planks = new GameObject("CabinWall");
        planks.transform.position = transform.position;
	    
        for (var i = 0; i < NumberOfPlanks; i++)
        {

            var position = new Vector3(transform.position.x + i * (PlankWidth + GapWidth), transform.position.y, transform.position.z);
            var plank = Instantiate(Plank, position, transform.rotation) as GameObject;
            plank.transform.parent = planks.transform;

            var mesh = plank.GetComponentInChildren(typeof(MeshRenderer));

            float offset = Random.Range(0.1f, 0.9f) * i;
            mesh.renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
            mesh.renderer.material.SetTextureOffset("_BumpMap", new Vector2(0, offset));
        }
	}
	
	public void Update()
	{
	
	}
}
