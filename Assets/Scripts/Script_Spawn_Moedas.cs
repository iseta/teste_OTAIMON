using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Spawn_Moedas : MonoBehaviour
{
    public GameObject[] moedasPrefab; //Prefab das moedas de diferentes cores
    public GameObject player; //Objeto do jogador, usado para pegar o local em que ele está e não spawnar moedas no local
    public float intervalo; //Intervalo entre spawn de moeda

    List<script_Moeda> moedas = new List<script_Moeda>(); //Lista das moedas ativas atualmetne

    void Start()
    {
        StartCoroutine(coroutineSpawn()); 
    }

    public void removeMoeda(script_Moeda s)
    {
        moedas.Remove(s); //Chamado no script de auto-destruição das moedas, remove a moeda da lista.
    }

    public void endSpawn() //Finaliza os spawns
    {
        foreach(script_Moeda s in moedas.ToArray()) 
        {
           s.destroySelf(); //Destroi todas as moedas ativas atualmente
        }
        StopAllCoroutines(); //Interrompe a coroutine de spawn
        this.enabled = false; //Desabilita o próprio script
    }

    IEnumerator coroutineSpawn()
    {
        int index = Random.Range(0, moedasPrefab.Length); //Faz um random de 0 até a quantidade de moedas que temos.
        bool spawnMoeda = false; //Variável pra verificar se o script encontrou um intervalo aceitável onde spawnar a moeda
        while (!spawnMoeda)
        {
            Vector3 moedaPos = new Vector3(Random.Range(-7.0f, 7.0f), moedasPrefab[index].transform.position.y, 0.0f); //Vector3 da posicao da moeda
            if((moedaPos - player.transform.position).magnitude < 3) //Verifica se a posição gerada em relação à posição do jogador possui uma distância adequada
            {
                continue; //Se não possuir, repete a geração dos valores.
            }
            else
            {
                GameObject go = Instantiate(moedasPrefab[index], moedaPos, Quaternion.identity); //Se sim, instancia a moeda na posição adequada.
                go.transform.parent = transform; 
                script_Moeda script = go.GetComponent<script_Moeda>(); //Pega o script da moeda e salva
                script.setSpawner(this); //Utiliza a referência para configurar a variável de spawner
                moedas.Add(script); //Adiciona essa moeda na lista
                spawnMoeda = true; //Sinaliza que foi possível spawnar uma moeda
            }
        }
        yield return new WaitForSeconds(intervalo); //Espera o intervalo e começa novamente
        StartCoroutine(coroutineSpawn());
    }
}
