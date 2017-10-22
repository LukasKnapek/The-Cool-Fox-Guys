using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public static bool helpText;

     private void Start()
    {
        if (!helpText)
        {
            Destroy(gameObject, 5f); // Destroy this gameobject after a t time.
            helpText = true;
        } else
        {
            Destroy(gameObject);
        }
    }
}
