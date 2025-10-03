using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuinicial : MonoBehaviour
{

    public void Jugar()
    {

        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();

    }

    public void Opciones()
    {

        SceneManager.LoadScene(4);
    }
    public void Menu()
    {

        SceneManager.LoadScene(0);
    }

}