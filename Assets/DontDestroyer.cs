using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyer : MonoBehaviour
{
    public static DontDestroyer Instance;

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
