using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AnimSCRIPT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Animation(ref isRun, image1, image2, delta, v1, v2);
        }
        catch
        {

        }
    }

    public GameObject first, second;

    public GameObject StopGo;

    GameObject image1, image2;

    public Vector2 v1, v2, delta;

    private bool isRun = false;
    int counter = 0, Div;



    public void AnimeOfFalls(GameObject aGo1, GameObject aGo2, bool isRight, int aDiv)
    {
        try
        {
            isRun = true;
            first = aGo1;
            second = aGo2;
            counter = 0;
            Div = aDiv;
            v1 = StaticClassGameTime.RoundIntPosition(first.transform.position);
            if (isRight) v2 = new Vector2(v1.x + 1, v1.y);
            else v2 = new Vector2(v1.x - 1, v1.y);
            delta = (v1 - v2) / Div;
            image1 = Imaging(first, v2);
            image2 = Imaging(second, v1);
            isRun = true;
        }
        catch
        {
            return;
        }
    }

    private GameObject Imaging(GameObject aGo, Vector2 aV)
    {
        GameObject go = GameObject.Instantiate(aGo);
        go.transform.position = new Vector2(500, 500);
        go.GetComponent<Collider2D>().enabled = false;
        Rigidbody2D rgbody = go.GetComponent<Rigidbody2D>();
        GameObject.Destroy(rgbody);
        go.transform.position = aV;
        return go;
    }

    public static void Animation(ref bool aIsRun, GameObject image1, GameObject image2, Vector2 delta, Vector2 v1, Vector2 v2)
    {
        if (aIsRun)
        {
            Vector2 cur1 = image1.transform.position;
            cur1 += delta;
            image1.transform.position = cur1;


            Vector2 cur2 = image2.transform.position;
            cur2 -= delta;
            image2.transform.position = cur2;
            if (math.abs(cur1.x - v1.x) < 0.1 || math.abs(cur2.x - v2.x) < 0.1)
            {
                aIsRun = false;
                GameObject.Destroy(image1);
                GameObject.Destroy(image2);
            }
        }
    }
}
