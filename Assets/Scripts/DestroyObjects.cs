using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    bool textDestroyed;

     private void Start()
    {
        if (!textDestroyed)
        {
            Destroy(gameObject, 5f); // Destroy this gameobject after a t time.
            textDestroyed = true;
        }
    }
}
