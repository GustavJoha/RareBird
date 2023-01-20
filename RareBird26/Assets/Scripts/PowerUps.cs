using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Running_Around running;
    public timer timer;
    public Jump Jump;
    public Ljudspelare ljud;
 
   void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("SpeedUp"))
        {
            running.speedUp();
            ljud.PowerUp();
            Destroy(collider.gameObject);
        }
        if (collider.CompareTag("merTid"))
        {
            timer.powerTid();
            ljud.PowerUp();
            Destroy(collider.gameObject);

        }
        if (collider.CompareTag("DoubleJump"))
        {
            Debug.Log ("doublejump");
            Jump.powerJump();
            ljud.PowerUp();
            Destroy(collider.gameObject);

        }
    }

}
