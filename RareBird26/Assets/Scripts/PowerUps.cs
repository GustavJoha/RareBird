using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Running_Around running;
    public timer timer;
    public Jump Jump;
 
   void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("SpeedUp"))
        {
            running.speedUp();
        }
        if (collider.CompareTag("merTid"))
        {
            timer.powerTid();
        }
        if (collider.CompareTag("DoubleJump"))
        {
            Debug.Log ("doublejump");
            Jump.powerJump();
        }
    }

}
