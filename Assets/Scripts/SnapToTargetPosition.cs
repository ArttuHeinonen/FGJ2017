using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToTargetPosition : MonoBehaviour {

    public Transform target;
    public Vector3 wantedPos;

	void Update () {
        wantedPos = Camera.main.WorldToViewportPoint(target.position);
        transform.position = wantedPos;
	}
}
