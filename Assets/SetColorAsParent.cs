using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorAsParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color col = transform.parent.GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = col;
        if(gameObject.GetComponent<Barriers>()!=null)
            gameObject.GetComponent<Renderer>().material.color = new Color(col.r,col.g, col.b, 0);

    }
}
