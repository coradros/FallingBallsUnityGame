using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionElement : MonoBehaviour
{

    public bool isTraining = false;

    PrefabsContainer PrefCont;

    public int NumberOfMoves = 50;
    public int OldNumberOfMoves;

    [HideInInspector] public int NumberAddMoves = 100;


    [HideInInspector] public bool isOpenFullMatrix;
    bool isOnceWinner;


    [HideInInspector] public List<GameObject> buttons;

    [HideInInspector] public List<GameObject> SquarePrefabs;

    [HideInInspector] public List<GameObject> BarrierPrefabs;
    [HideInInspector] public List<GameObject> BombPrefabs;
    [HideInInspector] public List<GameObject> KeyPrefabs;


    [HideInInspector] public List<GameObject> FallinPrefs;

    [HideInInspector] public int[,] SessionStartMatrix;
    [HideInInspector] public int[,] SessionFallMatrix;
    [HideInInspector] public int[,] SessionBarrierMatrix;

    [HideInInspector] public int ColNumber = 0;

    [HideInInspector] public int GlobalLevel;




    TextMeshPro NumberOfMovesTMP;

    [HideInInspector] public int Repeater;
    [HideInInspector] public bool needRepeat = false;

    [HideInInspector] public int activeI;
    [HideInInspector] public int activeJ;

    [HideInInspector] public bool isColPressed = false;

    [HideInInspector] public bool isCanTouch = true;

    [HideInInspector] public bool isOnce = true;

    [HideInInspector] public int FallsColorsNumber;

    public bool isEvent = false;

    public bool isStability = false;

    public bool isLaburunth = false;

    public GameObject BlackPref;

    Predator pred;

    // Start is called before the first frame update
    void Start()
    {
        pred = GameObject.Find("Predator").GetComponent<Predator>();


        if (!isLaburunth) Time.timeScale = 2;
        //string[] lines = File.ReadAllLines("F:\\gas\\sesue.txt");
        GlobalLevel = pred.GlobalLevel;


        ReadStartMatrix();

        FillPrefabsContainer();


        ReadBarrierMatrix();

        FillFallingObjects();

        DrawAllMatrix();

        //FillBarriers();
        Repeater = 1;
        NumberOfMovesTMP = GameObject.Find("NumberOfMoves").GetComponent<TextMeshPro>();

           ii = SessionStartMatrix.GetLength(0) - 1;

        //File.Delete(Application.persistentDataPath + "additionMoves");

        NumberAddMoves = pred.Coins;

        isOnceWinner = true;

        isCanTouch = true;

        L1 = new List<int>();
        L2 = new List<int>();

        OldNumberOfMoves = NumberOfMoves;

        if(!isLaburunth) StaticClassGameTime.FillFallWithBariiers(this);

    }

    void ReadStartMatrix()
    {
        string[] lines = File.ReadAllLines(Application.persistentDataPath + "sesuew");
        List<string[]> lst = Basic.strArray(lines);
        SessionStartMatrix = Basic.List2Matrix(lst);

        SessionStartMatrix = Predator.ConvertTo2DArray(pred.StartArray);
        SessionFallMatrix = new int[SessionStartMatrix.GetLength(0), SessionStartMatrix.GetLength(1)];

    }
    void ReadBarrierMatrix()
    {
        //string[] lines = File.ReadAllLines(Application.persistentDataPath + "barrier");
        //List<string[]> lst = Basic.strArray(lines);
        //SessionBarrierMatrix = Basic.List2Matrix(lst);

        SessionBarrierMatrix = Predator.ConvertTo2DArray(pred.EnemyArray);

    }

    void FillPrefabsContainer()
    {
        PrefCont = GameObject.Find("PrefabsContainer").GetComponent<PrefabsContainer>();

        PrefCont.StartPrefFill();

        SquarePrefabs = PrefCont.SquarePrefabs;
        FallinPrefs = PrefCont.FallPrefabs;
        buttons = PrefCont.ButtonPrefabs;
        BarrierPrefabs = PrefCont.BarrierPrefabs;
        BombPrefabs = PrefCont.BombPrefabs;
        KeyPrefabs = PrefCont.KeyPrefabs;
        FallsColorsNumber = PrefCont.PaletteMatrix.GetLength(0);

    }

    void DrawAllMatrix()
    {
        if (isLaburunth)
        {
            if (File.Exists(Application.persistentDataPath + "Labirinth"))
            {
                Saver.LoadLevel(this, "Labirinth");
                Saver.DrawLevelMatrix(BlackPref);
            }
            else
            {
                var textFile = Resources.Load<TextAsset>("GameImages/" + GlobalLevel.ToString() + "/lab");
                int[,] LabMatrix = Basic.List2Matrix(Basic.strArray(textFile));

                Saver.LoadBeginLevel(this, LabMatrix);
                Saver.DrawLevelMatrix(BlackPref);
            }
        }
        else
        {
            Basic.DrawBarrierMatrix(SessionBarrierMatrix, BarrierPrefabs);
            Basic.DrawBasicMatrix(SessionStartMatrix, SquarePrefabs);
        }
    }


    float time = 0, delay = 0.5f;
    float timeFall = 0, delayFall = 0.5f;
    float timeFullFall = 0, delayFullFall = 1f;
    float timeCheck = 0, delayCheck = 2;
    float timeLoose = 0, delayLoose = 0.5f;
    List<int> L1, L2;
    bool igo1 = false, igo2=false;

    int ii = 0;
    int jj;

    int count = 0, ob1, ob2;

    public bool isButtonsReturn=false;
    int bot = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (NumberAddMoves < 0) NumberAddMoves = 0;

        if (isButtonsReturn) bot++;

        if(bot==30)
        {
            ButtonsReturn();
            bot = 0;
            isButtonsReturn = false;
        }


        if (isEvent == true) isEvent = false;
        isEvent = CheckAllMistakes.MovesChange(this);

        //if (MovesChange()) ButtonsReturn();


        //if (StaticClassGameTime.MatrixComparison(SessionStartMatrix, SessionFallMatrix))
        //{
        //    time += Time.deltaTime;
        //    if (time > delay)
        //    {
        //        if (StaticClassGameTime.MatrixComparison(SessionStartMatrix, SessionFallMatrix))
        //        {
        //            if (isOnceWinner)
        //            {
        //                SaveWinnerStatus();
        //                isOnceWinner = false;
        //                isCanTouch = false;
        //            }
        //        }
        //    }
        //}

        if (needRepeat)
        {
            timeFall += Time.deltaTime;
            {
                if (timeFall > delayFall)
                {
                    if (Repeater == 1)
                    {
                        needRepeat = false;
                        timeFall = 0;
                        NumberOfMoves--;
                        isButtonsReturn = true;
                    }
                    else
                    {
                        GameObject go = StaticClassGameTime.FindGObyIJ(activeI, activeJ);
                        if (go != null && go.GetComponent<Fall>() != null && go.GetComponent<Health>() != null) go.GetComponent<Health>().HealthPoint--;
                        timeFall = 0;
                        Repeater--;
                        if (ColNumber == 10)
                        {
                            isButtonsReturn = true;
                            ColNumber = 0;
                        }

                    }
                }
            }
        }


        if (isOpenFullMatrix)
        {
            timeFullFall += Time.deltaTime;
            {
                if (timeFullFall > delayFullFall)
                {
                    if (jj == SessionStartMatrix.GetLength(1))
                    {
                        ii--;
                        jj = 0;
                    }
                    if (ii == 0 && jj == SessionStartMatrix.GetLength(1) - 1)
                    {
                        isOpenFullMatrix = false;
                    }
                    jj++;
                    timeFullFall = 0;
                }
            }
        }





        NumberOfMovesTMP.text = "Количество ходов " + NumberOfMoves.ToString() +
            "\nКоличество монет " + NumberAddMoves.ToString();
        if (NumberOfMoves <= 0 && isOnce && !StaticClassGameTime.MatrixComparison(SessionStartMatrix, SessionFallMatrix))
        {
            if (timeLoose > delayLoose && !StaticClassGameTime.MatrixComparison(SessionStartMatrix, SessionFallMatrix))
            {
                isCanTouch = false;
                GameObject.Instantiate(PrefCont.looser).transform.position = new Vector2(5, -5);
                isOnce = false;
            }
            timeLoose += Time.deltaTime;
        }
    }



    public void ButtonsReturn()
    {
        foreach(GameObject button in buttons)
        {
            if (button != null)
            {
                Fall fall = button.GetComponent<Fall>();
                if (fall != null)
                {
                    fall.isActive = true;
                    fall.isPressed = false;
                    ColNumber = 0;
                }
            }
        }
    }



    public bool CheckStability()
    {
        List<GameObject> lst = StaticClassGameTime.FallObjectsList();
        foreach(GameObject go in lst)
        {
            if (go == null) return false;
            if (go.GetComponent<Fall>() == null) return false;
            if (!go.GetComponent<Fall>().isStability) return false;
        }
        return true;
    }

    public bool MovesChange()
    {
        if (OldNumberOfMoves != NumberOfMoves)
        {
            if (CheckStability())
                OldNumberOfMoves = NumberOfMoves;
            return true;
        }
        else return false;
    }


    private void OnMouseDown()
    {
        GameObject.Instantiate(PrefCont.YesNoComplete).transform.position = new Vector2(5f, -8f);
    }


    public static int UpdateIntInFile(int aVal, string aFileName)
    {
        if (File.Exists(Application.persistentDataPath + aFileName))
        {
            string currentIntName = File.ReadAllText(Application.persistentDataPath + aFileName);
            int value = int.Parse(currentIntName);
            int vov = aVal + value;
            File.WriteAllText(Application.persistentDataPath + aFileName, vov.ToString());
            return value + aVal;
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + aFileName, aVal.ToString());
            return aVal;
        }
    }

    public static int ReadIntFromFile(string aFileName)
    {
        if (File.Exists(Application.persistentDataPath + aFileName))
        {
            string currentIntName = File.ReadAllText(Application.persistentDataPath + aFileName);
            int value = int.Parse(currentIntName);
            return value;
        }
        else
        {
            return 0;
        }
    }

    public void SaveWinnerStatus()
    {
        string[] deletedLevels = pred.FinishedCovers;
        if (deletedLevels.Length!=0)
        {
            deletedLevels = File.ReadAllLines(Application.persistentDataPath + "DeletedLevels");
        }
        else
        {
            deletedLevels = new string[0];
        }
        string currentLevelName = pred.currentLevel;

        pred.FinishedCovers = Predator.AddToArray(pred.FinishedCovers, currentLevelName);
        pred.Coins = NumberOfMoves + NumberAddMoves;

        StartCoroutine(WebAppBridge.PutPlayerData(pred));

        GameObject.Instantiate(PrefCont.winner).transform.position = new Vector2(5, -5);
        isOnceWinner = false;
        isCanTouch = false;

    }

    public void NumberEqAdd()
    {
        NumberOfMoves = NumberAddMoves;
        NumberAddMoves = 0;
    }

    void FillFallingObjects()
    {
        if (!isLaburunth)
        {
            GameObject botty = GameObject.Instantiate(PrefCont.bottom);
            botty.transform.position = new Vector2(SessionStartMatrix.GetLength(1) / 2, -SessionStartMatrix.GetLength(0));
            botty.transform.localScale = new Vector2(SessionStartMatrix.GetLength(1), 1);
        }
        else
        {
            GameObject botty = GameObject.Instantiate(PrefCont.bottom);
            botty.transform.position = new Vector2(SessionStartMatrix.GetLength(1) / 2, -SessionStartMatrix.GetLength(0)*2-3);
            botty.transform.localScale = new Vector2(SessionStartMatrix.GetLength(1), 1);
        }
    }
}
