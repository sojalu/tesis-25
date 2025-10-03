using UnityEngine;

public class MejoraDaño : MonoBehaviour
{
    // Multiplicador de daño
    public float damageMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el jugador entró en contacto
        if (other.CompareTag("Player"))
        {
            // Intentamos obtener el componente PlayerAttack del jugador
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                // Duplicamos el daño
                playerAttack.damage = Mathf.RoundToInt(playerAttack.damage * damageMultiplier);
                Debug.Log("Daño del jugador duplicado: " + playerAttack.damage);

                // Destruimos la mejora para que no se use de nuevo
                Destroy(gameObject);
            }
        }
    }
}
