using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlusMinus : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    public bool isPlus = true;
    SessionElement SessElement;
    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlus) TextMeshPro.text = "+";
        else TextMeshPro.text = "-";
    }

    private void OnMouseUp()
    {
        if (isPlus) SessElement.Repeater++;
        else SessElement.Repeater--;
        if (SessElement.Repeater < 1) SessElement.Repeater = 1;
    }
}
