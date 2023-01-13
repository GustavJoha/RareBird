using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantmaskin : MonoBehaviour
{
    public Pantgubbe gubbe;

    [SerializeField]
    float panttid = 1f;

    AudioSource AudioSource;
    public float tid = 0f;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            tid += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        tid = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if ((tid >= panttid) && (gubbe.capacity < gubbe.maxcapacity))
        {
            if (gubbe.antalBurkar > 0)
            {
                gubbe.pengar++;
                gubbe.capacity++;
                gubbe.antalBurkar--;
            }
            else
            {
                gubbe.pengar = gubbe.pengar + 2;
                gubbe.capacity = gubbe.capacity + 2;
                gubbe.antalFlaskor--;
            }
            tid = 0;
        }
        else if ((Input.GetKey(KeyCode.E)) && (gubbe.capacity < gubbe.maxcapacity) && !AudioSource.isPlaying)
        {
            AudioSource.Play();
        }
    }
}
