using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonProcess : MonoBehaviour
{
    public GameObject PolygonPrefab;
    GameObject ppf;
    public bool isClick;
    Vector3 StartPosition;
    public bool isRunning = false;

    SessionElement SessElement;

    // Start is called before the first frame update
    void Start()
    {
        isClick = false;
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();

    }


    private void OnMouseUp()
    {
        isRunning = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            gameObject.transform.localScale = new Vector2(2, 2);
            if (Input.GetMouseButtonDown(0))
            {
                if (!isClick)
                {
                    ppf = GameObject.Instantiate(PolygonPrefab);

                    ppf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    ppf.transform.position = new Vector3(ppf.transform.position.x, ppf.transform.position.y);
                    StartPosition = ppf.transform.position;
                    isClick = true;
                }
            }


            if (Input.GetMouseButtonUp(0))
            {
                isClick = false;
            }

            if (isClick)
            {
                Vector3 currenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currenPosition = new Vector3(currenPosition.x, currenPosition.y);
                Vector3 scale = StartPosition - currenPosition;
                if (scale.x > 5) scale = new Vector2(5, scale.y);
                if (scale.y > 3) scale = new Vector2(scale.x, 3);
                //if (scale.y > 4 && scale.x > 5) scale = new Vector2(5, 4);
                ppf.transform.position = (StartPosition + currenPosition) / 2;
                ppf.transform.localScale = scale;

            }
        }
        else
            gameObject.transform.localScale = new Vector2(1, 1);

    }
}
