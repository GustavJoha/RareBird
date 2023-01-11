using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), 1.1f, 1) && Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(Vector3.up * 500);
        }
    }
}
