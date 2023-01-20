using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantmaskin : MonoBehaviour
{
    public Pantgubbe gubbe;

    [SerializeField]
    float panttid = 1f;

    AudioSource AudioSource;
    public AudioClip panthint;
    public AudioClip burkhint;
    public AudioClip pantmaskin;
    public AudioClip komvellen;
    public float tid = 0f;

    [SerializeField]
    float hinttid = 5.0f;

    private float tid2 = 5.0f;
    private int velkommen = 0;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        velkommen = 0;
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
        if (velkommen == 0)
        {
            AudioSource.PlayOneShot(komvellen);
            velkommen = 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (tid == 0)
        {
            tid2 -= Time.deltaTime;
        }
        else
        {
            tid2 = hinttid;
        }
        if (tid2 <= 0)
        {
            if(gubbe.capacity == gubbe.maxcapacity)
            {
                print("kom tillbaka");
                AudioSource.PlayOneShot(burkhint);
                tid2 = hinttid;
                tid = 0.1f;
            }
            else
            {
                print("håll in e för att panta");
                AudioSource.PlayOneShot(panthint);
                tid2 = hinttid;
                tid = 0.1f;
            }
        }
        if ((tid >= panttid) && (gubbe.capacity < gubbe.maxcapacity))
        {
            if (gubbe.antalBurkar > 0)
            {
                Pantgubbe.pengar++;
                gubbe.capacity++;
                gubbe.antalBurkar--;
            }
            else
            {
                Pantgubbe.pengar = Pantgubbe.pengar + 2;
                gubbe.capacity = gubbe.capacity + 2;
                gubbe.antalFlaskor--;
            }
            tid = 0;
        }
        else if ((Input.GetKey(KeyCode.E)) && (gubbe.capacity < gubbe.maxcapacity) && !AudioSource.isPlaying)
        {
            AudioSource.PlayOneShot(pantmaskin);
        }
    }
}
