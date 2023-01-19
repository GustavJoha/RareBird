using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    bool IsSliding;

    public Vector3 SlideSpeedBoost;

    float SlideResetTimer;

    public float ForwardSlide;
    public float SideSlide;
    public GameObject legs;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && IsSliding == false)
        { //jag satte sliden i en coroutine f�r att enklare kunna hantera nedr�kningen f�r n�r spelaren ska st�lla sig upp-Gustav
            StartCoroutine(SlideTimer());
            SlideResetTimer = 0;
            
            
        }
        else
        { // n�r man slidar s� f�r man en liten speed boost som nollst�lls n�r man inte slidar p� 15 sekunder -Gustav
            SlideResetTimer += Time.deltaTime;
        }

        if (SlideResetTimer > 15)
        {
            SlideResetTimer = 0;

            ForwardSlide = 0;
            SideSlide = 0;
        }

        SlideSpeedBoost = ForwardSlide * transform.forward + SideSlide * transform.right;
        //Det h�r stycket g�r s� att vi bara kan adera hastighets bonusen till vectorn i movement scriptet. -Gustav
    }

    IEnumerator SlideTimer()
    {
        IsSliding = true;
        //s�tter en variabel s� att man vet om spelaren slidar och g�r spelaren kortare under sliden -Gustav
        gameObject.transform.localScale = new Vector3(1, 0.5f, 1);
        legs.SetActive(true);

        ForwardSlide += Input.GetAxis("Vertical");
        SideSlide += Input.GetAxis("Horizontal");
        //l�gger till hastighet baserat p� ens knapptryck n�r man slidar. -Gustav

        yield return new WaitForSeconds(4);

       
        gameObject.transform.localScale = Vector3.one;
        //nollst�ller storleks �ndringen och l�ter spelaren slida igen -Gustav
        IsSliding = false;
        legs.SetActive(false);







    }

 



}
