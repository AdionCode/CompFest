using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private static CurseSystem instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Curse System in the scene");
        }
        instance = this;
    }

    public static CurseSystem GetInstance()
    {
        return instance;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
