using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFairy : MonoBehaviour    
{
    [Header("General")]
    [SerializeField] bool fairyActive = true;       // 🔘 Activa o desactiva el hada
    [SerializeField] bool hideWhenInactive = true;  // 🔘 Si está desactivada, se oculta el sprite

    [Header("Target")]
    [SerializeField] Transform target;              // Player a seguir

    [Header("Offsets")]
    [SerializeField] Vector2 offset = new Vector2(1f, 0.5f); // distancia al jugador (x=lado, y=altura)

    [Header("Movimiento")]
    [SerializeField] float smoothTime = 0.15f;      // suavizado del seguimiento
    [SerializeField] float bobAmplitude = 0.1f;     // qué tanto flota
    [SerializeField] float bobFrequency = 3f;       // qué tan rápido flota

    Vector3 velocity;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        // Si no se asigna manualmente, busca un objeto con tag "Player"
        if (target == null)
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p) target = p.transform;
        }

        // Busca el SpriteRenderer en este objeto o en sus hijos
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        UpdateActiveState();
}

    void LateUpdate()
    {
        if (!fairyActive || !target) return;

        // Posición base con offset
        Vector3 desired = target.position + (Vector3)offset;

        // Movimiento de flotación vertical
        desired.y += Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;

        // Movimiento suave hacia el objetivo
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothTime);
    }

    // Llama esto desde otro script para activar o desactivar el hada
    public void SetFairyActive(bool active)
    {
        fairyActive = active;
        UpdateActiveState();
    }

    void UpdateActiveState()
    {
    if (hideWhenInactive)
        gameObject.SetActive(fairyActive);
    else if (spriteRenderer != null)
        spriteRenderer.enabled = fairyActive;
    }

    // Dibuja una línea en el editor para ver la conexión con el player
    void OnDrawGizmosSelected()
    {
        if (!target) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, target.position);
        Gizmos.DrawSphere(transform.position, 0.05f);
    }
}