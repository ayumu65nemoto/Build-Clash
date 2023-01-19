using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftView : MonoBehaviour
{
    GameObject mainCamera;
    GameObject fieldObject;
    float rotateSpeed=2.0f;
    private Vector3 lastPosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        this.fieldObject = GameObject.Find("field");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)|| Input.touchCount == 1)
        {
            newAngle = mainCamera.transform.localEulerAngles;
            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0)|| Input.touchCount == 2)
        {
            rotateCamera();
        }
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(
                Input.GetAxis("Mouse X") * this.rotateSpeed,
                Input.GetAxis("Mouse Y") * this.rotateSpeed,
                0
            );
        
            this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, Vector3.up, angle.x);
       
            this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, transform.right, angle.y);
        
    }
}
