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
    public float playerVelocity;

    [SerializeField]
    public Running_Around spring;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        playerVelocity = 6;
        float mappedPlayerSpeed = playerVelocity; //Convert the speed so that walking speed is about 6
        float stepsPerSecond = ((a * Mathf.Pow(mappedPlayerSpeed, n)) + (b * mappedPlayerSpeed) + c) / 60.0f;
        float timePerStep = (1.0f / stepsPerSecond);
        float currentFootstepsWaitingPeriod = timePerStep; //Amount of time to wait before playing the next audio source
        float sound = timePerStep -= Time.deltaTime;

        if (true)
        {
            audioSource.Play();
        }
    }



}
