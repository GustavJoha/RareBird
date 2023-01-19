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
        { //jag satte sliden i en coroutine för att enklare kunna hantera nedräkningen för när spelaren ska ställa sig upp-Gustav
            StartCoroutine(SlideTimer());
            SlideResetTimer = 0;
            
            
        }
        else
        { // när man slidar så får man en liten speed boost som nollställs när man inte slidar på 15 sekunder -Gustav
            SlideResetTimer += Time.deltaTime;
        }

        if (SlideResetTimer > 15)
        {
            SlideResetTimer = 0;

            ForwardSlide = 0;
            SideSlide = 0;
        }

        SlideSpeedBoost = ForwardSlide * transform.forward + SideSlide * transform.right;
        //Det här stycket gör så att vi bara kan adera hastighets bonusen till vectorn i movement scriptet. -Gustav
    }

    IEnumerator SlideTimer()
    {
        IsSliding = true;
        //sätter en variabel så att man vet om spelaren slidar och gör spelaren kortare under sliden -Gustav
        gameObject.transform.localScale = new Vector3(1, 0.5f, 1);
        legs.SetActive(true);

        ForwardSlide += Input.GetAxis("Vertical");
        SideSlide += Input.GetAxis("Horizontal");
        //lägger till hastighet baserat på ens knapptryck när man slidar. -Gustav

        yield return new WaitForSeconds(4);

       
        gameObject.transform.localScale = Vector3.one;
        //nollställer storleks ändringen och låter spelaren slida igen -Gustav
        IsSliding = false;
        legs.SetActive(false);







    }

 



}
