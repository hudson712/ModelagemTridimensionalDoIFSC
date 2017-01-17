using UnityEngine;
using System.Collections;

public class CapturarChegadaAoObjetivo : MonoBehaviour {

    public bool gatilho = false;

    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.tag == "Player"){
            gatilho = true;
        }
    }

}