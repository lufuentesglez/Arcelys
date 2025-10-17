using UnityEngine;
using UnityEngine.Rendering.Universal;

    public class Projectile2D : MonoBehaviour
    {
        [Header("Movimiento")]
        public Vector2 direction = Vector2.up;
        public float speed = 5f;
        public float lifeTime = 2f;

        [Header("Wind")]
        public bool isWind = false;            // <- lo marca PlayerSpells al instanciar wind
        public string pushableTag = "Pushable";
        public float windPushForce = 1f;       // impulso aplicado al objeto empujable

        [Header("Fire")]
        public bool isFire = false;
        public string flammableTag = "Flammable";

        void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        void Update()
        {
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isWind && collision.CompareTag(pushableTag))
            {
                var rb = collision.attachedRigidbody;
                if (rb != null)
                {
                    Vector2 pushDir = ((Vector2)collision.transform.position - (Vector2)transform.position).normalized;
                    rb.AddForce(pushDir * windPushForce, ForceMode2D.Impulse);
                }
                Destroy(gameObject);
                return;
            }

            if (isFire && collision.CompareTag(flammableTag))
            {
                // Buscar Light2D en el objeto, hijos (incluso inactivos) o padres
                Light2D light2D =
                collision.GetComponent<Light2D>() ??
                collision.GetComponentInChildren<Light2D>(true) ??
                collision.GetComponentInParent<Light2D>(true);

                if (light2D != null)
                {
                    // Si el GameObject donde está la luz está desactivado, lo activamos primero
                    if (!light2D.gameObject.activeSelf)
                        light2D.gameObject.SetActive(true);

                    // Encender la luz (si prefieres alternar: light2D.enabled = !light2D.enabled;)
                    light2D.enabled = true;
                }

                Destroy(gameObject);
                return;
            }

            if (collision.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }
