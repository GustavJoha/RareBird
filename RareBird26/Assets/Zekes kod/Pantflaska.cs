using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantflaska : MonoBehaviour
{
    [SerializeField]
    [Range (1,2)]
    int storlek = 1;
    public Pantgubbe gubbe;
    public Ljudspelare kamra;

    AudioSource jagvilldo;
    private void Start()
    {
        jagvilldo = GetComponent<AudioSource>();
        gubbe = FindObjectOfType<Pantgubbe>();
        kamra = FindObjectOfType<Ljudspelare>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        print("hej hej");
        if ((gubbe.capacity - storlek >= 0) && collider.CompareTag("Player"))
        {
            Debug.Log("hej 2");
            gubbe.capacity -= storlek;

            if (storlek == 1)
            {
                gubbe.antalBurkar++;
                kamra.Burk();
            }
            else
                gubbe.antalFlaskor++;
            gameObject.SetActive(false);
        }
    }
}
