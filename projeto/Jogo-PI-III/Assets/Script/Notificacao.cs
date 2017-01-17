using UnityEngine;
using System.Collections;

public class Notificacao : MonoBehaviour {

    // Variaveis necessarias para o contador
    public float realTime;
    public float tempAtual;
    public float maxTime;

    // Variavel contador para a identificação a messagem visivel
    public int contador;

    // Variaveis para testar visibilidade das informações da tela 
    public bool visivel_msm_1;
    public bool visivel_msm_2;

    // Varivel Trigger
    public bool gatilhoDestino;

    void Start(){
        realTime       = 0.0f;
        tempAtual      = 0.0f;
        maxTime        = 3.0f;
        contador       = 0;
        visivel_msm_1  = false;
        visivel_msm_2  = false;
        gatilhoDestino = false;
    }

    // Chamado a cada clock do processador
    void Update()
    {

        // Contador
        realTime += Time.deltaTime;
        if (gatilhoDestino) { tempAtual += Time.deltaTime; }

        // Verifica quando o contador chega em seu tempo limite
        if (realTime >= maxTime)
        {
            realTime = 0;
            if (contador == 1 || contador == 2)
            {
                visivel_msm_1 = true;
                visivel_msm_2 = false;
            }

            if (contador == 3)
            {
                visivel_msm_1 = false;
                visivel_msm_2 = false;
            }
            contador++;
        }

        // Capturando se usuario chegou até seu destino
        GameObject destino = GameObject.FindWithTag("Objetivo");
        gatilhoDestino = destino.GetComponent<CapturarChegadaAoObjetivo>().gatilho;

        if (gatilhoDestino){
            visivel_msm_1 = false;
            visivel_msm_2 = true;
        }

        if(tempAtual >= maxTime && gatilhoDestino){
            proximoMapa();
        }
    }

    // Configuração da interface do Unity
    void OnGUI(){
        
        if (visivel_msm_1){
            GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 20), "Novo objetivo");
            GUI.Box(new Rect(Screen.width / 2 - 150, 40, 300, 20), "Vá até a sua sala - A201");
        }

        if (visivel_msm_2){
            GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 20), "Objetivo concluido");
            GUI.Box(new Rect(Screen.width / 2 - 150, 40, 300, 20), "Vá até a sua sala - A201");
        }
    }

    void proximoMapa(){
        // Chama a proxima cena randomicamente
        //int numero = Random.Range(1,5);
        //Application.LoadLevel("IFSC_"+numero);
    }
}