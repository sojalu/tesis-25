using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int enemigosRestantes;

    void Start()
    {
        enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemigoEliminado()
    {
        enemigosRestantes--;

        if (enemigosRestantes <= 0)
        {
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
        // Reemplaza "NombreDeLaSiguienteEscena" con el nombre real de tu escena
        SceneManager.LoadScene(5);
    }
}
