using UnityEngine;
using System.Collections;

public class movimentoPlanetario : MonoBehaviour {


	public Transform outroAstro;
	public float velTrans = 2;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (outroAstro.position,transform.up,velTrans*Time.deltaTime);

	}
}
