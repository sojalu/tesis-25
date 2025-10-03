using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;  // Daño que hace el enemigo (1 vida)

    // Esto se ejecuta cuando el collider del enemigo colisiona físicamente con el del jugador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el objeto con el que colisionó es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Buscamos el LifeManager en la escena
            PlayerLivesUI lifeManager = FindObjectOfType<PlayerLivesUI>();

            if (lifeManager != null)
            {
                lifeManager.LoseLife();  // Le sacamos una vida al jugador
            }
            else
            {
                Debug.LogWarning("No se encontró el LifeManager con PlayerLivesUI en la escena");
            }
        }
    }
}
