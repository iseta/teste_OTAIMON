using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Painel_Inventario : MonoBehaviour //Script que define a imagem do inventário no canto superior direito da tela
{
    public Image imgItem;

    public void setSpriteItem(Sprite s)
    {
        imgItem.sprite = s;
    }
}
