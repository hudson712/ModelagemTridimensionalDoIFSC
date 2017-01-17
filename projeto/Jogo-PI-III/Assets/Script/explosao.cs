using UnityEngine;
using System.Collections;

public class Explosao : MonoBehaviour {

    private float distancia;

    private float realTime;
    private float maxTime;

    private bool entrou = false;

	// Update is called once per frame
	void Update () {
        
        // ===============================================================================
        GameObject player = GameObject.FindWithTag("Player");
        distancia = Vector3.Distance(player.transform.position, this.transform.position);

        // ===============================================================================
        if (distancia <= 25f && !entrou){
            entrou = true;
            maxTime = Random.Range(1, 5);
        }
	}

    void FixedUpdate(){
        if (entrou){
            realTime += Time.deltaTime;
            if(realTime >= maxTime){
                // EXPRODIIIIIIIIIIIIIIII
                Debug.LogWarning("Ixprudiu");
            }
        }
    }
}