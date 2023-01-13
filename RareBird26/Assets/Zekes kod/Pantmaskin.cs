using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantmaskin : MonoBehaviour
{
    public Movement gubbe;

    private int flaskor;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        flaskor = gubbe.maxcapacity - gubbe.capacity;
        gubbe.pengar = gubbe.pengar + flaskor;
        gubbe.capacity = gubbe.maxcapacity;
    }
}
