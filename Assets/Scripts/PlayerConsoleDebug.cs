/* using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float moveSmoothing = 0.1f; // Suavizado del movimiento
    private Rigidbody2D myRigidbody;
    private Vector2 change;
    private Animator animator;
    private Vector2 lastPosition;

    void Start()
    {
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        if (myRigidbody == null)
        {
            myRigidbody = gameObject.AddComponent<Rigidbody2D>();
            myRigidbody.bodyType = RigidbodyType2D.Dynamic;
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            myRigidbody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            myRigidbody.interpolation = RigidbodyInterpolation2D.None;
            Debug.LogWarning("⚠️ Rigidbody2D añadido automáticamente.");
        }

        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
            Debug.LogWarning("⚠️ BoxCollider2D añadido automáticamente.");
        }

        if (animator)
        {
            animator.applyRootMotion = false;
            animator.updateMode = AnimatorUpdateMode.Normal;
            Debug.Log($"🎮 Animator - Update Mode: {animator.updateMode}, ApplyRootMotion: {animator.applyRootMotion}");
        }

        Transform spriteChild = transform.Find("Sprite");
        if (spriteChild == null || spriteChild.GetComponent<SpriteRenderer>() == null)
        {
            Debug.LogWarning("⚠️ Crea un GameObject hijo 'Sprite' y mueve el SpriteRenderer allí.");
        }

        lastPosition = myRigidbody.position;
        Debug.Log($"🚀 PlayerMovement iniciado. Posición inicial: {transform.position}, Rigidbody Pos: {myRigidbody.position}");
    }

    void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change != Vector2.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        Debug.Log($"📊 Update - Input: ({change.x}, {change.y}), Transform Pos: {transform.position}, Rigidbody Pos: {myRigidbody.position}");
    }

    void FixedUpdate()
    {
        if (change != Vector2.zero)
        {
            Vector2 movement = change.normalized * speed * Time.fixedDeltaTime;
            movement = Vector2.ClampMagnitude(movement, 0.15f); // Límite estricto por FixedUpdate
            Vector2 targetPosition = myRigidbody.position + movement;
            Vector2 smoothedPosition = Vector2.Lerp(myRigidbody.position, targetPosition, 1f - moveSmoothing);
            myRigidbody.MovePosition(smoothedPosition);

            float distance = Vector2.Distance(myRigidbody.position, lastPosition);
            if (distance > 0.3f)
            {
                Debug.LogError($"🚨 TELETRANSPORTE DETECTADO EN FIXEDUPDATE! Distancia: {distance:F3} unidades, Desde: {lastPosition} Hasta: {myRigidbody.position}, Target: {targetPosition}, Smoothed: {smoothedPosition}, Time.fixedDeltaTime: {Time.fixedDeltaTime:F4}s, FPS approx: {1f / Time.deltaTime:F1}");
            }

            lastPosition = myRigidbody.position;
            Debug.Log($"🔧 FixedUpdate - Movement: {movement}, Target: {targetPosition}, Smoothed: {smoothedPosition}, Actual: {myRigidbody.position}");
        }
    }

    void LateUpdate()
    {
        Vector2 currentRbPos = myRigidbody.position;
        Vector2 currentTransformPos = transform.position;
        if (Vector2.Distance(currentTransformPos, currentRbPos) > 0.01f)
        {
            transform.position = new Vector3(currentRbPos.x, currentRbPos.y, transform.position.z);
            Debug.LogWarning($"🔄 Sync LateUpdate - Old Transform: {currentTransformPos}, New Transform: {transform.position}, Rigidbody: {currentRbPos}");
        }
    }
}
*/
