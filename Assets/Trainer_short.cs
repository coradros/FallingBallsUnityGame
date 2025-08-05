using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Trainer_short : MonoBehaviour
{
    public GameObject tmp_train;
    public GameObject move1;
    public GameObject move2;
    public GameObject move3;
    public GameObject move4;
    public GameObject move5;
    public GameObject move6;
    public GameObject move7;
    public GameObject move8;
    public GameObject move9;
    public GameObject move10;
    public GameObject move11;
    public GameObject move12;
    public GameObject move13;
    public GameObject move14;
    public GameObject move15;
    public GameObject move16;
    public GameObject move17;
    public GameObject move18;
    public GameObject move19;
    public GameObject move20;

    public GameObject tr2_1;
    public GameObject tr2_2;

    public GameObject tr3_1;
    public GameObject tr3_2;

    public GameObject tr4_1;
    public GameObject arrow_right;
    public GameObject arrow_left;
    public GameObject touch;

    GameObject work;

    SessionElement SessElement;

    int localNumberMoves;

    int trainerLevel;

    Predator pred;

    // Start is called before the first frame update
    void Start()
    {
        pred = GameObject.Find("Predator").GetComponent<Predator>();

        string[] deletedLevels=pred.FinishedCovers;

        trainerLevel = deletedLevels.Length;

        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        localNumberMoves = SessElement.NumberOfMoves;

        if (trainerLevel == 0)
        {
            work = GameObject.Instantiate(move1);
            work.transform.position = new Vector2(3.5f, -3.5f);
        }

        if (trainerLevel == 1)
        {
            work = GameObject.Instantiate(tr2_1);
            work.transform.position = new Vector2(3.5f, -3.5f);
        }

        if (trainerLevel == 2)
        {
            work = GameObject.Instantiate(tr3_1);
            work.transform.position = new Vector2(3.5f, -3.5f);
        }

        if (trainerLevel == 3)
        {
            work = GameObject.Instantiate(arrow_right);
            work.transform.position = new Vector2(5.5f, -1);
        }
    }

    int counter = 0, delayer = 0, delay = 50, delay2 = 20;
    bool repeater = true;
    // Update is called once per frame
    void Update()
    {
        if (trainerLevel == 0)
        {
            Training1();
        }

        if (trainerLevel == 1)
        {
            Training2();
        }

        if (trainerLevel == 2)
        {
            Training3();
        }

        if (trainerLevel == 3)
        {
            Training4();
        }
        delayer++;
    }



    private void Training1()
    {
        if (delayer == delay2 && repeater)
        {
            CreateTrainingSet1(SessElement);
            repeater = false;
        }

        if (counter == 0 && delayer == delay)
        {
            StaticClassGameTime.ChangeToNeed(SessElement, 6, 2, 0);
            delayer = 0;
        }


        if (CheckAllMistakes.MovesChange(SessElement, ref localNumberMoves))
        {
            if (counter == 0)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move2);
                work.transform.position = new Vector2(3.5f, -3.5f);
                StaticClassGameTime.ChangeToNeed(SessElement, 6, 2, 0);

            }
            if (counter == 1)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move3);
                work.transform.position = new Vector2(3.5f, -3.5f);
                //StaticClassGameTime.ChangeToNeed(SessElement, 10, 3, 0);

            }
            if (counter == 2)
            {
                GameObject.Destroy(work);
                delayer = 0;

            }
            counter++;
        }
    }

    private void Training2()
    {
        if (delayer == delay2) CreateTrainingSet2(SessElement);

        if (CheckAllMistakes.MovesChange(SessElement, ref localNumberMoves))
        {
            if (counter == 0)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(tr2_2);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 1)
            {
                GameObject.Destroy(work);
            }
            counter++;
        }
    }
    private void Training3()
    {
        if (delayer == delay2) CreateTrainingSet3(SessElement);

        if (CheckAllMistakes.MovesChange(SessElement, ref localNumberMoves))
        {
            if (counter == 0)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(arrow_right);
                work.transform.position = new Vector2(5.5f, 0);
            }
            if (counter == 1)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(arrow_right);
                work.transform.position = new Vector2(4.5f, 0);
            }
            if (counter == 2)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(arrow_right);
                work.transform.position = new Vector2(3.5f, 0);
            }
            if (counter == 3)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(touch);
                work.transform.position = new Vector2(3f, -1);
            }
            if (counter == 4)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(touch);
                work.transform.position = new Vector2(3f, -2);
            }
            if (counter == 5)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(tr3_2);
                work.transform.position = new Vector2(3f, -3);
            }
            if (counter == 6)
            {
                GameObject.Destroy(work);
            }
            counter++;
        }
    }


    private void Training4()
    {
        if (delayer == delay2) CreateTrainingSet4(SessElement);

        if (CheckAllMistakes.MovesChange(SessElement, ref localNumberMoves))
        {
            if (counter == 0)
            {
                GameObject fly = GameObject.Find("FlyEnemy1");
                if (fly != null) fly.transform.position = new Vector2(4, -1);

                GameObject.Destroy(work);
                work = GameObject.Instantiate(tr4_1);
                work.transform.position = new Vector2(3f, -3);
            }
            if (counter == 1)
            {
                GameObject.Destroy(work);
            }
            counter++;
        }
    }

    public static void CreateTrainingSet1(SessionElement se)
    {
        StaticClassGameTime.ChangeToNeed(se, 5, 0, 0);
        StaticClassGameTime.ChangeToNeed(se, 5, 1, 0);
        StaticClassGameTime.ChangeToNeed(se, 6, 2, 0);
        GameObject fly = GameObject.Find("FlyEnemy1");
        if (fly != null) GameObject.Destroy(fly);
    }
    public static void CreateTrainingSet2(SessionElement se)
    {
        StaticClassGameTime.ChangeToNeed(se, 10, 0, 0);
        GameObject fly = GameObject.Find("FlyEnemy1");
        if (fly != null) GameObject.Destroy(fly);
    }
    public static void CreateTrainingSet3(SessionElement se)
    {
        StaticClassGameTime.ChangeToNeed(se, 10, 7, 0);
        StaticClassGameTime.ChangeToNeed(se, 1, 3, 0);
        StaticClassGameTime.ChangeToNeed(se, 2, 3, 1);
        StaticClassGameTime.ChangeToNeed(se, 3, 3, 2);
        GameObject fly = GameObject.Find("FlyEnemy1");
        if (fly != null) GameObject.Destroy(fly);
    }
    public static void CreateTrainingSet4(SessionElement se)
    {
        StaticClassGameTime.ChangeToNeed(se, 10, 6, 1);
        StaticClassGameTime.ChangeToNeed(se, 6, 7, 1);
        GameObject fly = GameObject.Find("FlyEnemy1");
        if (fly != null) fly.transform.position=new Vector2(3, -1);
    }

}
