using UnityEngine;
using System.Collections;

public class Lanterna : MonoBehaviour {
	public AudioClip SomLanterna;
	private AudioSource source;
	public Light Luz;
	public float cont = 3;





	// Use this for initialization
	void Start () {
		source = GetComponent <AudioSource> ();
		Luz.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (cont < 0.5f) {
			cont += Time.deltaTime;
		}




			


			if (Input.GetButtonDown ("Fire2") && cont >= 0.5f) {
				Luz.enabled = !Luz.enabled;
				source.PlayOneShot (SomLanterna);
				cont = 0;

		
			}
		}
	}



