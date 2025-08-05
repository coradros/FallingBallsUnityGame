using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.Port;
using UnityEngine.UIElements;

public class Barriers : MonoBehaviour
{

    public GameObject MouthPrefab;

    SessionElement SessElement;
    Shooter shooter;
    public int Number;
    int MaxHealth;
    List<GameObject> ChildList;
    Health goHealth;
    int localMoves = 5, localOldMoves;

    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        goHealth = gameObject.GetComponent<Health>();
        StatusOfHealth();
        goHealth.HealthPoint = MaxHealth;
        localOldMoves = SessElement.NumberOfMoves;
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        StaticClassGameTime.FillFallMatrix(gameObject, SessElement, Number);
        ViewOfStatus(goHealth.HealthPoint);
        if (CheckAllMistakes.MovesChange(SessElement, ref localOldMoves))
        {
            localMoves--;
            if (Number == 105)
            {
                if (!IsRightFall()) IsLeftFall();
            }
        }
        if (localMoves < 0)
        {
            int fff = SessElement.NumberOfMoves;
            if (Number == 110)
            {
                try
                {
                    shooter.BombShot();
                }
                catch { return; }
            }
            localMoves = 5;
        }

    }

    void StatusOfHealth()
    {
        int ChildNumber = GetComponent<Transform>().childCount;
        ChildList = new List<GameObject>();
        for (int i = 0; i < ChildNumber; i++)
        {
            ChildList.Add(GetComponent<Transform>().GetChild(i).gameObject);
        }
        MaxHealth = ChildList.Count;
        if (Number == 111) MaxHealth = 1000;
    }

    void ViewOfStatus(int aHp)
    {if (Number == 111) return;
        if (aHp < 0) aHp = 0;
        if (aHp == 0) return;
        int numOfChild = MaxHealth - aHp;
        ChildList[numOfChild].GetComponent<SpriteRenderer>().sortingOrder = 5 + numOfChild;
    }

    bool IsRightFall()
    {
        List<GameObject> lst = StaticClassGameTime.FallObjectsList();
        foreach (GameObject go in lst)
        {
            if (go != null && go.GetComponent<Fall>() != null && go.GetComponent<Fall>().number == 6 && go.GetComponent<Fall>().rightFall == gameObject)
            {
                GameObject.Destroy(go);
                GameObject mo= GameObject.Instantiate(MouthPrefab);
                mo.transform.localScale = new Vector2(-1.5f, 1.5f);
                mo.transform.position = gameObject.transform.position;
                SessElement.NumberAddMoves--;
                return true;
            }
        }
        return false;
    }
    bool IsLeftFall()
    {
        List<GameObject> lst = StaticClassGameTime.FallObjectsList();
        foreach (GameObject go in lst)
        {
            if (go != null && go.GetComponent<Fall>() != null && go.GetComponent<Fall>().number == 6 && go.GetComponent<Fall>().leftFall == gameObject)
            {
                GameObject.Destroy(go);
                GameObject mo = GameObject.Instantiate(MouthPrefab);
                mo.transform.position = gameObject.transform.position;

                SessElement.NumberAddMoves--;
                return true;
            }
        }
        return false;
    }
}
