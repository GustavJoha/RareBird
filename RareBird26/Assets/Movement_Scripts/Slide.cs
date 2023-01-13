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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && IsSliding == false)
        {
            StartCoroutine(SlideTimer());
            SlideResetTimer = 0;
        }
        else
        {
            SlideResetTimer += Time.deltaTime;
        }

        if (SlideResetTimer > 15)
        {
            SlideResetTimer = 0;

            ForwardSlide = 0;
            SideSlide = 0;
        }

        SlideSpeedBoost = ForwardSlide * transform.forward + SideSlide * transform.right;
    }

    IEnumerator SlideTimer()
    {
        IsSliding = true;

        gameObject.transform.localScale = new Vector3(1, 0.5f, 1);

        ForwardSlide += Input.GetAxis("Vertical");
        SideSlide += Input.GetAxis("Horizontal");

        yield return new WaitForSeconds(4);

        gameObject.transform.localScale = Vector3.one;

        IsSliding = false;
    }

    
}
