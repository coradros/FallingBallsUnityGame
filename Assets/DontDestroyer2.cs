using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyer2 : MonoBehaviour
{
    public static DontDestroyer2 Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // уничтожаем дубликат
        }
    }
}
