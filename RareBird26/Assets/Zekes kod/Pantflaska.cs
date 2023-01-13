using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantflaska : MonoBehaviour
{
    [SerializeField]
    [Range (1,2)]
    int storlek = 1;
    public Movement movement;


    private void OnTriggerEnter(Collider collider)
    {
        print("hej hej");
        if (movement.capacity > 0)
        {
            movement.capacity -= storlek;
            gameObject.SetActive(false);
        }
    }
}
