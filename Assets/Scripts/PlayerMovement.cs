using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; 

    private Rigidbody2D myRigidbody;
    private Vector2 movementInput;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Usado para capturar el input (no afecta la física).
    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput.Normalize(); 
    }

    // Usado para aplicar la física (movimiento).
    void FixedUpdate()
    {
        // Aplicamos la velocidad directamente.
        myRigidbody.linearVelocity = movementInput * speed;
    }
}
