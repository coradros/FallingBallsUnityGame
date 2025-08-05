using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject barr_trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchOn()
    {
        BarrierTrigger bt = barr_trigger.GetComponent<BarrierTrigger>();
        if (bt != null)
        {
            bt.enabled = true;
            bt.islabirinth = true;
        }
    }
    public void SwitchOff()
    {
        BarrierTrigger bt = barr_trigger.GetComponent<BarrierTrigger>();
        if (bt != null) bt.enabled = false;
    }
}
