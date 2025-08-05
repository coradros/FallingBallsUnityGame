using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_anime : MonoBehaviour
{

    List<GameObject> ChildList;
    // Start is called before the first frame update
    void Start()
    {
        CreateList();
    }

    void CreateList()
    {
        int ChildNumber = GetComponent<Transform>().childCount;
        ChildList = new List<GameObject>();
        for (int i = 0; i < ChildNumber; i++)
        {
            ChildList.Add(GetComponent<Transform>().GetChild(i).gameObject);
        }
    }

    int i = 0, counter = 0, count = 7;
    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter == count)
        {
            counter = 0;
            if (i == 0) i = 1;
            else i = 0;
            DrawArrow(i);
        }
    }

    void DrawArrow(int i)
    {
        if (i == 0)
        {
            ChildList[i].GetComponent<Renderer>().enabled = true;
            ChildList[1].GetComponent<Renderer>().enabled = false;
        }
        else
        {
            ChildList[i].GetComponent<Renderer>().enabled = true;
            ChildList[0].GetComponent<Renderer>().enabled = false;
        }
    }
}
