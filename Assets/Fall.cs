using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Fall : MonoBehaviour
{

    public GameObject leftFall;
    public GameObject rightFall;




    public GameObject flyOnMe;

    public int number;
    bool isMove;
    bool isBlocked = false;
    public bool isButton = false;
    public bool isPressed = false;
    public bool isActive = true;
    bool isDestroyed = false;

    bool canDrag = true;

    int[,] SessionFallMatrix;

    bool isFallingNow = true;

    Health HP;

    SessionElement SessElement;

    GameObject gmo;

    AnimSCRIPT ansc;

    int localNumberMoves;


    int AnimDiver = 5;

    Vector2 fallPos1, fallPos2, fallPos3;

    // Start is called before the first frame update
    void Start()
    {
        isMove = false;


        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();

        HP = gameObject.GetComponent<Health>();


        SessionFallMatrix = SessElement.SessionFallMatrix;

        gmo = new GameObject();

        ansc = SessElement.gameObject.GetComponent<AnimSCRIPT>();

        localNumberMoves = SessElement.NumberOfMoves;

    }

    // Update is called once per frame

    int count = 0, posy;
    bool isOutside = false;

    int countStabb = 0, StabLimit = 5;

    float stabx, staby;

    public bool isStability = false;

    int checkPos = 0, countPos = 3;

    void Update()
    {
        checkPos++;
        if (checkPos == 1) fallPos1 = gameObject.transform.position;
        if (checkPos == 2) fallPos2 = gameObject.transform.position;
        if (checkPos == 3) fallPos3 = gameObject.transform.position;
        if (checkPos==countPos) 
        {
            checkPos = 0;
            if(fallPos1==fallPos2&&fallPos2==fallPos3) isFallingNow = true;
            else isFallingNow=false;
        }

        if (CheckAllMistakes.MovesChange(SessElement, ref localNumberMoves))
        {
            if(isFallingNow)
            gameObject.transform.position=StaticClassGameTime.RoundIntPosition(gameObject.transform.position);
        }

        if (isDestroyed) Destroy(gameObject);
        if (!isButton)
        {
            StaticClassGameTime.FillFallMatrix(gameObject, SessElement, number);

            if (GameObject.Find("PolygonButton").GetComponent<PolygonProcess>().isRunning) isBlocked = true;
            else isBlocked = false;

        }
        else
        {
            if (!isActive)
            {
                Vector2 activScale = new Vector2(0.3f, 0.3f);
                gameObject.transform.localScale = activScale;
            }
            else
            {
                if (!isPressed)
                {
                    Vector2 activScale = new Vector2(0.95f, 0.95f);
                    gameObject.transform.localScale = activScale;
                }
            }
        }


        if (count == 1)
        {
            if ((int)math.round(gameObject.transform.position.y) > 0)
            {
                isOutside = true;
                posy = (int)math.round(gameObject.transform.position.y);
            }
        }
        if (count == 100)
        {
            if (isOutside)
            {
                int posyNext = (int)math.round(gameObject.transform.position.y);
                if (posyNext == posy)
                    GameObject.Destroy(gameObject);
                else
                    isOutside = false;
            }

            count = 0;
        }
        count++;



        if ((int)math.round(gameObject.transform.position.y) < -30) GameObject.Destroy(gameObject);

        if (countStabb == 0)
        {
            stabx = transform.position.x;
            staby = transform.position.y;
        }

        countStabb++;
        if (countStabb > StabLimit)
        {
            countStabb = 0;
            if (stabx == transform.position.x && staby == transform.position.y) isStability = true;
            else isStability = false;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HP.HealthPoint--;
        }
    }


    private void OnMouseUp()
    {
        if (!SessElement.isCanTouch) return;

        if (!isButton)
        {
            if (!isBlocked)
            {
                if (!isMove)
                {
                    //SessElement.CreateRandomFallUp((int)math.round(gameObject.transform.position.x));
                    SessElement.activeI = (int)math.round(gameObject.transform.position.x);
                    SessElement.activeJ = -(int)math.round(gameObject.transform.position.y);
                    SessElement.needRepeat = true;
                    if (HP != null) HP.HealthPoint--;
                }
                else isMove = false;
            }
        }
        else
        {
            if (isActive)
            {
                if (!isPressed)
                {
                    Vector2 pressScale = new Vector2(1.5f, 1.5f);
                    gameObject.transform.localScale = pressScale;
                    isPressed = true;
                    SessElement.ColNumber = number;
                    List<GameObject> buttons = SessElement.buttons;
                    foreach (GameObject b in buttons)
                    {
                        b.GetComponent<Fall>().isActive = false;
                    }
                    isActive = true;
                }
                else
                {
                    Vector2 pressScale = new Vector2(0.95f, 0.95f);
                    gameObject.transform.localScale = pressScale;
                    isPressed = false;
                    SessElement.ColNumber = 0;
                    List<GameObject> buttons = SessElement.buttons;
                    foreach (GameObject b in buttons)
                    {
                        b.GetComponent<Fall>().isActive = true;
                    }
                }
                SessElement.NumberOfMoves--;
            }
        }
        canDrag = true;
    }




    public void IfDestroy()
    {
        //SessElement.CreateRandomFallUp((int)math.round(gameObject.transform.position.x));
        GameObject.Destroy(gameObject);
    }
    public void IfDestroy(int level)
    {
        //SessElement.CreateRandomFallUp((int)math.round(gameObject.transform.position.x), level);
        GameObject.Destroy(gameObject);
    }


    private Vector3 offset, MaxOff, CurOff, StartPosition;
    float speed = 50;

    void OnMouseDown()
    {
        if (!isButton)
        {
            if (!isBlocked)
            {
                offset = gameObject.transform.position -
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
                StartPosition = StaticClassGameTime.RoundIntPosition(gameObject.transform.position);
            }
        }
    }


    bool KillFly(GameObject aWeapon)
    {
        if (aWeapon != null &&
            aWeapon.GetComponent<Fall>() != null &&
            aWeapon.GetComponent<Fall>().flyOnMe != null)
        {
            if (number == 10)
            {
                GameObject.Destroy(aWeapon.GetComponent<Fall>().flyOnMe);
                return true;
            }
        }
        return false;
    }

    /****************Move objects****************************************************************************************************************/
    void OnMouseDrag()
    {
        if (canDrag)
        {
            Vector2 lfpos, rtpos;
            if (!isButton)
            {
                if (rightFall != null)
                {
                    rtpos = rightFall.transform.position;
                }
                else
                {
                    rtpos = new Vector2(100, 100);
                }
                if (leftFall != null)
                {
                    lfpos = leftFall.transform.position;
                }
                else
                {
                    lfpos = new Vector2(100, 100);
                }
                if (gameObject.GetComponent<Bomb>() == null)
                {
                    if (!isBlocked)
                    {
                        MaxOff = new Vector3(0.1f, 0.1f, 0.1f);
                        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
                        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
                        MaxOff = transform.position - Input.mousePosition;

                        if (transform.position.x > StartPosition.x + 0.1)
                        {
                            if (rightFall != null)
                            {
                                Barriers br = rightFall.GetComponent<Barriers>();
                                if (br != null)
                                {
                                    if (number == 10)
                                    {
                                        br.GetComponent<Health>().HealthPoint--;
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;
                                    }
                                    else
                                    {
                                        gameObject.transform.position = StartPosition;
                                        canDrag=false;
                                    }
                                }
                                else
                                {

                                    rightFall.transform.position = StartPosition;
                                    if (rightFall != null && rightFall.GetComponent<Fall>() != null)
                                    {
                                        if (!KillFly(rightFall))
                                        {
                                            ansc.AnimeOfFalls(rightFall, gameObject, true, AnimDiver);
                                        }


                                        gmo = GameObject.Instantiate(gameObject);
                                        gmo.transform.position = new Vector2(200, 200);
                                        GameObject.Destroy(gameObject);
                                        gmo.transform.position = rtpos;

                                        if (rightFall.GetComponent<Fall>().number == number)
                                        {
                                            switch (number)
                                            {
                                                case 6:
                                                    StaticClassGameTime.ChangeToNeed(SessElement, 10, gmo);
                                                    rightFall.GetComponent<Health>().HealthPoint--;
                                                    canDrag = false;
                                                    break;
                                                case 10:
                                                    StaticClassGameTime.ChangeToBomb(SessElement, gmo);
                                                    rightFall.GetComponent<Health>().HealthPoint--;
                                                    canDrag = false;
                                                    break;
                                                default:
                                                    StaticClassGameTime.ChangeToNeed(SessElement, 6, gmo);
                                                    rightFall.GetComponent<Health>().HealthPoint--;
                                                    canDrag = false;
                                                    break;
                                            }
                                        }
                                    }
                                }

                                Bomb bmb = rightFall.GetComponent<Bomb>();
                                if (bmb != null)
                                {
                                    if (number == 1 || number == 2)
                                    {
                                        bmb.Capacity++;
                                        Destroy(gmo);
                                        canDrag = false;
                                    }
                                    if (number == 6 && bmb.TypeOfExplo == 0)
                                    {
                                        StaticClassGameTime.ChangeToRocket(SessElement, rightFall);
                                        Destroy(gmo);
                                        canDrag = false;
                                    }
                                    if (number == 6 && bmb.TypeOfExplo == 1)
                                    {
                                        StaticClassGameTime.ChangeToCatapult(SessElement, rightFall);
                                        Destroy(gmo);
                                        canDrag = false;
                                    }
                                }
                                Kight kht = rightFall.GetComponent<Kight>();
                                if (kht != null)
                                {
                                    if (number == 6)
                                    {
                                        kht.Jump();
                                        canDrag = false;
                                    }
                                    canDrag = false;
                                    if (number == 700)
                                    {
                                        kht.YellowKey();
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;
                                    }
                                    if (number == 701)
                                    {
                                        kht.GreenKey();
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;
                                    }
                                    if (number == 702)
                                    {
                                        kht.BlueKey();
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;
                                    }
                                    if (number == 703)
                                    {
                                        kht.RedKey();
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;
                                    }
                                }
                            }
                            else
                            {
                                gameObject.transform.position = StartPosition;

                                canDrag = false;
                                //SessElement.CreateRandomFallUp(StaticClassGameTime.RoundIntPosition(StartPosition.x));
                            }
                            isMove = true;
                            //HP.HealthPoint--;
                            SessElement.NumberOfMoves--;

                            canDrag = false;
                        }
                        if (transform.position.x < StartPosition.x - 0.1)
                        {

                            if (leftFall != null)
                            {
                                Barriers br = leftFall.GetComponent<Barriers>();
                                if (br != null)
                                {
                                    if (number == 10)
                                    {
                                        br.GetComponent<Health>().HealthPoint--;
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;

                                    }
                                    else
                                    {
                                        gameObject.transform.position = StartPosition;
                                        canDrag = false;
                                    }
                                }
                                else
                                {

                                    leftFall.transform.position = StartPosition;

                                    if (leftFall != null && leftFall.GetComponent<Fall>() != null)
                                    {
                                        if (!KillFly(leftFall))
                                        {
                                            ansc.AnimeOfFalls(leftFall, gameObject, true, AnimDiver);
                                        }

                                        gmo = GameObject.Instantiate(gameObject);
                                        gmo.transform.position = new Vector2(200, 200);
                                        GameObject.Destroy(gameObject);
                                        gmo.transform.position = lfpos;


                                        if (leftFall.GetComponent<Fall>().number == number)
                                        {
                                            switch (number)
                                            {
                                                case 6:
                                                    StaticClassGameTime.ChangeToNeed(SessElement, 10, gmo);
                                                    leftFall.GetComponent<Health>().HealthPoint--;
                                                    canDrag = false;
                                                    break;
                                                case 10:
                                                    StaticClassGameTime.ChangeToBomb(SessElement, gmo);
                                                    leftFall.GetComponent<Health>().HealthPoint--;
                                                    canDrag = false;
                                                    break;
                                                default:
                                                    StaticClassGameTime.ChangeToNeed(SessElement, 6, gmo);
                                                    leftFall.GetComponent<Health>().HealthPoint--;
                                                    canDrag = false;
                                                    break;
                                            }
                                        }
                                    }
                                }
                                Bomb bmb = leftFall.GetComponent<Bomb>();
                                if (bmb != null)
                                {
                                    if (number == 1 || number == 2)
                                    {
                                        bmb.Capacity++;
                                        Destroy(gmo);
                                        canDrag = false;

                                    }
                                    if (number == 6 && bmb.TypeOfExplo == 0)
                                    {
                                        StaticClassGameTime.ChangeToRocket(SessElement, leftFall);
                                        Destroy(gmo);
                                        canDrag = false;

                                    }
                                    if (number == 6 && bmb.TypeOfExplo == 1)
                                    {
                                        StaticClassGameTime.ChangeToCatapult(SessElement, leftFall);
                                        Destroy(gmo);
                                        canDrag = false;

                                    }
                                }
                                Kight kht = leftFall.GetComponent<Kight>();
                                if (kht != null)
                                {
                                    if (number == 6)
                                    {
                                        kht.Jump();
                                        canDrag = false;

                                    }
                                    if (number == 700)
                                    {
                                        kht.YellowKey();
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;

                                    }
                                    if (number == 701)
                                    {
                                        kht.GreenKey();
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;

                                    }
                                    if (number == 702)
                                    {
                                        kht.BlueKey();
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;

                                    }
                                    if (number == 703)
                                    {
                                        kht.RedKey();
                                        GameObject.Destroy(gameObject);
                                        canDrag = false;

                                    }
                                }
                            }
                            else
                            {
                                gameObject.transform.position = StartPosition;

                                canDrag = false;

                                //SessElement.CreateRandomFallUp(StaticClassGameTime.RoundIntPosition(StartPosition.x));
                            }


                            isMove = true;
                            //HP.HealthPoint--;
                            SessElement.NumberOfMoves--;
                            canDrag = false;
                        }
                        if (transform.position.y > StartPosition.y + 0.2 && transform.position.x > StartPosition.x - 0.95 && transform.position.x < StartPosition.x + 0.95)
                        {
                            transform.position = StartPosition;
                            isMove = true;

                            GameObject go = GameObject.Instantiate(ansc.StopGo);
                            go.transform.position = new Vector2(4, 0);
                            go.transform.localScale = new Vector2(2, 2);
                            canDrag = false;
                        }
                        if (transform.position.y < StartPosition.y - 0.2 && transform.position.x > StartPosition.x - 0.95 && transform.position.x < StartPosition.x + 0.95)
                        {
                            transform.position = StartPosition;
                            isMove = true;

                            GameObject go = GameObject.Instantiate(ansc.StopGo);
                            go.transform.position = new Vector2(4, -7);
                            go.transform.localScale = new Vector2(2, 2);

                            canDrag = false;
                        }
                    }
                }
            }
        }
    }
}

