using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running_Around : MonoBehaviour
{
    Rigidbody RB;
    Animator anim;

    public static bool IsMoving = false;

    public float ForwardRun;
    float SideRun;

    public float Acceleration;
    public float DeAcceleration;

    Vector3 PlayerVelocity;

    Slide SlideTracker;
    public float powerTimer = 10f;
    public bool speedpower = false;

    float speedboost;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        SlideTracker = GetComponent<Slide>();
        IsMoving = false;
    }

    void Update()
    {
        ForwardRun += Input.GetAxis("Vertical")*Time.deltaTime*Acceleration;
        // Den här koden låter spelaren bygga upp momentum över tid istället för att accelerera direkt. -Gustav
        ForwardRun = Mathf.Clamp(ForwardRun, -15, 15);
        anim.SetBool("Move", IsMoving);

        if(Input.GetAxis("Vertical") == 0)
        {// Om spelaren inte rör sig i en riktning så börjar dem deaccelerera i den riktningen. -Gustav
            IsMoving = false;

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
        else
        {
         
          IsMoving = true;
        }
        

        //Det här stycket gör samma sak som ovanstående fast för sida till sida -Gustav
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

        PlayerVelocity = (transform.forward * ForwardRun + transform.right * SideRun * Acceleration + SlideTracker.SlideSpeedBoost) * speedboost;
        //Här använder vi dem tidigare värdena för att framställa hastighet relativt till riktning som spelaren är vänd emot

       PlayerVelocity.y += RB.velocity.y;
        //den här raden får karaktären att falla ordentligt. 


        RB.velocity = PlayerVelocity;

        if (speedpower)
        {
            speedboost = 2;
            Debug.Log("power");
        } else
        {
            speedboost = 1;
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
