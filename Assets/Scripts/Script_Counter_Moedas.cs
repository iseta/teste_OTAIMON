using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Script_Counter_Moedas : MonoBehaviour
{
    public List<Classe_Moeda> moedas = new List<Classe_Moeda>();

    public void addMoedas(string s) //Função que recebe a tag da moeda coletada e compara com a tag das moedas que já temos.
    {
        foreach(Classe_Moeda moeda in moedas)
        {
            if (s == moeda.tagMoeda)
            {
                moeda.AddValor(1);
            }
        }
        
    }

}
