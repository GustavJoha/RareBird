using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantflaska : MonoBehaviour
{
    [SerializeField]
    [Range (1,2)]
    int storlek = 1;
    public Pantgubbe gubbe;


    private void OnTriggerEnter(Collider collider)
    {
        print("hej hej");
        if ((gubbe.capacity - storlek >= 0) && collider.CompareTag("Player"))
        {
            gubbe.capacity -= storlek;
            gameObject.SetActive(false);
            if (storlek == 1)
                gubbe.antalBurkar++;
            else
                gubbe.antalFlaskor++;

        }
    }
}
