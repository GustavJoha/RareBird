using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerljud : MonoBehaviour
{
    AudioSource AudioSource;
    float lastFootstepPlayedTime;
    Vector3 lastPlayerPosition;
    float VELOCITY_POLL_PERIOD = 0.2f; // 5 times a second
    private Vector3 playerPosition;
    private float stepsPerSecond;
    private object timePerStep;
    private float currentFootstepsWaitingPeriod;

    public void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        InvokeRepeating("EstimatePlayerVelocity_InvokeRepeating", 1.0f, VELOCITY_POLL_PERIOD);
    }

    public void EstimatePlayerVelocity_InvokeRepeating()
    {

        float distanceMagnitude = (playerPosition - lastPlayerPosition).magnitude;
        lastPlayerPosition = playerPosition;
        float estimatedPlayerVelocity = distanceMagnitude / VELOCITY_POLL_PERIOD;
        if (estimatedPlayerVelocity < 15.0f)
        {
            //Avoid playing footsteps audio for moving at very small speeds
            //As the human foot moves forward, the head (camera) moves forward before the foot hits the ground
            //because the current foot on the ground pushes the body forward.
            currentFootstepsWaitingPeriod = Mathf.Infinity;
            return;
        }

        const float a = 0.24f;
        const float n = 2.0f;
        const float b = 1.68f;
        const float c = 159.0f;
        float mappedPlayerSpeed = estimatedPlayerVelocity / 10.0f; //Convert the speed so that walking speed is about 6
        stepsPerSecond = ((a * Mathf.Pow(mappedPlayerSpeed, n)) + (b * mappedPlayerSpeed) + c) / 60.0f;
        timePerStep = (1.0f / stepsPerSecond);
        currentFootstepsWaitingPeriod = (float)timePerStep;




    }
        public void Update()
        {

            if (Time.time - lastFootstepPlayedTime > currentFootstepsWaitingPeriod)
            {

            //Play another footstep  audio file
                AudioSource.Play();
                lastFootstepPlayedTime = Time.time;
            }

        }
}
