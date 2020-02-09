using UnityEngine;
using System.Collections;

// Creates a cube primitive

public class ExampleClass : MonoBehaviour
{
    private float x= (float) .04;
    private float y= (float) 10;
    private float z=(float) .04;

    void Start()
    {	
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
	    cube.transform.localScale = new Vector3(x, y, z);     //x and z is the floor
	    
	    GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

		cube2.transform.localScale = new Vector3(y, x, z);

	    GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube3.transform.localScale = new Vector3(x, x, y);
	}


}