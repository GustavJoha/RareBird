using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ljudspelare : MonoBehaviour
{
    AudioSource ljud;
    void Start()
    {
        ljud = GetComponent<AudioSource>();
    }
    public void Burk()
    {
        ljud.Play();
    }
}
