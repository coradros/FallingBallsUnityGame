using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTrigger : MonoBehaviour
{
    SessionElement SessElement;

    int x, y;

    public bool islabirinth = false;

    // Start is called before the first frame update
    void Start()
    {
        x = StaticClassGameTime.RoundIntPosition(transform.position.x);
        y = StaticClassGameTime.RoundIntPosition(transform.position.y);
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!CheckFall(x, y))
        {
            try
            {
                GameObject go;
                go = GameObject.Instantiate(StaticClassGameTime.GetRandomFall(0, SessElement.FallinPrefs, SessElement.FallsColorsNumber));
                go.transform.position = new Vector2(x, y);
            }
            catch
            {
                return;
            }
        }
    }


    bool CheckFall(int x, int y)
    {
        if (y < -7&&!islabirinth)
        {
            return true;
        }
        GameObject go = StaticClassGameTime.FindFall2BarrbyIJ(x, -y);
        if (go != null) return true;
        else return false;
    }

}
