using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour {

    public static Quaternion rotation;

    public GameObject arrow;
    public float maxMagnitude = 0;

    private int frame = 0;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private Material materialColored;

    private ArrayList arrows = new ArrayList(); 

    private float timePassed = 0;

	// Use this for initialization
	void Start () {
        
        generateVectorField(2, 1);

	}

    // Update is called once per frame
    void Update()
    {
        frame++;
        rotation = transform.rotation;

        if (frame % 1 == 0)
        {
            timePassed += Time.deltaTime / 2;
            clearVectorField();
            generateVectorField(2, timePassed);
        }

	}


    void clearVectorField() {
        for (int i = 0; i < arrows.Count; i++) {
            Destroy((GameObject)arrows[i]);
            maxMagnitude = 0;
        }
        while (arrows.Count != 0) {
            arrows.RemoveAt(0);
        }
    }

    void generateVectorField(float spacing, float t) {

        for (int x = -2; x < 2; x++)
        {
            for (int y = -2; y < 2; y++)
            {
                for (int z = -2; z < 2; z++){ 
                    Vector3 r = vectorValuedFunction(spacing * x, spacing * y, spacing * z, t);
                    float magnitude = Mathf.Pow(r.x * r.x + r.y * r.y + r.z * r.z, .5f);
                    if (maxMagnitude < magnitude)
                        maxMagnitude = magnitude;
                }
            }
        }


        for (int x = -2; x <= 2; x++) {
            for (int y = -2; y <= 2; y++) {
                for (int z = -2; z <= 2; z++) {
                    Vector3 r = vectorValuedFunction(spacing * x, spacing * y, spacing * z, t);
                    float magnitude = Mathf.Pow(r.x * r.x + r.y * r.y + r.z * r.z, .5f);
                    Color color = new Color(magnitude / maxMagnitude, 0, 1 - (magnitude / maxMagnitude));

                    materialColored = new Material(Shader.Find("Diffuse"));
                    materialColored.color = color;
                    Renderer[] renderers = arrow.GetComponentsInChildren<Renderer>();
                    foreach (Renderer rend in renderers) {
                        rend.material = materialColored;
                    }

                    Vector3 rotationEuler = Quaternion.LookRotation(r).eulerAngles + new Vector3(90, 0, 0);
                    Quaternion rotation = Quaternion.Euler(rotationEuler);
                    if (System.Math.Abs(magnitude) > .0001)
                    {
                        arrows.Add(Instantiate(arrow, new Vector3(x * spacing, y * spacing, z * spacing), rotation));
                    }

                 
                }
            }
        }
    }

    //modify this to change the function
    Vector3 vectorValuedFunction(float x, float y, float z, float t) {
        
        return new Vector3(Mathf.Cos(y * t), Mathf.Sin(x * t) * z, 0);
    
    }
}
