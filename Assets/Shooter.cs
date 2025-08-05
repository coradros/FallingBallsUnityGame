using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooter : MonoBehaviour
{
    SessionElement SessElement;
    public GameObject bullet;
    GameObject go_bullet;

    int target_x, target_y;

    public bool isShut = false;



    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShut)
        {
            MoveTo();
        }
    }

    void RandomShot()
    {
        int i = UnityEngine.Random.Range(0, SessElement.SessionStartMatrix.GetLength(0));
        int j = UnityEngine.Random.Range(0, SessElement.SessionStartMatrix.GetLength(1));
        Shot(j, -i);
        StaticClassGameTime.CatapultExp(j, i, SessElement.FallinPrefs, SessElement.SessionFallMatrix, 1, SessElement.FallsColorsNumber);
    }

    public void BombShot()
    {
        List<GameObject> bomblist = StaticClassGameTime.BombObjectsList();
        if (bomblist.Count != 0)
        {
            int x = StaticClassGameTime.RoundIntPosition(bomblist[0].transform.position.x);
            int y = StaticClassGameTime.RoundIntPosition(bomblist[0].transform.position.y);
            Shot(x, y);
            if (bomblist[0].GetComponent<Bomb>() != null) bomblist[0].GetComponent<Bomb>().SelfExplosion();
        }
        else
            RandomShot();
    }

    public void Shot(int x, int y)
    {
        go_bullet = GameObject.Instantiate(bullet);

        go_bullet.transform.position = transform.position;
        target_x = x; target_y = y;
        isShut = true;
    }

    public void MoveTo()
    {
        if (go_bullet == null) return;
        go_bullet.transform.position = Vector2.MoveTowards(go_bullet.transform.position, new Vector2(target_x, target_y), 10f * Time.deltaTime);
        if (go_bullet.transform.position == new Vector3(target_x, target_y, go_bullet.transform.position.z))
        {
            isShut = false;
            GameObject.Destroy(go_bullet);
            if(GetComponent<Bomb>()!=null) GameObject.Destroy(gameObject);
        }
    }
}
