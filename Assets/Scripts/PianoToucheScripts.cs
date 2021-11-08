using UnityEngine;
using System.Collections;

public class PianoToucheScript : MonoBehaviour
{

	//public float semitone_offset = 0;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	void OnMouseDown()
	{
		//GetComponent<AudioSource>().pitch = Mathf.Pow(2f, semitone_offset / 12.0f);
		transform.Rotate(Vector3.up * -2);
		GetComponent<AudioSource>().Play();
	}

	void OnMouseUp()
    {

		transform.Rotate(Vector3.up * 2);
	}
}