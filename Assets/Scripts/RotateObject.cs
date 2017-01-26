using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public float rotationSpeed;

	void Start () {
		
	}

	void Update () {
        this.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
	}
}
