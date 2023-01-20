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
        // Den h�r koden l�ter spelaren bygga upp momentum �ver tid ist�llet f�r att accelerera direkt. -Gustav
        ForwardRun = Mathf.Clamp(ForwardRun, -15, 15);
        anim.SetBool("Move", IsMoving);

        if(Input.GetAxis("Vertical") == 0)
        {// Om spelaren inte r�r sig i en riktning s� b�rjar dem deaccelerera i den riktningen. -Gustav
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

        PlayerVelocity = (transform.forward * ForwardRun + transform.right * SideRun * Acceleration + SlideTracker.SlideSpeedBoost) * speedboost;
        //H�r anv�nder vi dem tidigare v�rdena f�r att framst�lla hastighet relativt till riktning som spelaren �r v�nd emot

       PlayerVelocity.y += RB.velocity.y;
        //den h�r raden f�r karakt�ren att falla ordentligt. 


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
