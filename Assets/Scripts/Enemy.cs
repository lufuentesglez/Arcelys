using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Configuración Base")]
    public float speed = 3f;           // Velocidad máxima de movimiento del enemigo.
    public float maxForce = 10f;       // Máxima fuerza de dirección (steering force) que se puede aplicar.

    protected Transform playerTransform; // Referencia al Transform del jugador (Target).
    protected Rigidbody2D rb;          // Componente de física para movimiento basado en fuerza.

    protected virtual void Start()
    {
        // 1. Inicializar Rigidbody
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError($"[ID: {gameObject.name}] Rigidbody2D es necesario para el movimiento basado en fuerza. Desactivando script.");
            enabled = false;
            return;
        }
        
        // CRÍTICO PARA 2D: Asegurarse de que la gravedad es cero y la ROTACIÓN Z está congelada.
        rb.gravityScale = 0f;
        rb.freezeRotation = true; 

        // 2. Buscar al jugador (Target)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("[IA INIT] No se encontró el objeto 'Player'. Comportamientos de persecución/huida serán ignorados.");
        }
    }

    protected virtual void Move() 
    {
        // Implementación específica de la IA (Seek, Flee, Patrol) en clases derivadas.
    }

    void FixedUpdate()
    {
        Move();
    }
}
