using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    Camera PlayerCam;
    public Transform Bodytransform;

    public int sensitivity = 100;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCam = GetComponent<Camera>();

        Bodytransform = transform.parent.GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
    }



        float Vertical_Rotation;


    // Update is called once per frame
    void Update()
    {
        Bodytransform.Rotate(Vector3.up * Input.GetAxis("Mouse X")*Time.deltaTime*sensitivity);


        Vertical_Rotation -= Input.GetAxis("Mouse Y")*Time.deltaTime*sensitivity;

        Vertical_Rotation = Mathf.Clamp(Vertical_Rotation, -90, 90);

        transform.localRotation = Quaternion.Euler(Vector3.right * Vertical_Rotation);
    }
}
