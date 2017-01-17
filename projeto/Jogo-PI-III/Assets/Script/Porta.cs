using UnityEngine;
using System.Collections;

/*********************************************************************
 * Script responsavel por abrir e fechar portas ou mantelas fechadas *
 *********************************************************************
 * O script não foi feito para ser colocado diretamente na porta, e  *
 * sim em uma dobradiça de porta do lado oposto que a porta ira abrir*
 * detalhe, a porta por obrigação precisa ser um objeto pertecente a *
 * dobradiça da porta.                                               *
 * *******************************************************************/

public class Porta : MonoBehaviour {

    // Variaveis e objetos
    private GameObject player;
    public float distancia;

    private bool MovimentarPorta;
    private bool EstaAberta;
    public float VelocidadeDeGiro = 60;

    private float RotacaoFechada, RotacaoAberta;
    private GameObject Jogador;

    public bool portaTravada;

    // Metodo update chamado a cada frame
    void Update () {

        // Capturando distancia entre o player e a porta
        player = GameObject.FindWithTag ("Player");
	    distancia = Vector3.Distance (player.transform.position, this.gameObject.transform.position);

        // Abrindo porta
        if (Input.GetKeyDown("e") && distancia <= 4.5f && !portaTravada){
            MovimentarPorta = true;
            EstaAberta = !EstaAberta;
        }
	}

    // Mostra informações para jogador
    void OnGUI(){
        if (distancia <= 2.5f) {
            if (!portaTravada){
                GUI.Box(new Rect((Screen.width / 2) - 250, (Screen.height * 0.90f) - 25, 500, 25), "Aperte [ E ] para abrir a porta");
            }else{
                GUI.Box(new Rect((Screen.width / 2) - 250, (Screen.height * 0.90f) - 25, 500, 25), "Porta enterrada");
            }
            
        }
    }

    void Start() {
        EstaAberta = false;
        RotacaoFechada = transform.eulerAngles.y;
        RotacaoAberta = transform.eulerAngles.y + 90;
        if (RotacaoAberta > 360)
        {
            RotacaoAberta = transform.eulerAngles.y + 90 - 360;
        }
    }


    void FixedUpdate()
    {
        // MOVIMENTO DE ABRIR A PORTA
        if (MovimentarPorta == true && EstaAberta == false)
        {
            Vector3 rotacaoFinal = new Vector3(0, RotacaoAberta, 0);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotacaoFinal, Time.deltaTime * (VelocidadeDeGiro / 50));
        }

        // MOVIMENTO DE FECHAR A PORTA
        else if (MovimentarPorta == true && EstaAberta == true)
        {
            Vector3 rotacaoFinal = new Vector3(0, RotacaoFechada, 0);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotacaoFinal, Time.deltaTime * (VelocidadeDeGiro / 50));
        }
    }
}