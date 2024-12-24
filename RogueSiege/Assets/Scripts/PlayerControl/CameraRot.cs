using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    private float x;
    private float y;
    private Vector3 rotateValue;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1f)
        {
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            rotateValue = new Vector3(x, y * -1, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
        }

    }
}
