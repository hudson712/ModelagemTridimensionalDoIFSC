using UnityEngine;
using System.Collections;

/**************************************
 * REQUERIMENTOS PARA O USO DO SCRIPT *
 **************************************
 * 1 - Um collider em modo Trigger com a TAG "PontoDePartida" possicionado na porta que o jogador terá que passar para ativar o contador.
 * 2 - Um collider em modo Trigger com a TAG "PontoDeChegada" possicionado na saida que o jogador terá que passar para marcar o tempo contado.
 */

public class Contador : MonoBehaviour {

    // Variaveis necessarias para o contador
    private bool contadorVisivel;
    private float tempoFugindo;

    // Objetos pertencentes ao contador
    private GameObject PontoDeChegada;
    private GameObject PontoDePartida;

    // Metodo chamado apenas no inicio do cenario
    void Start(){
        contadorVisivel = false;
        tempoFugindo = 0.0f;

        // Capturando os componentes dos objetos com a tag "PontoDePartida" e "PontoDeChegada"
        PontoDePartida = GameObject.FindWithTag("PontoDePartida");
        PontoDeChegada = GameObject.FindWithTag("PontoDeChegada");

    }

    // Metodo chamado a cada frame
    void Update () {
        contador();
    }

    // Metodo contador - Responsavel por mostrar par o jogador o quanto de tempo foi necessario para sair do predio
    void contador(){

        // Apos o player passar pela porta o gatilho ativa e o contador inicia junto
        if (PontoDePartida.GetComponent<CapturarChegadaAoObjetivo>().gatilho && !PontoDeChegada.GetComponent<CapturarChegadaAoObjetivo>().gatilho) {
            contadorVisivel = true;
            tempoFugindo += Time.deltaTime;
        }

        // Apos o player passar pela porta o gatilho ativa e o contador inicia junto
        if (PontoDeChegada.GetComponent<CapturarChegadaAoObjetivo>().gatilho) {

        }
    }

    // Metodo responsavel pela interface (HUB) do simulador
    void OnGUI(){

        // Interface do metodo contador - Onde sera mostrado o tempo para o usuario
        if (contadorVisivel) {
            GUI.Box(new Rect(10,10,175,25), "Tempo: "+tempoFugindo+" Seg");
        }

    }
}