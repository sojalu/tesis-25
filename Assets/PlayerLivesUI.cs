using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLivesUI : MonoBehaviour
{
    public int maxLives = 3;           // Máximo de vidas
    public int currentLives;           // Vidas actuales
    public Image[] hearts;             // Array con las imágenes de los corazones

    void Start()
    {
        currentLives = maxLives;
        UpdateHeartsUI();
    }

    // 🔻 Método para perder una vida
    public void LoseLife()
    {
        currentLives--;
        UpdateHeartsUI();

        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            Die();
        }
    }

    // 🔺 Método NUEVO para ganar vida
    public void GainLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateHeartsUI();
            Debug.Log("Vida extra: " + currentLives);
        }
        else
        {
            Debug.Log("¡Ya tienes todas las vidas!");
        }
    }

    // 🔹 Actualiza los corazones en la UI
    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < currentLives);
        }
    }

    void Die()
    {
        Debug.Log("¡Sin vidas! Cambio a GameOver");
        StartCoroutine(GoToGameOverAfterDelay(0.5f));
    }

    IEnumerator GoToGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }
    
}
