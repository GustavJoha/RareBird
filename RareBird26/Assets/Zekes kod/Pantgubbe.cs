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
	public static int pengar = 0;
	public Text score;
	public Text pant;
	public Text flaskor;
	public Text Utrymme;
    private void Start()
    {
		capacity = maxcapacity;
    }
    void Update()
	{
		score.text = (pengar.ToString() + "kr");
		pant.text = ("Burkar: " + antalBurkar.ToString());
		flaskor.text = ("Flaskor: " + antalFlaskor.ToString());
		Utrymme.text = ("Utrymme kvar i väska: " + capacity.ToString() + "/" + maxcapacity.ToString() );
		
	}

}
