using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoist : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 GoalPos;
    float TimeReq;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(new Ray(transform.position - transform.up, transform.forward), 1.1f, 1) == true && Physics.Raycast(new Ray(transform.position + Vector3.up, transform.forward), 1.1f, 1) == false)
        {
            print("Yes");
        }
    }
}
