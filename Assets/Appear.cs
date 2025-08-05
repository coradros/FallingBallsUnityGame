using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    SessionElement SessElement;
    // Start is called before the first frame update
    void Start()
    {
        SessElement=GameObject.Find("SessionElement").GetComponent<SessionElement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        //StaticClassGameTime.FillEmpty(SessElement.SessionFallMatrix, SessElement.FallinPrefs, SessElement.FallsColorsNumber);
    }
}
