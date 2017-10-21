using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public Dictionary<string, List<string>> ControlBindings;

    void Awake()
    {
        if (GM == null)
            GM = this;
        else if (GM != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        ControlBindings = new Dictionary<string, List<string>>
        {
            {"Button1", new List<string>() {"Door1", "Door2"} }
        };
    }
}
