using UnityEngine;
using System.Collections;

// Script colocado na lanterna
// Se player clicar [ F ] Lanterna é ativada

public class lanterna2 : MonoBehaviour {


    private bool ativo = false;
    private bool ligar = false;
    private float contagem;
	public Light luz;


    private bool possuiLanterna = false;

    void Start(){
		transform.Rotate(0,90,90);
		luz.enabled = false;

    }

    void Update(){

        GameObject lanternaItem = GameObject.FindWithTag("Lanterna");
        possuiLanterna = lanternaItem.GetComponent<itenLanterna>().lanternaCapturada;


        if (Input.GetKeyDown(KeyCode.F)){
            if (possuiLanterna) {
                ativo = true;
                ligar = !ligar;
            }else{

            }
        }

        if (ativo){

            if (contagem <= 30 && ligar) {
				transform.Rotate(0,-4,-4);
                contagem = contagem + 1;
				luz.enabled = true;
            }

            if (contagem >= 0 && !ligar){
				transform.Rotate(0,4,4);
                contagem = contagem - 1;
				luz.enabled = false;
            }
        }
    }
}