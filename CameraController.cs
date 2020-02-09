using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = new Vector3(0, 0, Input.GetAxis("Vertical"));
        this.transform.rotation = FieldGenerator.rotation;
        this.transform.position += .1f * (transform.rotation * forward);

        Vector3 side = new Vector3(Input.GetAxis("Horizontal"),0 , 0 );
        this.transform.position += .1f * (transform.rotation * side);

    }

}

