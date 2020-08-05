using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_NPC : MonoBehaviour
{
    private bool isNear; //Variável que verifica se o jogador entrou no trigger do NPC
    private GameObject painelLoja; //Variável que recebe o painel da loja, que está em outra cena

    private void Start()
    {
        painelLoja = GameObject.Find("container_Painel_Loja").transform.GetChild(0).gameObject; //Eu não tenho muita experiência em trabalhar com duas cenas separadas, então essa foi a forma que encontrei de deixar o painel
                                                                                                //Desativado e ainda assim obter a referência dele.
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") //Se o jogador entrou no trigger, ativa a variável isNear
        {
            isNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") //Se o jogador saiu do trigger, desativa a variável isNear e o painel
        {
            painelLoja.SetActive(false);
            isNear = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&&(isNear)) //Se o jogador estiver apertando a tecla F e estiver perto, ativa o painel e pára o tempo para interromper as coroutines de spawn e movimento.
            {
                painelLoja.SetActive(!painelLoja.activeSelf);
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
         }
    }
}

