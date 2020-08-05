using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Moeda : MonoBehaviour
{
    private Script_Counter_Moedas counter; //Variável do contador de moedas que chama a função adequada pra somar
    private Script_Spawn_Moedas spawner; //Variável de controle do spawner

    private bool isNear = false; //Variável que verifica se o jogador entrou no trigger da moeda

    void Start()
    {
        counter = GameObject.FindObjectOfType<Script_Counter_Moedas>(); //Encontra o contador das moedas, que está em outra cena.
        Invoke("destroySelf", 5.0f); //Assim que spawnado, invoca com um delay de 5 segundos a auto-destruição
    }

    public void setSpawner(Script_Spawn_Moedas s)
    {
        spawner = s; //Função pra definir o Spawner, utilizado quando o objeto é instanciado
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
        if (collision.tag == "Player") //Se o jogador sair do trigger, desativa a variável isNear
        {
            isNear = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isNear) //Se a tecla espaço for apertada e o jogador estiver perto
        {
            counter.addMoedas(gameObject.tag); //Adiciona a moeda no contador
            destroySelf(); //Destroi o objeto
        }
    }

    public void destroySelf()
    {
        spawner.removeMoeda(this); //Remove ele mesmo da lista de moedas do spawner
        Destroy(gameObject); //Destroi o objeto
    }
}
