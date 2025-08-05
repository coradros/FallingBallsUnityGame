using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChilds : MonoBehaviour
{
    List<GameObject> ChildList;
    // Start is called before the first frame update
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

    }


    int count = 0; int countnumber = 1;
    int ExCounter = 0;

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count > countnumber)
        {
            if (ExCounter > ChildList.Count - 1)
            {
                ChildList[ChildList.Count - 1].GetComponent<Renderer>().enabled = false;
                return;
            }
            ChildList[ExCounter].GetComponent<Renderer>().enabled = true;
            if (ExCounter > 0) ChildList[ExCounter - 1].GetComponent<Renderer>().enabled = false;
            ExCounter++;
            count = 0;
        }

    }
}
