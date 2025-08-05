using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{

    public GameObject PolygonPrefab_mb;
    public GameObject PolygonPrefab_ms;
    public GameObject PolygonPrefab_row;
    public GameObject PolygonPrefab_column;

    SessionElement SessElement;

    GameObject ppf;

    Vector3 StartPosition;

    public bool isClick;
    public int Magic_Type;

    public int NumberOfUsing;


    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();

        isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (NumberOfUsing > 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (isClick)
                {
                    if (ppf != null) GameObject.Destroy(ppf);
                    Vector3 currenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    int obx = StaticClassGameTime.RoundIntPosition(currenPosition.x);
                    int oby = StaticClassGameTime.RoundIntPosition(currenPosition.y);
                    if (Magic_Type == 0)
                    {
                        if (obx > 1 && obx < SessElement.SessionFallMatrix.GetLength(1) - 2 && -oby > 1 && -oby < SessElement.SessionFallMatrix.GetLength(0) - 1.5)
                        {
                            StaticClassGameTime.MagicBig(SessElement, obx, -oby);
                        }
                    }
                    if (Magic_Type == 1)
                    {
                        if (obx > 0 && obx < SessElement.SessionFallMatrix.GetLength(1) - 1 && -oby > 0 && -oby < SessElement.SessionFallMatrix.GetLength(0) - 1)
                        {
                            StaticClassGameTime.MagicSmall(SessElement, obx, -oby);
                        }
                    }
                    if (Magic_Type == 2)
                    {
                        if (-oby >= 0 && -oby < SessElement.SessionFallMatrix.GetLength(0))
                        {
                            StaticClassGameTime.MagicRow(SessElement, -oby);
                        }
                    }
                    if (Magic_Type == 3)
                    {
                        if (obx >= 0 && obx < SessElement.SessionFallMatrix.GetLength(1))
                        {
                            StaticClassGameTime.MagicColumn(SessElement, obx);
                        }
                    }
                    isClick = false;
                    NumberOfUsing--;
                }
            }
            if (isClick)
            {
                if (ppf != null)
                {
                    Vector3 currenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    currenPosition = new Vector3(currenPosition.x, currenPosition.y);

                    currenPosition = StaticClassGameTime.RoundIntPosition(currenPosition);
                    if (Magic_Type == 0)
                        currenPosition = new Vector2(currenPosition.x, currenPosition.y + 0.5f);
                    if (Magic_Type == 1)
                        currenPosition = new Vector2(currenPosition.x, currenPosition.y);
                    if (Magic_Type == 2)
                        currenPosition = new Vector2(4.5f, currenPosition.y);
                    if (Magic_Type == 3)
                        currenPosition = new Vector2(currenPosition.x, -3.5f);

                    ppf.transform.position = currenPosition;
                }
            }
        }
        else gameObject.transform.localScale = new Vector2(0.2f, 0.2f);
    }

    private void OnMouseDown()
    {
        List<GameObject> lst = StaticClassGameTime.EnemyObjectsList();
        if (lst.Count == 0 && NumberOfUsing > 0)
        {
            if (Magic_Type == 0)
            {
                ppf = GameObject.Instantiate(PolygonPrefab_mb);

                ppf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ppf.transform.position = new Vector3(ppf.transform.position.x, ppf.transform.position.y);
                StartPosition = ppf.transform.position;
            }
            if (Magic_Type == 1)
            {
                ppf = GameObject.Instantiate(PolygonPrefab_ms);

                ppf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ppf.transform.position = new Vector3(ppf.transform.position.x, ppf.transform.position.y);
                StartPosition = ppf.transform.position;
            }
            if (Magic_Type == 2)
            {
                ppf = GameObject.Instantiate(PolygonPrefab_row);

                ppf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ppf.transform.position = new Vector3(ppf.transform.position.x, ppf.transform.position.y);
                StartPosition = ppf.transform.position;
            }
            if (Magic_Type == 3)
            {
                ppf = GameObject.Instantiate(PolygonPrefab_column);

                ppf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ppf.transform.position = new Vector3(ppf.transform.position.x, ppf.transform.position.y);
                StartPosition = ppf.transform.position;
            }
            isClick = true;
        }
    }
}
