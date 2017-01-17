using UnityEngine;
using System.Collections;

public class itenLanterna : MonoBehaviour {

    public bool lanternaCapturada;
    private float distancia;
    private bool visivel;
    
    void Update(){

        GameObject player = GameObject.FindWithTag("Player");
        distancia = Vector3.Distance(player.transform.position, this.transform.position);

        if (distancia <= 1.5f){

            if (!lanternaCapturada) {
                visivel = true;
            }

            if (Input.GetKey(KeyCode.E)){
                visivel = false;
                lanternaCapturada = true;
                this.GetComponent<MeshRenderer>().enabled = false;
            }
        }

    }

    void OnGUI(){
        if (visivel){
            GUI.Box(new Rect((Screen.width / 2) - 250, (Screen.height * 0.90f) - 25, 500, 25), "Aperte [ E ] pegar a lanterna");
        }
    }
}