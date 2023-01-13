using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pantgubbe : MonoBehaviour
{
	private float speed = 2.0f;
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

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.back * speed * Time.deltaTime;
		}
		score.text = pengar.ToString();
		pant.text = ("Burkar: " + antalBurkar.ToString() + " Flaskor: " + antalFlaskor.ToString() + "Utrymme kvar i väska: " + capacity.ToString() + "/" + maxcapacity.ToString() );
	}

}
