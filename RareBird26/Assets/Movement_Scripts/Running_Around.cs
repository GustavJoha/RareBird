using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running_Around : MonoBehaviour
{
    Rigidbody RB;

    float ForwardRun;
    float SideRun;

    public float Acceleration;

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

        ForwardRun = Mathf.Clamp(ForwardRun, -15, 15);

        if(Input.GetAxis("Vertical") == 0)
        {
            if (ForwardRun < -1)
            {
                ForwardRun+=Time.deltaTime * 30;
            } 
            else if (ForwardRun > 1)
            {
                ForwardRun-=Time.deltaTime * 30;
            } else
            {
                ForwardRun = 0;
                SlideTracker.ForwardSlide = 0;
            }
        }

        SideRun += Input.GetAxis("Horizontal")*Time.deltaTime;

        SideRun = Mathf.Clamp(SideRun, -15, 15);

        if (Input.GetAxis("Horizontal") == 0)
        {
            if (SideRun < -1)
            {
                SideRun+=Time.deltaTime * 30;
            }
            else if (SideRun > 1)
            {
                SideRun-=Time.deltaTime * 30;
            }
            else
            {
                SideRun = 0;
                SlideTracker.SideSlide = 0;
            }
        }

        PlayerVelocity = transform.forward * ForwardRun + transform.right * SideRun * Acceleration + SlideTracker.SlideSpeedBoost;


       PlayerVelocity.y += RB.velocity.y;

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
