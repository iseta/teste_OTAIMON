using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Item: MonoBehaviour
{
    public Text txt_Nome, txt_Preco; //Variaveis publicas referenciadas no inspetor que guardam os textos
    public Image img_Item, img_Moeda; //Variaveis publicas referenciadas no inspetor que guardam as imagens
    public Button button; //Guarda o botão que será habilitado ou desabilitado
    public GameObject prefabInventario; //Prefab do inventário que fica no canto superior esquerdo da tela
    public Classe_Moeda moeda; //Moeda que será adicionada ou subtraída

    Script_Gerador_Loja parentScript;
    Item self;

    public void setupItem(Item i) //Atribui os valores de acordo
    {
        self = i;
        moeda = i.moeda;
        txt_Nome.text = i.nome;
        txt_Preco.text = "x"+i.preco;
        img_Item.sprite = i.imagemItem;
        img_Moeda.sprite = moeda.spriteMoeda;
        button.onClick.AddListener(compraMoeda);
    }

    public void instantiateInventario() //Quando comprado com sucesso, adiciona ao inventário instanciando o painel
    {
        GameObject parentInventario = GameObject.Find("painel_Itens_Jogador");
        GameObject currInventario = Instantiate(prefabInventario, parentInventario.transform);
        currInventario.GetComponent<Script_Painel_Inventario>().setSpriteItem(self.imagemItem);
    }

    public void compraMoeda() //Verifica se existe moeda suficiente pra compra
    {
        if (moeda.qtdMoeda >= self.preco)
        {
            moeda.AddValor(-self.preco);
            instantiateInventario();
            button.interactable = false;
            parentScript.removeFromList(self, this.gameObject);
        }
    }
    
    public void setParentScript(Script_Gerador_Loja p)
    {
        parentScript = p;
    }
}