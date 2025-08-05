using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Saver : MonoBehaviour
{

    SessionElement SessElement;

    int localNumberMoves;

    public List<GameObject> FullLevelList;

    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        localNumberMoves = SessElement.NumberOfMoves;
        FullLevelList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckAllMistakes.MovesChange(SessElement, ref localNumberMoves)&&SessElement.isLaburunth)
        {
            FullLevelList = StaticClassGameTime.FullLevelObjectsList();
            ClearList(FullLevelList);
            SaveLevel(FullLevelList, "Labirinth");
        }
    }

    public static void ClearList(List<GameObject> aLevelList)
    {
        foreach (GameObject go in aLevelList)
        {
            if (go == null)
            {
                aLevelList.Remove(go);
                break;
            }
        }
    }

    public static GameObject JumpObject(GameObject aGo, List<GameObject> aLevelList)
    {
        int x = StaticClassGameTime.RoundIntPosition(aGo.transform.position.x);
        int y = StaticClassGameTime.RoundIntPosition(aGo.transform.position.y);
        ClearList(aLevelList);
        foreach (GameObject go in aLevelList)
        {
            if (go != null)
            {
                if (StaticClassGameTime.RoundIntPosition(go.transform.position.x) == x &&
                    StaticClassGameTime.RoundIntPosition(go.transform.position.y) == y + 1)
                {
                    if (go.GetComponent<Fly>() == null) return go;

                }
            }
        }
        return null;
    }

    public static void SaveLevel(List<GameObject> aLevelList, string aFileName)
    {
        int k1=0, k2=0, k3=0, k4=0;
        int[,] checkMatrix = new int[8, 19];
        List<string> StringLevel = new List<string>();
        List<string> keys = new List<string>();

        foreach (GameObject go in aLevelList)
        {
            int number = 0;
            int x = StaticClassGameTime.RoundIntPosition(go.transform.position.x);
            int y = StaticClassGameTime.RoundIntPosition(go.transform.position.y);
            int capacity = 0;
            int hp = 1;
            if (go.GetComponent<Fall>() != null)
            {
                number = go.GetComponent<Fall>().number;
                if (go.GetComponent<Bomb>() != null) capacity = go.GetComponent<Bomb>().Capacity;
            }
            if (go.GetComponent<Barriers>() != null && go.GetComponent<Health>())
            {
                number = go.GetComponent<Barriers>().Number;
                hp = go.GetComponent<Health>().HealthPoint;
            }
            string str = number + "," + x + "," + y + "," + capacity + "," + hp;

            Kight kht = go.GetComponent<Kight>();

            if (kht != null)
            {
                if (kht.yellow.GetComponent<Renderer>().enabled) k1 = 1;
                if (kht.green.GetComponent<Renderer>().enabled) k2 = 1;
                if (kht.blue.GetComponent<Renderer>().enabled) k3 = 1;
                if (kht.red.GetComponent<Renderer>().enabled) k4 = 1;
                keys.Add(k1.ToString());
                keys.Add(k2.ToString());
                keys.Add(k3.ToString());
                keys.Add(k4.ToString());
            }

            if (x >= 0 && x < 8 && -y >= 0 && -y < 19 && checkMatrix[x, -y] == 0)
            {
                StringLevel.Add(str);
                checkMatrix[x, -y] = 1;
            }
        }
        File.WriteAllLines(Application.persistentDataPath + aFileName, StringLevel);
        File.WriteAllLines(Application.persistentDataPath + aFileName+"_key", keys);
    }

    public static int[,] ReadArrayFromFile(string aFileName)
    {
        string[] lines = File.ReadAllLines(Application.persistentDataPath + aFileName);
        List<string[]> lst = Basic.strArray(lines);

        int[,] arr = Basic.List2Matrix(lst);

        return arr;
    }

    public static GameObject CreateFall(SessionElement se, int aNumber, int aX, int aY, int aCapacity)
    {
        GameObject go;
        switch (aNumber)
        {
            case 500:
                {
                    go = GameObject.Instantiate(se.BombPrefabs[0]);
                    go.GetComponent<Bomb>().Capacity = aCapacity;
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 501:
                {
                    go = GameObject.Instantiate(se.BombPrefabs[1]);
                    go.GetComponent<Bomb>().Capacity = aCapacity;
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 502:
                {
                    go = GameObject.Instantiate(se.BombPrefabs[2]);
                    go.GetComponent<Bomb>().Capacity = aCapacity;
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 600:
                {
                    go = GameObject.Instantiate(se.BombPrefabs[3]);
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 700:
                {
                    go = GameObject.Instantiate(se.KeyPrefabs[0]);
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 701:
                {
                    go = GameObject.Instantiate(se.KeyPrefabs[1]);
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 702:
                {
                    go = GameObject.Instantiate(se.KeyPrefabs[2]);
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 703:
                {
                    go = GameObject.Instantiate(se.KeyPrefabs[3]);
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            default:
                {
                    go = GameObject.Instantiate(StaticClassGameTime.GetRandomFall(aNumber, se.FallinPrefs, se.FallsColorsNumber));
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
        }
        return go;
    }

    public static GameObject CreateBarr(SessionElement se, int aNumber, int aX, int aY, int aHp)
    {
        GameObject go = null;
        switch (aNumber)
        {
            case 200:
                {
                    go = GameObject.Instantiate(se.BarrierPrefabs[0]);
                    go.GetComponent<SwitchTrigger>().SwitchOff();
                    if (aHp != -1) go.GetComponent<Health>().HealthPoint = aHp;
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 205:
                {
                    go = GameObject.Instantiate(se.BarrierPrefabs[1]);
                    go.GetComponent<SwitchTrigger>().SwitchOff();
                    if(aHp!=-1) go.GetComponent<Health>().HealthPoint = aHp;
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 105:
                {
                    go = GameObject.Instantiate(se.BarrierPrefabs[10]);
                    go.GetComponent<SwitchTrigger>().SwitchOff();
                    if (aHp != -1) go.GetComponent<Health>().HealthPoint = aHp;
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 110:
                {
                    go = GameObject.Instantiate(se.BarrierPrefabs[11]);
                    go.GetComponent<SwitchTrigger>().SwitchOff();
                    if (aHp != -1) go.GetComponent<Health>().HealthPoint = aHp;
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            case 111:
                {
                    go = GameObject.Instantiate(se.BarrierPrefabs[2]);
                    go.GetComponent<SwitchTrigger>().SwitchOff();
                    if (aHp != -1) go.GetComponent<Health>().HealthPoint = aHp;
                    go.transform.position = new Vector2(aX, aY);
                    break;
                }
            default:
                {
                    break;
                }
        }
        return go;
    }

    public static GameObject CreateGameObject(SessionElement se, int aNumber, int aX, int aY, int aCapacity, int aHp)
    {
        if (aNumber > 20 && aNumber < 450) return CreateBarr(se, aNumber, aX, aY, aHp);
        else return CreateFall(se, aNumber, aX, aY, aCapacity);
    }

    public static void LoadLevel(SessionElement se, string aFileName)
    {
        SwitchAlltriggersOff();
        int[,] arr = ReadArrayFromFile(aFileName);
        for (int i = 0; i < arr.GetLongLength(0); i++)
        {
            GameObject tt = CreateGameObject(se, arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4]);
        }

        GameObject kht = GameObject.Find("Knight(Clone)");
        if (kht != null)
        {
            Kight k = kht.GetComponent<Kight>();
            if (kht != null && k != null)
            {
                int[,] key = ReadArrayFromFile(aFileName + "_key");
                if (key[0, 0] == 1) k.yellow.GetComponent<Renderer>().enabled = true;
                if (key[1, 0] == 1) k.green.GetComponent<Renderer>().enabled = true;
                if (key[2, 0] == 1) k.blue.GetComponent<Renderer>().enabled = true;
                if (key[3, 0] == 1) k.red.GetComponent<Renderer>().enabled = true;
            }
        }
        SwitchAlltriggersOn();
    }
    public static void LoadBeginLevel(SessionElement se, int[,] arr)
    {
        SwitchAlltriggersOff();
        for (int i = 0; i < arr.GetLongLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                GameObject tt = CreateGameObject(se, arr[i, j], j, -i, 0, -1);
            }
        }
        
        SwitchAlltriggersOn();
    }

    public static void SwitchAlltriggersOn()
    {
        List<GameObject> lst = StaticClassGameTime.FullTriggerList();
        foreach(GameObject go in lst)
        {
            if (go.GetComponent<FallTrigger>() != null) go.GetComponent<FallTrigger>().enabled = true;
            if (go.GetComponent<SwitchTrigger>() != null) go.GetComponent<SwitchTrigger>().SwitchOn();
        }
    }
    public static void SwitchAlltriggersOff()
    {
        List<GameObject> lst = StaticClassGameTime.FullTriggerList();
        foreach (GameObject go in lst)
        {
            if (go.GetComponent<FallTrigger>() != null) go.GetComponent<FallTrigger>().enabled = false;
            if (go.GetComponent<SwitchTrigger>() != null) go.GetComponent<SwitchTrigger>().SwitchOff();
        }
    }


    public static void DrawLevelMatrix(GameObject aBp)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject curGO = GameObject.Instantiate(aBp);
                curGO.name = "Lev"+(i * 1000 + j * 10).ToString();
                curGO.transform.position = new Vector2(j * 2f-3.9f, -i * 2f+9f);
                curGO.transform.localScale = new Vector2(1.95f, 1.95f);

            }
        }
        if (File.Exists(Application.persistentDataPath + "DeletedLevels"))
        {
            string[] deletedLevels = File.ReadAllLines(Application.persistentDataPath + "DeletedLevels");

            for (int i = 0; i < deletedLevels.Length; i++) Destroy(GameObject.Find("Lev"+deletedLevels[i]));
        }
    }

}

