using UnityEngine;

public class MeleeChaser : Enemy
{
    [Header("Comportamiento Chaser")]
    public float stoppingDistance = 1.0f; // Distancia para detenerse y considerar la posición de ataque en un futuro.
    public float slowdownRadius = 3.0f;   // Distancia a la que empieza a reducir la velocidad para un frenado suave.

    protected override void Start()
    {
        base.Start();
    }

    protected override void Move()
    {
        if (playerTransform == null || rb == null) return;

        Vector2 targetPosition = playerTransform.position;
        Vector2 currentPosition = rb.position;
        Vector2 desiredVelocity;
        
        float distanceToPlayer = Vector2.Distance(currentPosition, targetPosition);

        // Si estamos dentro de la distancia de detención, nos detenemos inmediatamente.
        if (distanceToPlayer <= stoppingDistance)
        {
            rb.linearVelocity = Vector2.zero; 
            return;
        }

        // 1. Calcular la dirección normalizada hacia el jugador.
        Vector2 direction = (targetPosition - currentPosition).normalized;
        
        // Aplicamos el comportamiento de Llegada (Arrival) para un frenado natural.
        if (distanceToPlayer < slowdownRadius)
        {
            // Escalar la velocidad en función de la distancia al objetivo.
            float desiredSpeed = speed * (distanceToPlayer / slowdownRadius);
            desiredVelocity = direction * desiredSpeed;
        }
        else
        {
            // Si está lejos, la velocidad deseada es la velocidad máxima.
            desiredVelocity = direction * speed;
        }

        // 2. Calcular la fuerza de dirección (Steering Force)
        Vector2 steeringForce = desiredVelocity - rb.linearVelocity;
        
        // Limitar la fuerza máxima.
        steeringForce = Vector2.ClampMagnitude(steeringForce, maxForce);

        // 3. Aplicar la fuerza al Rigidbody.
        rb.AddForce(steeringForce);
    }
}
