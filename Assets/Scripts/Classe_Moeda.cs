using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Classe_Moeda : MonoBehaviour
{
    public string tagMoeda;
    public Text valorMoeda;
    public int qtdMoeda = 0;
    public Sprite spriteMoeda;

    public void Start() //Inicia o texto com o valor do inspetor, caso seja necessário iniciar os valores diferentes
    {
        valorMoeda.text = "x" + qtdMoeda;
    }

    public void AddValor(int i) //Recebe um valor e adiciona ele na quantidade dessa moeda. Também atualiza o texto
    {
        qtdMoeda += i;
        valorMoeda.text = "x" + qtdMoeda;
    }
}
