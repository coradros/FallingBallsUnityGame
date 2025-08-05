using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerProcess : MonoBehaviour
{
    GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D colly)
    {
        try
        {
            GameObject go = colly.gameObject;
            if (gameObject.name == "TriggerRight")
            {
                if (go.tag == "Fall")
                    gameObject.transform.parent.gameObject.GetComponent<Fall>().rightFall = go;
                else
                    gameObject.transform.parent.gameObject.GetComponent<Fall>().rightFall = null;
            }

            if (gameObject.name == "TriggerLeft")
            {
                if (go.tag == "Fall")
                    gameObject.transform.parent.gameObject.GetComponent<Fall>().leftFall = go;
                else
                    gameObject.transform.parent.gameObject.GetComponent<Fall>().leftFall = null;
            }

        }
        catch
        {
            return;
        }
    }

}
