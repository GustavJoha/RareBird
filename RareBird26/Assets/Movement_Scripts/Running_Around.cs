using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running_Around : MonoBehaviour
{
    Rigidbody RB;

    float ForwardRun;
    float SideRun;

    public float Acceleration;
    public float DeAcceleration = 30;

    Vector3 PlayerVelocity;

    Slide SlideTracker;
    public float powerTimer = 10f;
    public bool speedpower = false;
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        SlideTracker = GetComponent<Slide>();
    }

    void Update()
    {
        ForwardRun += Input.GetAxis("Vertical")*Time.deltaTime*Acceleration;
        // Den h�r koden l�ter spelaren bygga upp momentum �ver tid ist�llet f�r att accelerera direkt. -Gustav
        ForwardRun = Mathf.Clamp(ForwardRun, -15, 15);
        

        if(Input.GetAxis("Vertical") == 0)
        {// Om spelaren inte r�r sig i en riktning s� b�rjar dem deaccelerera i den riktningen. -Gustav
            if (ForwardRun < -1)
            {
                ForwardRun+=Time.deltaTime * DeAcceleration;
            } 
            else if (ForwardRun > 1)
            {
                ForwardRun-=Time.deltaTime * DeAcceleration;
            } else
            {
                ForwardRun = 0;
                SlideTracker.ForwardSlide = 0;
            }
        }


        //Det h�r stycket g�r samma sak som ovanst�ende fast f�r sida till sida -Gustav
        SideRun += Input.GetAxis("Horizontal")*Time.deltaTime;

        SideRun = Mathf.Clamp(SideRun, -15, 15);

        if (Input.GetAxis("Horizontal") == 0)
        {
            if (SideRun < -1)
            {
                SideRun+=Time.deltaTime * DeAcceleration;
            }
            else if (SideRun > 1)
            {
                SideRun-=Time.deltaTime * DeAcceleration;
            }
            else
            {
                SideRun = 0;
                SlideTracker.SideSlide = 0;
            }
        }

        PlayerVelocity = transform.forward * ForwardRun + transform.right * SideRun * Acceleration + SlideTracker.SlideSpeedBoost;
        //H�r anv�nder vi dem tidigare v�rdena f�r att framst�lla hastighet relativt till riktning som spelaren �r v�nd emot

       PlayerVelocity.y += RB.velocity.y;
        //den h�r raden f�r karakt�ren att falla ordentligt. 


        RB.velocity = PlayerVelocity;

        if (speedpower)
        {
            PlayerVelocity *= 10f;
            Debug.Log("power");
        }
    }
    public void speedUp()
    {

        StartCoroutine(PowerUp());
        
        IEnumerator PowerUp()
        {
            speedpower = true;
            yield return new WaitForSeconds(powerTimer);
            speedpower = false;
        }
        
       
    }
}
