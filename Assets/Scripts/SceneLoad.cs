using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false; //Desativa o cursor
        SceneManager.LoadScene(1, LoadSceneMode.Additive); //Carrega a cena do menu como aditiva
    }
}
