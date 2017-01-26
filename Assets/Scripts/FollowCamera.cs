using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    public GameObject lookPos;
    public GameObject player;
    public float rotationSpeed = 1;
    public float damping = 1;
    public Vector3 offset;
    public float camHeight = 2.3f;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + camHeight, transform.position.z);
        offset = lookPos.transform.position - transform.position;
    }

    void LateUpdate()
    {
        if (!Cursor.visible)
        {
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed + Input.GetAxis("RightStickX") * rotationSpeed;
            player.transform.Rotate(0, horizontal, 0);
        }
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = player.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping * rotationSpeed);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        //transform.position = player.transform.position - (rotation * offset);

        Vector3 result = player.transform.position - (rotation * offset);

        transform.position = new Vector3(result.x, player.transform.position.y + camHeight, result.z);
        transform.LookAt(lookPos.transform);
        
    }
}
