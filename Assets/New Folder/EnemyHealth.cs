using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemigo golpeado. Vida restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Avisar al LevelManager
        FindObjectOfType<LevelManager>().EnemigoEliminado();

        // Destruir al enemigo
        Destroy(gameObject);
    }
}
