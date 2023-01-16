using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody RB;
    public bool powerdoubble = false;
    public float doublejump = 2;
    public float jumpPowerTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerdoubble == false)
        {
            if (Physics.Raycast(new Ray(transform.position, Vector3.down), 1.1f, 1) && Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(Vector3.up * 500);
            }
        }
        if (powerdoubble)
        {
            Debug.Log("dj");
            if (Physics.Raycast(new Ray(transform.position, Vector3.down), 1.1f, 1))
            {
                doublejump = 2;
            }
            if (Input.GetKeyDown(KeyCode.Space) && doublejump > 1)
            {
                RB.AddForce(Vector3.up * 500);
                doublejump -= 1;
                
            }
        }
    }
    public void powerJump()
    {
        StartCoroutine(JumpPower());
        IEnumerator JumpPower()
        {
            powerdoubble = true;
            yield return new WaitForSeconds(jumpPowerTime);
            powerdoubble = false;
        }

    }
}
