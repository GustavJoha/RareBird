using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pantgubbe : MonoBehaviour
{
	
	public GameObject character;

	[SerializeField]
	public int maxcapacity = 10;

	public int antalBurkar = 0;
	public int antalFlaskor = 0;
	public int capacity;
	public int pengar = 0;
	public Text score;
	public Text pant;
    private void Start()
    {
		capacity = maxcapacity;
    }
    void Update()
	{
		score.text = pengar.ToString();
		pant.text = ("Burkar: " + antalBurkar.ToString() + " Flaskor: " + antalFlaskor.ToString() + "Utrymme kvar i v�ska: " + capacity.ToString() + "/" + maxcapacity.ToString() );
	}

}
