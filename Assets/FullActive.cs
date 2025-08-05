using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FullActive : MonoBehaviour
{

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button10;
    public GameObject buttonPlus;
    public GameObject buttonMinus;
    public GameObject buttonDigit;
    public GameObject buttonPoly;
    public GameObject buttonMagicBig;
    public GameObject buttonMagicSmall;
    public GameObject buttonRow;
    public GameObject buttonColumn;


    public GameObject EnemyFrame;



    List<GameObject> buttonList;
    List<GameObject> EnemyList;

    SessionElement SessElement;

    int GlobalLevel;

    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        GlobalLevel = Basic.ReadLevel();


        buttonList = new List<GameObject>();
        buttonList.Add(button1);
        buttonList.Add(button2);
        buttonList.Add(button3);
        buttonList.Add(button4);
        buttonList.Add(button5);
        buttonList.Add(button6);
        buttonList.Add(button7);
        buttonList.Add(button8);
        buttonList.Add(button9);
        buttonList.Add(button10);


        buttonList.Add(buttonPlus);
        buttonList.Add(buttonMinus);
        buttonList.Add(buttonDigit);
        buttonList.Add(buttonMagicBig);
        buttonList.Add(buttonMagicSmall);
        buttonList.Add(buttonRow);
        buttonList.Add(buttonColumn);
    }

    // Update is called once per frame

    int delayer = 1000, delay = 20;
    void Update()
    {
        EnemyList = StaticClassGameTime.EnemyObjectsList();
        if (EnemyList.Count > 0)
        {
            foreach (GameObject bu in buttonList)
            {
                if (bu != null)
                {
                    Collider2D col = bu.GetComponent<Collider2D>();
                    if (col != null) col.enabled = false;
                    bu.transform.localScale = new Vector2(0.2f, 0.2f);
                }
            }
        }
        else
        {
            foreach (GameObject bu in buttonList)
            {
                if (bu != null)
                {
                    Collider2D col = bu.GetComponent<Collider2D>();
                    if (col != null) col.enabled = true;
                    bu.transform.localScale = new Vector2(1f, 1f);
                }
            }

            if (GlobalLevel == 1)
            {
                delayer = 0;
                GlobalLevel = 0;
            }

        }

        if (delayer == delay)
        {
            StaticClassGameTime.FillFullMatrix(SessElement);
            GameObject.Destroy(EnemyFrame);
            SessElement.SaveWinnerStatus();
        }


        delayer++;
    }
}
