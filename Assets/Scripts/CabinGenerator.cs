using UnityEngine;
using System.Collections;

public class CabinGenerator : MonoBehaviour
{
    public GameObject WoodenPlank;
    public GameObject Explosion;

    public float PlankWidth = 0.5f;
    public float PlankHeight = 3.0f;

    public float ColliderGap = 0.001f;

    private GameObject _cabin;

    private int _cabinDepth;
    private int _porchDepth;

	public void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.25f, transform.position.z);

        PlankWidth += ColliderGap;
        PlankHeight += ColliderGap;

        _cabin = new GameObject("Cabin");

        _cabinDepth = 25;
        _porchDepth = 6;

        GenerateCabin();

        var explosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
        explosion.transform.parent = _cabin.transform;
	}

    public void GenerateCabin()
    {
        GenerateSteps();
        GenerateFloor();
        GenerateWalls();
        GenerateRoof();
    }
    
    private void GenerateSteps()
    {
        CreatePlank(0.0f, 0.0f, 0.0f, 90.0f, 0.0f, 90.0f, transform.localScale.y);
        CreatePlank(0, 0, PlankWidth, 90.0f, 0.0f, 90.0f, transform.localScale.y);
        CreatePlank(0, PlankWidth, PlankWidth, 90.0f, 0.0f, 90.0f, transform.localScale.y);

    }

    private void CreatePlank(float x, float y, float z, float xRotation, float yRotation, float zRotation, float yScale)
    {
        var position = new Vector3(
            transform.position.x + x, 
            transform.position.y + y, 
            transform.position.z + z);

        var plank = Instantiate(WoodenPlank, position, transform.rotation) as GameObject;
        plank.transform.localScale = new Vector3(transform.localScale.x, yScale, transform.localScale.z);
        plank.transform.localEulerAngles = new Vector3(Random.Range(0, 3) * xRotation, Random.Range(0, 3) * yRotation, zRotation);
        plank.transform.parent = _cabin.transform;
        plank.tag = "Explodable";
    }

    private void GenerateFloor()
    {
        for (var k = 0; k < _cabinDepth; k++)
        {
            for (var j = 0; j < 3; j++)
            {
                for (var i = 0; i < 4; i++)
                {
                    var x = (i - 1.0f) * PlankHeight;

                    //Debug.Log("j: " + j);
                    if ((k & 1) == 0)
                    {
                        if ((j & 1) == 0)
                        {
                            x += PlankWidth;
                            //Debug.Log("j is even. Offsetting.");
                        }
                    }
                    else
                    {
                        if ((j & 1) != 0)
                        {
                            x += PlankWidth;
                            //Debug.Log("j is even. Offsetting.");
                        }
                    }

                    CreatePlank(x - PlankHeight * 0.5f, j * PlankWidth, (k + 2) * PlankWidth, 90.0f, 0.0f, 90.0f, transform.localScale.y);
                }
            }
        }
    }
    private void GenerateWalls()
    {
        CreateWall(-2.5f * PlankHeight + 0.5f * PlankWidth);
        CreateWall(1.5f * PlankHeight + 0.5f * PlankWidth);
    }

    private void CreateWall(float xPosition)
    {
        for (var k = 0; k < _cabinDepth - _porchDepth; k++)
        {
            float yScale = transform.localScale.y;

            var y = 3.0f * PlankWidth - PlankWidth * 0.5f;

            if (xPosition < 0)
            {
                if ((k & 1) == 0)
                {
                    y -= PlankWidth;
                    yScale = 1.158f;
                }
                else
                {
                    yScale = 0.84f;
                }
            }
            else
            {
                if ((k & 1) != 0)
                {
                    y -= PlankWidth;
                }
            }

            CreatePlank(xPosition, y, (k + _porchDepth + 2.0f) * PlankWidth, 0.0f, 90.0f, 0.0f, yScale);
        }
    }

    private void GenerateRoof()
    {
		//CreatePlank();
    }
}
