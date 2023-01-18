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
    public float sound = 5.0f;

    [SerializeField]
    public Running_Around spring;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        float mappedPlayerSpeed = playerVelocity; //Convert the speed so that walking speed is about 6
        float stepsPerSecond = ((a * Mathf.Pow(mappedPlayerSpeed, n)) + (b * mappedPlayerSpeed) + c) / 60.0f;
        float timePerStep = (1.0f / stepsPerSecond);
        float currentFootstepsWaitingPeriod = timePerStep; //Amount of time to wait before playing the next audio source
        sound -= Time.deltaTime;

        if (sound < 0)
        {
            if (playerVelocity != 0)
            print("fotsteg");
            audioSource.Play();
            sound = timePerStep;
        }
    }



}
