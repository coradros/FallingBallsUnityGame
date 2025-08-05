using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameAnime : MonoBehaviour
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
            if (i == ChildList.Count) i = 0;
            DrawFrame(i);
            i++;
        }
    }

    void DrawFrame(int i)
    {
        for (int j = 0; j < ChildList.Count; j++)
        {
            ChildList[j].GetComponent<Renderer>().enabled = false;
        }
        ChildList[i].GetComponent<Renderer>().enabled = true;
    }
}
