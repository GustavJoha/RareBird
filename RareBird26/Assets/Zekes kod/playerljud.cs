using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerljud : MonoBehaviour
{
    const float a = 0.24f;
    const float n = 2.0f;
    const float b = 1.68f;
    const float c = 159.0f;
    AudioSource audioSource;
    public AudioClip steg;
    public float sound = 5.0f;
    public Running_Around hastighet;
    public Jump hopp;
    public float mappedPlayerSpeed;

    [SerializeField]
    public Running_Around spring;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        mappedPlayerSpeed = hastighet.ForwardRun * 6;
        float stepsPerSecond = ((a * Mathf.Pow(mappedPlayerSpeed, n)) + (b * mappedPlayerSpeed) + c) / 60.0f;
        float timePerStep = (1.0f / stepsPerSecond);
        sound -= Time.deltaTime;

        if (sound < 0 && hopp.onground)
        {
            if (mappedPlayerSpeed > 0)
            {
                print("fotsteg");
                audioSource.PlayOneShot(steg);
                sound = timePerStep * 10;
            }

        }
    }



}
