using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;
    private bool isPlayerInRange = false;

    private Animator animator;  // referencia al animator
    private Transform enemy;    // referencia al objeto enemigo (padre)

    void Start()
    {
        // Obtenemos al enemigo (padre del DetectionRange)
        enemy = transform.parent;

        // Obtenemos el Animator del enemigo
        animator = enemy.GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayerInRange && player != null)
        {
            // Calculamos la dirección hacia el jugador
            Vector2 direction = (player.position - enemy.position).normalized;

            // Movemos al enemigo principal
            enemy.position += (Vector3)(direction * speed * Time.deltaTime);

            // Activamos el bool "Movimiento" si hay dirección distinta de cero
            if (animator != null)
                animator.SetBool("Movimiento", direction.magnitude > 0.01f);
        }
        else
        {
            // Si no hay jugador en rango, desactivamos "Movimiento"
            if (animator != null)
                animator.SetBool("Movimiento", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            player = null;

            // Cuando el jugador sale del rango, dejamos de movernos
            if (animator != null)
                animator.SetBool("Movimiento", false);
        }
    }
}



