using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    // Start is called before the first frame update

    public int delay = 20;

    int counter = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == delay) GameObject.Destroy(gameObject);
        counter++;
    }
}
