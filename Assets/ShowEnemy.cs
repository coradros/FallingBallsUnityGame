using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ShowEnemy : MonoBehaviour
{

    List<GameObject> ChildList;

    int[] EnemyCountList;

    List<TextMeshPro> tmpList;

    // Start is called before the first frame update
    void Start()
    {
        CreateList();
    }

    // Update is called once per frame
    void Update()
    {
        MakeEnemyStatus();
        ViewEnemyStatus();
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
    List<GameObject> CreateList(GameObject go)
    {
        int ChildNumber = go.GetComponent<Transform>().childCount;
        List<GameObject> ObjectChildList = new List<GameObject>();
        for (int i = 0; i < ChildNumber; i++)
        {
            ObjectChildList.Add(go.GetComponent<Transform>().GetChild(i).gameObject);
        }
        return ObjectChildList;
    }

    void CreateTmpList()
    {
        CreateList();
        tmpList = new List<TextMeshPro>();
        foreach (GameObject g in ChildList)
        {
            List<GameObject> golist = CreateList(g);
            TextMeshPro tmp = golist[0].GetComponent<TextMeshPro>();
            if (tmp != null) tmpList.Add(tmp);
        }
    }

    void MakeEnemyStatus()
    {
        EnemyCountList = new int[5];
        List<GameObject> enemyList = StaticClassGameTime.EnemyObjectsList();
        foreach (GameObject enemy in enemyList)
        {
            if (enemy.GetComponent<Barriers>() != null)
            {
                int number = enemy.GetComponent<Barriers>().Number;
                switch (number)
                {
                    case 105:
                        EnemyCountList[0]++;
                        break;
                    case 110:
                        EnemyCountList[1]++;
                        break;
                    case 200:
                        EnemyCountList[2]++;
                        break;
                    case 205:
                        EnemyCountList[3]++;
                        break;
                }
            }
            if (enemy.GetComponent<Fly>() != null) EnemyCountList[4]++;
        }
    }

    void ViewEnemyStatus()
    {
        CreateTmpList();
        for (int i = 0; i < EnemyCountList.Count(); i++)
        {
            if (EnemyCountList[i] == 0)
            {
                ChildList[i].transform.position = new Vector2(100, 100);
            }
            tmpList[i].text = EnemyCountList[i].ToString();
        }
    }

}
