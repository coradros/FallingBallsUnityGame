using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    SessionElement SessElement;

    public bool isBarrier = false;

    bool isExit = true, isCollision = false, isActive = true;

    GameObject triggerObject;


    int x, y;
    void Start()
    {
        x = StaticClassGameTime.RoundIntPosition(transform.position.x);
        y = StaticClassGameTime.RoundIntPosition(transform.position.y); 
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isExit && !isCollision)
        {
            try
            {
                GameObject go;
                go = GameObject.Instantiate(StaticClassGameTime.GetRandomFall(SessElement.ColNumber, SessElement.FallinPrefs, SessElement.FallsColorsNumber));
                go.transform.position = new Vector2(x, y);
                isExit = false;
                isCollision = true;
            }
            catch
            {
                return;
            }
        }
    }
    


    private void OnTriggerStay2D(Collider2D collision)
    {
        isCollision = true;
        triggerObject = collision.gameObject;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isExit = true;
        isCollision = false;
    }
}
