using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
   

    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb2D;
    private Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Solo una animación activa a la vez
        if (direccion.y > 0)
        {
            SetAnimState(true, false, false);
        }
        else if (direccion.y < 0)
        {
            SetAnimState(false, true, false);
        }
        else if (direccion.x != 0)
        {
            SetAnimState(false, false, true);
        }
        else
        {
            SetAnimState(false, false, false); // Idle
        }

        // Flip visual si va a la izquierda o derecha
        if (direccion.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Mirar izquierda
        }
        else if (direccion.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Mirar derecha
        }
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }

    // Helper para controlar el estado del Animator
    private void SetAnimState(bool up, bool down, bool side)
    {
        animator.SetBool("IsRunningUp", up);
        animator.SetBool("IsRunningDown", down);
        animator.SetBool("IsRunningSide", side);
    }
}



