using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Collisions : MonoBehaviour
{

    bool isClick;
    GameObject polygon;
    int level;

    SessionElement Sesselement;

    // Start is called before the first frame update
    void Start()
    {
        polygon = GameObject.Find("PolygonButton");
        Sesselement=GameObject.Find("SessionElement").GetComponent<SessionElement>();
    }

    float delay = 0.5f;
    float timer = 0;
    bool running = false;
    bool isOnce = true;
    // Update is called once per frame
    void Update()
    {
        isClick = polygon.GetComponent<PolygonProcess>().isClick;


        if (running)
        {
            level = -(int)math.round(gameObject.transform.position.y) + (int)math.round(gameObject.transform.localScale.y) / 2;

            timer += Time.deltaTime;
            if (timer > delay)
            {
                CollProc();
                timer = 0;
            }
        }

        TriggerProc();
    }
    //ContactPoint2D[] contacts = new ContactPoint2D[200];
    List<Collider2D> colliders = new List<Collider2D>();
    List<Collider2D> DupesColliders = new List<Collider2D>();
    List<Collider2D> FinishColliders = new List<Collider2D>();


    void CollProc()
    {
        if (FinishColliders.Count > 0)
        {
            Collider2D colly = FinishColliders[0];
            FinishColliders.RemoveAt(0);
            int startLevel = -(int)math.round(colly.transform.position.y);
            if (colly.gameObject != null && colly.gameObject.GetComponent<Fall>() != null && colly.gameObject.GetComponent<Health>() != null) colly.gameObject.GetComponent<Health>().HealthPoint--;
            if (Sesselement.ColNumber == 10)
            {
                Sesselement.isButtonsReturn = true;
                Sesselement.ColNumber = 0;
            }
        }
        else
        {
            GameObject.Find("PolygonButton").GetComponent<PolygonProcess>().isRunning = false;
            
            Sesselement.NumberOfMoves--;

            Sesselement.isButtonsReturn=true;

            GameObject.Destroy(gameObject);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    void TriggerProc()
    {
        if (!isClick&&isOnce)
        {
            gameObject.GetComponent<Collider2D>().GetContacts(colliders);
            foreach (Collider2D col in colliders)
            {
                if (col.tag == "Fall")
                    DupesColliders.Add(col);
            }
            FinishColliders = DupesColliders.Distinct().ToList();
            isClick = true;           
            running = true;
            isOnce = false;
        }
    }
}
