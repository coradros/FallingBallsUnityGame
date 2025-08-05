using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroybyTime : MonoBehaviour
{
    float live = 1f, count=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count > live) GameObject.Destroy(gameObject);
    }
}
