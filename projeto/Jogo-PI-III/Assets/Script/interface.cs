using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

    // Variaveis para interação com usuario
    public bool visivel = false;        // Estado atual de visibilidade da interface
    public bool disponivel = false;     // Disponibilidade para deixar visivel ou invisivel
    
    // Variaveis responsaveis pelo contador
    public float realTime = 0.0f;       // Tempo real do jogo | Zerado sempre quando chegar no tempo maximo 
    public float maxiTime = 0.1f;       // Tempo maximo que a variavel 'realTime' pode chegar

    void OnGUI() {

        // Contador
        if(realTime >= maxiTime){
            disponivel = true;
            realTime = 0.0f;
        }else if(!disponivel){
            realTime += Time.deltaTime;
        }

        //
        if (Input.GetKeyDown(KeyCode.Tab) && disponivel){
            visivel = !visivel;
            disponivel = false;
        }

        // Checa se esta visivel
        if (visivel){
            // Menu de seleção - Titulo
            GUI.Box(
                new Rect(
                    Screen.width  / 2 - 125, 
                    Screen.height / 2 - 100, 
                    250, 
                    20
                ), 
                " MENU "
            );

            // Menu de seleção - Voltar para o simulador
            GUI.Button(
                new Rect(
                    Screen.width / 2 - 125,
                    Screen.height / 2 - 75,
                    250,
                    20
                ),
                " Voltar para o simulador "
            );

            // Menu de seleção - Resetar
            GUI.Button(
                new Rect(
                    Screen.width / 2 - 125,
                    Screen.height / 2 - 50,
                    250,
                    20
                ),
                " Resetar mapa "
            );

            // Menu de seleção - Voltar para o menu principal
            GUI.Button(
                new Rect(
                    Screen.width / 2 - 125,
                    Screen.height / 2 - 25,
                    250,
                    20
                ),
                " Voltar para o menu principal "
            );
        }
    }
}