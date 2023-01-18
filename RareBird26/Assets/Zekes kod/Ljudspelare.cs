using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ljudspelare : MonoBehaviour
{
    public AudioClip burk;
    public AudioClip flaska;
    public AudioClip powerUp;
    AudioSource ljud;
    void Start()
    {
        ljud = GetComponent<AudioSource>();
    }
    public void Burk()
    {
        ljud.PlayOneShot(burk);
    }
    public void PowerUp()
    {
        ljud.PlayOneShot(powerUp);
    }
}
