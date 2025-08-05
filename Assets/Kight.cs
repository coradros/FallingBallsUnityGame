using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kight : MonoBehaviour
{
    public List<GameObject> FullLevelList;
    SessionElement SessElement;

    public GameObject yellow;
    public GameObject green;
    public GameObject blue;
    public GameObject red;

    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        FullLevelList = SessElement.gameObject.GetComponent<Saver>().FullLevelList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        FullLevelList = SessElement.gameObject.GetComponent<Saver>().FullLevelList;

        GameObject go = Saver.JumpObject(gameObject, FullLevelList);
        if (go.GetComponent<Fall>() != null) TwoObjectsExchange(go, gameObject);
    }

    public void TwoObjectsExchange(GameObject g1, GameObject g2)
    {
        Vector2 vec1 = g1.transform.position;
        Vector2 vec2 = g2.transform.position;
        g1.transform.position = new Vector2(500, 500);
        g2.transform.position = vec1;
        g1.transform.position = vec2;
    }

    public void YellowKey()
    {
        yellow.GetComponent<Renderer>().enabled = true;
    }
    public void GreenKey()
    {
        green.GetComponent<Renderer>().enabled = true;
    }
    public void BlueKey()
    {
        blue.GetComponent<Renderer>().enabled = true;
    }
    public void RedKey()
    {
        red.GetComponent<Renderer>().enabled = true;
    }
}
