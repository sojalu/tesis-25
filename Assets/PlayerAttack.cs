using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackArea;
    public float attackDuration = 0.2f;
    public int damage = 10; // daño base del jugador


    private bool isAttacking = false;
    private bool attackEnabled = false; // Empieza deshabilitado
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Cambia el estado de habilitación al presionar 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            attackEnabled = !attackEnabled;
            Debug.Log("Ataque con Q habilitado: " + attackEnabled);
        }

        // Solo permite atacar si está habilitado y no está ya atacando
        if (attackEnabled && Input.GetKeyDown(KeyCode.Q) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private System.Collections.IEnumerator Attack()
    {
        isAttacking = true;

        if (attackArea != null) attackArea.SetActive(true);
        if (animator != null) animator.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(attackDuration);

        if (attackArea != null) attackArea.SetActive(false);
        if (animator != null) animator.SetBool("IsAttacking", false);

        isAttacking = false;
    }
}
