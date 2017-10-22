using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public bool destroyOnStart = false;

     private void Start()
    {
        if (destroyOnStart)
            Destroy(gameObject, 5f); // Destroy this gameobject after a t time.
    }

    // Destroy this gameobject after a t time.
    void DestroyObject(float time)
    {
        Destroy(gameObject, time);
    }
}
