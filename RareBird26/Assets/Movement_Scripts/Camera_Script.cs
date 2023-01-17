using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public Transform Bodytransform;

    public int sensitivity = 100;

    // Start is called before the first frame update
    void Start()
    {
        Bodytransform = transform.parent.GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
    }



        float Vertical_Rotation; //kamerans vertikala rotation måste lagras i en variabel för att kunna clampas ordentligt. -Gustav


    // Update is called once per frame
    void Update()
    {
        Bodytransform.Rotate(Vector3.up * Input.GetAxis("Mouse X")*Time.deltaTime*sensitivity); //Roterar spelar objektet baserat på mus rörelse -Gustav

        Vertical_Rotation -= Input.GetAxis("Mouse Y")*Time.deltaTime*sensitivity;

        Vertical_Rotation = Mathf.Clamp(Vertical_Rotation, -90, 90); //förhindrar spelar kameran från att kunna snurra vertikalt. -Gustav

        transform.localRotation = Quaternion.Euler(Vector3.right * Vertical_Rotation); //Roterar kameran vertikalt baserat på mus rörelse -Gustav
    }
}
