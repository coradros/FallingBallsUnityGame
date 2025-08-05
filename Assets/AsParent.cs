using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsParent : MonoBehaviour
{
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().enabled = parent.GetComponent<Renderer>().enabled;
    }
}
