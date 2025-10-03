using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menupausa : MonoBehaviour
{
    [SerializeField] private GameObject botonpausa;
    [SerializeField] private GameObject menuPausa;
    public void pausa()
    {
        Time.timeScale = 0f;
        botonpausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void reanudar()
    {
        Time.timeScale = 1f;
        botonpausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void reiniciar()
    {
        Time.timeScale = 1f;
        botonpausa.SetActive(true);
        menuPausa.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
