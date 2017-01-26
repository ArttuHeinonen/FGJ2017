using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour {

	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ToggleMouseLock()
    {
        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.RightAlt) || Input.GetButton("Start"))
        {
            ToggleMouseLock();
        }
    }
}
