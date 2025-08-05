using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PolygonPrefab;

    public GameObject SliderPrefab;

    public GameObject TargetPrefab;

    Shooter shooter;

    Slider slider;

    GameObject ppf;
    public bool isClick;
    Vector3 StartPosition;
    public bool isRunning = true;

    public bool isButton;

    public int TypeOfExplo;

    public int Capacity;

    SessionElement SessElement;

    void StopFreeze(bool isbu)
    {

        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (isbu)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
                rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Shooter>() != null) shooter = GetComponent<Shooter>();
        isClick = false;
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();

        if(SliderPrefab!=null) slider = SliderPrefab.GetComponent<Slider>();
    }


    public void SelfExplosion()
    {
        try
        {
            int obx = StaticClassGameTime.RoundIntPosition(transform.position.x);
            int oby = StaticClassGameTime.RoundIntPosition(transform.position.y);
            StaticClassGameTime.CatapultExp(obx, -oby, SessElement.FallinPrefs, SessElement.SessionFallMatrix, Capacity, SessElement.FallsColorsNumber);
            AfterExplo(obx);
        }
        catch
        {
            return;
        }
    }

    private void OnMouseDown()
    {
        if (isButton)
        {
            ppf = GameObject.Instantiate(PolygonPrefab);

            ppf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ppf.transform.position = new Vector3(ppf.transform.position.x, ppf.transform.position.y);
            StartPosition = ppf.transform.position;
            isClick = true;
            gameObject.GetComponent<Fall>().isPressed = true;

        }
        else
        {
            int obx = (int)math.round(gameObject.transform.position.x);
            int oby = (int)math.round(gameObject.transform.position.y);

            if (TypeOfExplo == 0)
            {
                StaticClassGameTime.BombExp(obx, -oby, SessElement.FallinPrefs, SessElement.SessionFallMatrix, Capacity, SessElement.FallsColorsNumber);
                AfterExplo(obx);
            }


            if (TypeOfExplo == 1)
            {
                StaticClassGameTime.RocketExp(obx, -oby, SessElement.FallinPrefs, SessElement.SessionFallMatrix, Capacity, SessElement.FallsColorsNumber);
                AfterExplo(obx);
            }

            if(TypeOfExplo==2)
            {
                ppf = GameObject.Instantiate(TargetPrefab);

                ppf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ppf.transform.position = new Vector3(ppf.transform.position.x, ppf.transform.position.y);
                StartPosition = ppf.transform.position;
                isClick = true;
            }
        }
    }

    void AfterExplo(int aObx)
    {
            SessElement.NumberOfMoves--;

            GameObject.Destroy(gameObject);
    }

    void AfterShut(int aObx)
    {
        SessElement.NumberOfMoves--;
    }


    // Update is called once per frame
    void Update()
    {
        StopFreeze(isButton);

        if (slider != null) slider.Capacity = Capacity;

        if (Capacity > 5) Capacity = 5;

        if (Input.GetMouseButtonUp(0))
        {
            if (isButton)
            {
                if (isClick)
                {
                    GameObject.Destroy(ppf);
                    Vector3 currenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    int obx = StaticClassGameTime.RoundIntPosition(currenPosition.x);
                    int oby = StaticClassGameTime.RoundIntPosition(currenPosition.y);
                    if (obx > 0 && obx < SessElement.SessionFallMatrix.GetLength(1) - 1&&-oby>0&&-oby<SessElement.SessionFallMatrix.GetLength(0)-1)
                    {
                        if (StaticClassGameTime.ForBomb(-oby, obx, SessElement.SessionFallMatrix, SessElement.SessionStartMatrix))
                        {
                            GameObject target = StaticClassGameTime.FindGObyIJ(obx, -oby);
                            GameObject.Destroy(target);

                            GameObject bomb = GameObject.Instantiate(gameObject);
                            bomb.transform.position = new Vector2(obx, oby);

                            bomb.GetComponent<Bomb>().isButton = false;
                            bomb.GetComponent<Bomb>().TypeOfExplo = TypeOfExplo;

                            bomb.GetComponent<Fall>().isButton = false;
                            bomb.transform.localScale = new Vector2(0.95f, 0.95f);
                            bomb.tag = "Fall";

                            StaticClassGameTime.BombInst(obx, -oby, SessElement.FallinPrefs, SessElement.FallsColorsNumber);
                        }
                    }
                    isClick = false;
                }
            }
            else
            {
                if (isClick && TypeOfExplo == 2)
                {
                    GameObject.Destroy(ppf);
                    Vector3 currenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    int obx = StaticClassGameTime.RoundIntPosition(currenPosition.x);
                    int oby = StaticClassGameTime.RoundIntPosition(currenPosition.y);
                    StaticClassGameTime.CatapultExp(obx, -oby, SessElement.FallinPrefs, SessElement.SessionFallMatrix, Capacity, SessElement.FallsColorsNumber);
                    if (shooter != null) shooter.Shot(obx, oby);
                    shooter.isShut = true;
                    AfterShut(obx);
                }
            }
        }

        if (isClick)
        {
            if (isButton)
            {
                Vector3 currenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currenPosition = new Vector3(currenPosition.x, currenPosition.y);
                ppf.transform.position = StaticClassGameTime.RoundIntPosition(currenPosition);
            }

            if(!isButton&&TypeOfExplo==2)
            {
                Vector3 currenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currenPosition = new Vector3(currenPosition.x, currenPosition.y);
                if(ppf!=null) ppf.transform.position = StaticClassGameTime.RoundIntPosition(currenPosition);
            }
        }
    }
}

