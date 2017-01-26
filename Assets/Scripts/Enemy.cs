using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform[] wayPointList;
    public int currentWayPoint = 0;
    public Transform targetWayPoint;

    public Vector3 wantedRot;
    public Vector3 wantedPos;

	void Start () {

        

	}
	
	void Update () {
		if(wayPointList.Length != 0)
        {
            if (currentWayPoint < wayPointList.Length)
            {
                if (targetWayPoint == null)
                {
                    targetWayPoint = wayPointList[currentWayPoint];

                }
                Walk();
            }
        }
	}

    public void Walk()
    { 
        wantedRot = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, this.GetComponent<Stats>().rotationSpeed * Time.deltaTime, 0.0f);
        transform.forward = new Vector3(wantedRot.x, transform.forward.y, wantedRot.z);
        wantedPos = Vector3.MoveTowards(transform.position, targetWayPoint.position, this.GetComponent<Stats>().movementSpeed * Time.deltaTime);
        transform.position = new Vector3(wantedPos.x, transform.position.y, wantedPos.z);
        if(isCloseToGoalPoint())
        {
            currentWayPoint++;
            if(currentWayPoint < wayPointList.Length)
            {
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
    }

    public bool isCloseToGoalPoint()
    {
        if(transform.position.x < targetWayPoint.position.x + 0.1f && transform.position.x >= targetWayPoint.position.x - 0.1f)
        {
            if (transform.position.z < targetWayPoint.position.z + 0.1f && transform.position.z >= targetWayPoint.position.z - 0.1f)
            {
                return true;
            }
            
        }
        return false;
    }
}
