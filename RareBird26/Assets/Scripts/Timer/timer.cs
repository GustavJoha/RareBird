using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float TidKvar = 120;
    public bool timernTickar = false;
    public Text timetext;
    public Text CountdownText;
    public float CountdownTime = 3;
    public bool Countdown = true;
    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    void Update()
    {

     
       

        if (timernTickar)
        {
            timetext.gameObject.SetActive(true);
            DisplayTime(TidKvar);
            if (TidKvar > 0)
            {
                TidKvar -= Time.deltaTime;
            }
            else
            {

                Debug.Log("Tiden är slut");
                TidKvar = 0;
                timernTickar = false;
            }
        }
    }
    void DisplayTime(float TidKvar)
    {
        float minutes = Mathf.FloorToInt(TidKvar / 60);
        float seconds = Mathf.FloorToInt(TidKvar % 60);
        timetext.text = string.Format("{0:00} : {1:00}", minutes, seconds);
       
    }
   
    
    IEnumerator StartCountdown()
    {
        while(CountdownTime > 0)
        {
            CountdownText.text = CountdownTime.ToString();
            yield return new WaitForSeconds(1);
            CountdownTime--; 
        }
        CountdownText.text = "Go!!";
        yield return new WaitForSeconds(1);
        CountdownText.gameObject.SetActive(false);
        timernTickar = true;

    }
}


