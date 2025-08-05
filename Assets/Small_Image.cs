using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.Mathematics;


public class Small_Image : MonoBehaviour
{

    public float fx;
    public float fy;

    int x, y;

    float start_x, start_y;

    private Vector3 offset, StartPosition;

    Basic BasicEl;

    int current_number, num_mov=10;

    int globalLevel;

    public int NumberOfImage;

    string Level_Number;


    // Start is called before the first frame update
    void Start()
    {
        globalLevel = Basic.ReadLevel();

        start_x = transform.position.x;
        start_y = transform.position.y;
        BasicEl = GameObject.Find("BasicElement").GetComponent<Basic>();
        current_number = StaticClassGameTime.PlayerList().Count;
        //num_mov =SessionElement.ReadIntFromFile("winnerMove");
        Level_Number = globalLevel.ToString() + "__" + NumberOfImage.ToString();
        if (File.Exists(Application.persistentDataPath + Level_Number))
        {
            num_mov = 0;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }

        // Update is called once per frame
        void Update()
    {
    }

    void OnMouseDown()
    {
        if (num_mov > 0)
        {
            offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            StartPosition = StaticClassGameTime.RoundIntPosition(gameObject.transform.position);
        }
    }

    private void OnMouseDrag()
    {
        if (num_mov > 0)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }



    private void OnMouseUp()
    {
       Vector2 vec=new Vector2(fx,fy);
        if (VectorComparizon(vec, transform.position, 3))
        {
            transform.position = new Vector2(fx, fy);
            BasicEl.NumberAddMoves += current_number;
            File.WriteAllText(Application.persistentDataPath + Level_Number, 1.ToString());
            transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 5;
            num_mov = 0;
        }
        else
        {
            transform.position = new Vector2(start_x, start_y);
        }
        num_mov--;
        File.WriteAllText(Application.persistentDataPath + "winnerMove", "0");
        File.WriteAllText(Application.persistentDataPath + "additionMoves", BasicEl.NumberAddMoves.ToString());
    }

    int In4(float a, int divide)
    {
        return Mathf.RoundToInt(a / divide);
    }

    bool VectorComparizon(Vector2 a, Vector2 b, int rate)
    {
        if (math.abs(a.x - b.x) < rate && math.abs(a.y - b.y) < rate) return true; else return false;
    }

}
