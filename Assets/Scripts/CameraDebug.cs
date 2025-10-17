/*using UnityEngine;
using System.Linq;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    
    private Vector3 ultimaPosicionJugador;
    private int teletransportesDetectados = 0;
    private float mayorTeletransporte = 0f;
    private float lastFrameTime;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("❌ Cámara: No hay objetivo asignado!");
            return;
        }
        
        ultimaPosicionJugador = target.position;
        lastFrameTime = Time.time;
        Debug.Log($"📷 Cámara de seguimiento activada - Monitorizando teletransportes. Target: {GetHierarchyPath(target)}");
        Debug.Log($"⏳ Time.timeScale: {Time.timeScale}");
    }

    void LateUpdate()
    {
        if (target == null) return;
        
        // Calcular FPS
        float currentFrameTime = Time.time;
        float deltaTime = currentFrameTime - lastFrameTime;
        float fps = deltaTime > 0 ? 1f / deltaTime : 0;
        lastFrameTime = currentFrameTime;

        Vector3 posicionActualJugador = target.position;
        
	float distanciaRecorrida = Vector3.Distance(ultimaPosicionJugador, posicionActualJugador);
        
        if (distanciaRecorrida > 0.3f) // Umbral para teletransportes
        {
            teletransportesDetectados++;
            mayorTeletransporte = Mathf.Max(mayorTeletransporte, distanciaRecorrida);
            
            Debug.LogError($"🚨 TELETRANSPORTE #{teletransportesDetectados} DETECTADO (CÁMARA)");
            Debug.LogError($"📏 Distancia: {distanciaRecorrida:F3} unidades");
            Debug.LogError($"📍 Desde: {ultimaPosicionJugador}");
            Debug.LogError($"📍 Hasta: {posicionActualJugador}");
            Debug.LogError($"⏰ Tiempo: {Time.time:F2}s, DeltaTime: {Time.deltaTime:F4}s, FPS: {fps:F1}");
            Debug.LogError($"🧭 Dirección: ({(posicionActualJugador - ultimaPosicionJugador).x:F2}, {(posicionActualJugador - ultimaPosicionJugador).y:F2})");
            Debug.LogError($"🎮 Animator State: {(target.GetComponent<Animator>()?.GetCurrentAnimatorStateInfo(0).fullPathHash ?? 0)}");
            Debug.LogError($"🛠️ Componentes activos: {string.Join(", ", target.GetComponents<MonoBehaviour>().Select(c => c.GetType().Name))}");
            Debug.LogError($"📋 Jerarquía: {GetHierarchyPath(target)}");
            Debug.LogError($"⏳ Time.timeScale: {Time.timeScale}");
            
            if (teletransportesDetectados >= 3)
            {
                Debug.LogError($"📊 RESUMEN: {teletransportesDetectados} teletransportes, Mayor: {mayorTeletransporte:F3}u");
            }
        }
        else if (distanciaRecorrida > 0.1f)
        {
            Debug.LogWarning($"⚠️ Movimiento grande: {distanciaRecorrida:F3} unidades, FPS: {fps:F1}");
        }
        
        // 🎥 MOVIMIENTO SUAVE DE CÁMARA
        if (Vector3.Distance(transform.position, target.position) > 0.01f)
        {
            Vector3 posicionObjetivo = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, smoothing);
            Debug.Log($"🎥 Cámara movida a: {transform.position}, Smoothing: {smoothing}, FPS: {fps:F1}");
        }
        
        ultimaPosicionJugador = posicionActualJugador;
    }

    private string GetHierarchyPath(Transform obj)
    {
        string path = obj.name;
        Transform parent = obj.parent;
        while (parent != null)
        {
            path = $"{parent.name}/{path}";
            parent = parent.parent;
        }
        return path;
    }
}
*/
