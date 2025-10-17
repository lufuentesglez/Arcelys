using UnityEngine;

public class CollisionDebug : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning($"COLLISION ENTER with: {collision.gameObject.name}");
        Debug.LogWarning($"Relative velocity: {collision.relativeVelocity}");
        Debug.LogWarning($"Contact points: {collision.contactCount}");
        
        // Mostrar posición exacta del contacto
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.LogWarning($"Contact point: {contact.point}");
        }
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log($"Collision STAY with: {collision.gameObject.name}");
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"Collision EXIT with: {collision.gameObject.name}");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning($"TRIGGER ENTER with: {other.gameObject.name}");
        Debug.LogWarning($"Trigger position: {other.transform.position}");
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Trigger EXIT with: {other.gameObject.name}");
    }
}
