using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;

public class Fly : MonoBehaviour
{

    public GameObject animePrefab;

    SessionElement SessElement;

    GameObject target;

    int curr_x, curr_y, target_x, target_y;

    int localNumberMoves;

    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        localNumberMoves = SessElement.NumberOfMoves;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckAllMistakes.MovesChange(SessElement, ref localNumberMoves))
        {
            if (target == null) target = FingTargetCoin();
            else gameObject.transform.position = StepPosition();

            //FindUnderMe();
        }
    }

    GameObject FingTargetCoin()
    {
        List<GameObject> lst = StaticClassGameTime.FallObjectsListByNumber(6);
        if (lst.Count > 0) return lst[0];
        else return null;
    }

    void DefineCoord()
    {
        curr_x = StaticClassGameTime.RoundIntPosition(gameObject.transform.position.x);
        curr_y = StaticClassGameTime.RoundIntPosition(gameObject.transform.position.y);
        target_x = StaticClassGameTime.RoundIntPosition(target.transform.position.x);
        target_y = StaticClassGameTime.RoundIntPosition(target.transform.position.y);
    }

    Vector2 StepPosition()
    {
        DefineCoord();
        int dist_x = target_x - curr_x;
        int dist_y = target_y - curr_y;

        int next_x, next_y;
        if (dist_x == 0 && dist_y == 0)
        {
            GameObject ani= GameObject.Instantiate(animePrefab);
            ani.transform.position=gameObject.transform.position;
            GameObject.Destroy(target);
            SessElement.NumberAddMoves--;
            return new Vector2(target_x, target_y);
        }
        else
        {
            if (math.abs(dist_x) >= math.abs(dist_y) && dist_x > 0)
            {
                next_x = curr_x + 1;
                next_y = curr_y;
                return new Vector2(next_x, next_y);
            }
            if (math.abs(dist_x) >= math.abs(dist_y) && dist_x < 0)
            {
                next_x = curr_x - 1;
                next_y = curr_y;
                return new Vector2(next_x, next_y);
            }
            if (math.abs(dist_x) < math.abs(dist_y) && dist_y > 0)
            {
                next_x = curr_x;
                next_y = curr_y + 1;
                return new Vector2(next_x, next_y);
            }
            if (math.abs(dist_x) < math.abs(dist_y) && dist_y < 0)
            {
                next_x = curr_x;
                next_y = curr_y - 1;
                return new Vector2(next_x, next_y);
            }
            return new Vector2(target_x, target_y);
        }
    }

    void FindUnderMe()
    {
        List<GameObject> lst = StaticClassGameTime.FallObjectsList();
        foreach (GameObject go in lst)
        {
            if (StaticClassGameTime.RoundIntPosition(transform.position.x) == StaticClassGameTime.RoundIntPosition(go.transform.position.x) &&
                StaticClassGameTime.RoundIntPosition(transform.position.y) == StaticClassGameTime.RoundIntPosition(go.transform.position.y))
            {
                if (go.GetComponent<Fall>() != null) go.GetComponent<Fall>().flyOnMe = gameObject;
            }
            else
                if (go.GetComponent<Fall>() != null) go.GetComponent<Fall>().flyOnMe = null;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        Fall fl = go.GetComponent<Fall>();
        if (fl != null) fl.flyOnMe = gameObject;

    }

}
