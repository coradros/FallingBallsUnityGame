using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Exposion : MonoBehaviour
{
    // Start is called before the first frame update

    List<GameObject> ChildList, PlazmaList;

    List<Vector2> RoundPosition;
    int radius = 10;

    public GameObject Plazma;

    void Start()
    {
        int ChildNumber = GetComponent<Transform>().childCount;
        ChildList = new List<GameObject>();
        for (int i = 0; i < ChildNumber; i++)
        {
            GameObject go = GetComponent<Transform>().GetChild(i).gameObject;
            if (go != null)
            {
                go.GetComponent<Renderer>().enabled = false;
                ChildList.Add(go);
            }
        }

        PlazmaList = new List<GameObject>();
        RoundPosition = new List<Vector2>();
        for (int i = 0; i < 36; i++)
        {
            GameObject plzm = GameObject.Instantiate(Plazma);
            plzm.transform.position = transform.position;
            PlazmaList.Add(plzm);
            RoundPosition.Add(GetRoundPosition(i * 10) + new Vector2(transform.position.x, transform.position.y));
        }
    }

    int count = 0; int countnumber = 1;
    int ExCounter = 0;
    // Update is called once per frame
    void Update()
    {        
        MoveTo();

        count++;
        if (count > countnumber)
        {
            if (ExCounter > ChildList.Count - 1)
            {
                ChildList[ChildList.Count-1].GetComponent<Renderer>().enabled = false;
                return;
            }
            ChildList[ExCounter].GetComponent<Renderer>().enabled = true;
            if (ExCounter > 0) ChildList[ExCounter - 1].GetComponent<Renderer>().enabled = false;
            ExCounter++;
            count = 0;
        }

    }

    Vector2 GetRoundPosition(float angle)
    {
        float x = radius * math.sin(angle);
        float y = radius * math.cos(angle);
        return new Vector2(x, y);
    }

    void MoveTo()
    {
        int j = 0;
        for (int i = 0; i < PlazmaList.Count; i++)
        {if (PlazmaList[i] != null)
            {
                PlazmaList[i].transform.position = Vector2.MoveTowards(PlazmaList[i].transform.position, RoundPosition[i], 10f * Time.deltaTime);
                if (new Vector2(PlazmaList[i].transform.position.x, PlazmaList[i].transform.position.y) == RoundPosition[i])
                {
                    GameObject.Destroy(PlazmaList[i].gameObject);
                    j++;
                }
                if (j == PlazmaList.Count) GameObject.Destroy(gameObject);
            }
        }
    }
}
