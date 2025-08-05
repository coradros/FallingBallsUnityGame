using UnityEngine;

public class Trainer : MonoBehaviour
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

    GameObject work;

    SessionElement SessElement;

    int localNumberMoves;

    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        localNumberMoves = SessElement.NumberOfMoves;
        work = GameObject.Instantiate(move1);
        work.transform.position = new Vector2(3.5f, -3.5f);
    }

    int counter = 0, delayer = 0, delay = 50;
    // Update is called once per frame
    void Update()
    {
        if (counter == 0 && delayer == delay)
        {
            StaticClassGameTime.ChangeToNeed(SessElement, 6, 2, 0);
            delayer = 0;
        }

        delayer++;
        //if (counter == 1) StaticClassGameTime.ChangeToNeed(SessElement, 10, 3, 0);
        //if (counter == 2) StaticClassGameTime.ChangeToNeed(SessElement, 10, 4, 0);
        //if (counter == 3) StaticClassGameTime.ChangeToNeed(SessElement, 2, 3, 0);


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
                StaticClassGameTime.ChangeToNeed(SessElement, 10, 3, 0);

            }
            if (counter == 2)
            {
                SessElement.ColNumber = 1;
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move4);
                work.transform.position = new Vector2(3.5f, -3.5f);
                StaticClassGameTime.ChangeToNeed(SessElement, 2, 3, 0);

            }
            if (counter == 3)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move5);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 4)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move6);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 5)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move7);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 6)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move8);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 7)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move9);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 8)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move10);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 9)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move11);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 9)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move11);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 10)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move12);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 11)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move13);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 12)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move14);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 13)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move15);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 14)
            {
                GameObject.Destroy(work);
                work = GameObject.Instantiate(move16);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 15)
            {
                GameObject.Destroy(work);
                GameObject fl = StaticClassGameTime.GetFly();
                if (fl != null) fl.transform.position = new Vector2(6, -1);
                work = GameObject.Instantiate(move17);
                work.transform.position = new Vector2(3.5f, -3.5f);
                StaticClassGameTime.ChangeToNeed(SessElement, 10, 7, 1);
            }
            if (counter == 16)
            {
                GameObject fl = StaticClassGameTime.GetFly();
                if (fl != null) fl.transform.position = new Vector2(6, -1);
            }
            if (counter == 17)
            {
                GameObject.Destroy(work);
                GameObject.Destroy(tmp_train);
                GameObject fl = StaticClassGameTime.GetFly();
                if (fl != null) GameObject.Destroy(fl);

                StaticClassGameTime.FillFallWithoutBariiersByColor(SessElement, 4);

                StaticClassGameTime.ClearFallWithoutBariiersByColor(SessElement, 0);

                work = GameObject.Instantiate(move18);
                work.transform.position = new Vector2(3.5f, -3.5f);
            }
            if (counter == 18)
            {
                GameObject.Destroy(work);
                GameObject.Destroy(tmp_train);
                work = GameObject.Instantiate(move19);
                work.transform.position = new Vector2(3.5f, -3.5f);

            }
            if (counter == 19)
            {
                GameObject.Destroy(work);
                GameObject.Destroy(tmp_train);
                work = GameObject.Instantiate(move20);
                work.transform.position = new Vector2(3.5f, -3.5f);

            }
            counter++;
        }
    }
}
