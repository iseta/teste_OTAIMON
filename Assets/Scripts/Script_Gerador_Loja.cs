using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class Item //Classe para facilitar a elaboração da lista de itens
{
    public string nome;
    public Sprite imagemItem;
    public int preco;
    public Classe_Moeda moeda;
}

public class Script_Gerador_Loja : MonoBehaviour
{
    public List<Item> itens; //Lista de todos os itens, criado no inspetor
    public GameObject prefabItem; //Prefab do item, atribuido no inspetor
    int qtdItens; //Quantidade de itens, definido aleatoriamente de 3 a 5 itens

    List<Item> instanciaItens = new List<Item>(); //Lista dos itens instanciados
    List<GameObject> objItens = new List<GameObject>(); //GameObjects dos itens instanciados
    Script_Spawn_Moedas spawner; //Spawner para controlar quando compramos todos os itens da loja

    private void Start()
    {
        spawner = GameObject.FindObjectOfType<Script_Spawn_Moedas>(); //Encontra o spawner, que está em outra cena
        qtdItens = Random.Range(3, 6); //Define quantos itens teremos
        int aux = 0;

        for(int i = 0; i < qtdItens; i++) //Adiciona itens na lista de itens a serem instanciados de acordo com a quantidade de itens
        {
            aux = Random.Range(0, itens.Count);
            instanciaItens.Add(itens[aux]);
            itens.RemoveAt(aux); //No entanto, para não termos itens repetidos, removemos da lista original os que já foram selecionados.
        }

        foreach(Item i in instanciaItens) //Para cada item na lista, instancia o prefab e configura de acordo com as configurações dele no inspetor
        {
            GameObject goItem = Instantiate(prefabItem, transform);
            Script_Item thisScript = goItem.GetComponent<Script_Item>();
            thisScript.setupItem(i);
            thisScript.setParentScript(this);
            objItens.Add(goItem); //Adiciona o item na lista de GameObjects;
        }
        updateSelectedItem();
    }

    public void OnEnable() //Executa quando o objeto for ativado ou desativado
    {
        if (objItens.Count > 0) //Verifica se a lista de objetos está preenchida.
        {
            updateSelectedItem();
        }
    }

    public void updateSelectedItem()  //Configura o item selecionado atualmente como o primeiro da lista
    {
        objItens[0].GetComponent<Button>().OnSelect(null);
        EventSystem.current.SetSelectedGameObject(objItens[0]);
    }

    public void removeFromList(Item i, GameObject obj)
    {
        instanciaItens.Remove(i);
        objItens.Remove(obj);
        if(objItens.Count == 0)
        {
            spawner.endSpawn();
            spawner.StopAllCoroutines();
            return;
        }
        updateSelectedItem();
    }
}
