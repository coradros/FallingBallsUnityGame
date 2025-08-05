using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class Basic : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public GameObject go4;
    public GameObject go5;
    public GameObject go6;
    public GameObject go7;
    public GameObject go8;
    public GameObject go9;
    public GameObject go10;
    public GameObject go11;
    public GameObject blackPrefab;

    public GameObject aaa;

    List<GameObject> SquarePrefabs;

    int[,] baseMatrix;
    int[,] PaletteMatrix;
    int[,] baseBarrierMatrix;
    int[,] localmatrix;
    int[,] levelmatrixX;
    int[,] levelmatrixY;
    public int divX;
    public int divY;
    public int currentIndexX;
    public int currentIndexY;
    int scaleX, scaleY;
    public int pointX, pointY;

    public int NumberAddMoves;

    int globalLevel;

    List<Color> colorList;

    Predator pred;

    // Start is called before the first frame update
    void Start()
    {
        pred = GameObject.Find("Predator").GetComponent<Predator>();

        StartCoroutine(WebAppBridge.GetPlayerData(pred));

        globalLevel = pred.GlobalLevel;

        SquarePrefabs = FillPrefabs();
        var textFile = Resources.Load<TextAsset>("GameImages/" + globalLevel.ToString()+"/l");
        baseMatrix = convertMatrix(strArray(textFile));

        var textBarrierFile = Resources.Load<TextAsset>("GameImages/" + globalLevel.ToString() + "/b");
        baseBarrierMatrix = convertMatrix(strArray(textBarrierFile));

        var PaletteText = Resources.Load<TextAsset>("GameImages/" + globalLevel.ToString() + "/p");
        PaletteMatrix = List2Matrix(strArray(PaletteText));

        //SetPalette(SquarePrefabs);

        DrawBasicMatrix(baseMatrix, aaa, PaletteMatrix);

        DrawLevelMatrix();

        GameObject.Find("Texter").GetComponent<TextMeshPro>().text = "Количество монет " + NumberAddMoves.ToString();

        NumberAddMoves = pred.Coins;
    }




    public static int ReadLevel()
    {
        if (File.Exists(Application.persistentDataPath + "GlobalLevel"))
        {
            string strLevel = File.ReadAllText(Application.persistentDataPath + "GlobalLevel");
            int level = int.Parse(strLevel);
            return level;
        }
        return 1;
    }

    public static void WriteLevel(int level)
    {
        File.WriteAllText(Application.persistentDataPath + "GlobalLevel", level.ToString());
    }


    public static List<string[]> strArray(TextAsset textFile)
    {
        string[] str = textFile.text.Split('\n');
        return strArray(str);
    }



    public static List<string[]> strArray(string[] str)
    {
        List<string[]> aa = new List<string[]>();
        for (int i = 0; i < str.Length; i++)
        {
            aa.Add(str[i].Split(','));
        }
        return aa;
    }

    int[,] convertMatrix(List<string[]> aListArray)
    {
        int[,] ret = List2Matrix(aListArray);

        scaleX = ret.GetLength(1) / divX;
        scaleY = ret.GetLength(0) / divY;
        levelmatrixX = new int[divX, divY];
        levelmatrixY = new int[divX, divY];
        for (int i = 0; i < divX; i++)
        {
            for (int j = 0; j < divY; j++)
            {
                levelmatrixX[i, j] = i * scaleX;
                levelmatrixY[i, j] = j * scaleY;
            }
        }

        return ret;
    }

    public static int[,] List2Matrix(List<string[]> aListArray)
    {
        int[,] ret = new int[aListArray.Count, aListArray[0].Count()];
        for (int i = 0; i < aListArray.Count; i++)
        {
            for (int j = 0; j < aListArray[0].Count(); j++)
            {
                ret[i, j] = int.Parse(aListArray[i][j]);
            }
        }
        return ret;
    }


    List<GameObject> FillPrefabs()
    {
        List<GameObject> tp = new List<GameObject>();
        tp.Add(go1);
        tp.Add(go2);
        tp.Add(go3);
        tp.Add(go4);
        tp.Add(go5);
        tp.Add(go6);
        tp.Add(go7);
        tp.Add(go8);
        tp.Add(go9);
        tp.Add(go10);
        return tp;
    }


    void SetPalette(List<GameObject> aPrefabs)
    {
        for (int i = 0; i < aPrefabs.Count; i++)
        {
            Color co = CreateNewColor(PaletteMatrix, i + 1);
            Renderer rnd = aPrefabs[i].GetComponent<Renderer>();
            rnd.sharedMaterial.color = co;
        }
    }

    float ConvertComp(int aComp)
    {
        return (float)aComp / 255;
    }

    Color CreateNewColor(int[,] aPalette, int aNumber)
    {
        float r, g, b;
        for (int i = 0; i < aPalette.GetLength(0); i++)
        {
            if (aPalette[i, 0] == aNumber)
            {
                r = ConvertComp(aPalette[i, 1]);
                g = ConvertComp(aPalette[i, 2]);
                b = ConvertComp(aPalette[i, 3]);
                return new Color(r, g, b);
            }
        }
        return new Color(0, 0, 0);
    }


    public static void DrawBasicMatrix(int[,] aDrawArray, List<GameObject> PrefabArray)
    {
        for (int i = 0; i < aDrawArray.GetLength(0); i++)
        {
            for (int j = 0; j < aDrawArray.GetLength(1); j++)
            {
                GameObject go = GameObject.Instantiate(PrefabArray[aDrawArray[i, j] - 1]);
                go.transform.position = new Vector2(j, -i);
            }
        }
    }

    public void DrawBasicMatrix(int[,] aDrawArray, GameObject aPrefab, int[,] aPalettArray)
    {
        for (int i = 0; i < aDrawArray.GetLength(0); i++)
        {
            for (int j = 0; j < aDrawArray.GetLength(1); j++)
            {
                GameObject go = GameObject.Instantiate(aPrefab);
                go.transform.position = new Vector2(j, -i);
                Color col = CreateNewColor(PaletteMatrix, aDrawArray[i, j]);
                if (aDrawArray[i, j] == 6)
                    j = j;
                //Color col = CreateNewColor(PaletteMatrix, 7);
                go.GetComponent<Renderer>().material.color = col;
            }
        }
    }

    public static void DrawBarrierMatrix(int[,] aDrawArray, List<GameObject> PrefabArray)
    {
        for (int i = 0; i < aDrawArray.GetLength(0); i++)
        {
            for (int j = 0; j < aDrawArray.GetLength(1); j++)
            {
                int ggg = aDrawArray[i, j];
                if (ggg > 0)
                {
                    if (aDrawArray[i, j] == 200)
                        i = i;
                    int index = GetPrefabIndex(aDrawArray[i, j]);
                    GameObject go = GameObject.Instantiate(PrefabArray[index]);
                    go.transform.position = new Vector2(j, -i);
                }
            }
        }
    }

    static int GetPrefabIndex(int i)
    {
        if (i == 200)
            return 0;
        if (i == 201)
            return 1;

        for (int k = 0; k < 12; k++)
        {
            if (i == 100 + k) return k * 2;
            if (i == 300 + k) return k * 2 + 1;
        }

        return -1;

    }


    void DrawLevelMatrix()
    {
        for (int i = 0; i < levelmatrixX.GetLength(1); i++)
        {
            for (int j = 0; j < levelmatrixX.GetLength(0); j++)
            {
                GameObject curGO = GameObject.Instantiate(blackPrefab);
                curGO.name = (i * 1000 + j * 10).ToString();
                curGO.transform.position = new Vector2(levelmatrixX[j, i] + scaleX / 2 - 1, -levelmatrixY[j, i] - scaleY / 2 + 1);
                curGO.transform.localScale = new Vector2(scaleX, scaleY);

            }
        }

        try
        {
            for (int i = 0; i < pred.FinishedCovers.Length; i++) 
                Destroy(GameObject.Find(pred.FinishedCovers[i]));
        }
        catch
        {
            return;
        }
    }


    void CalcIndexes(int x, int y)
    {
        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        currentIndexX = scaleY * (int)(x / scaleY);
        currentIndexY = scaleX * (int)(y / scaleX);
    }



    public void CreateSessionMatrix(int x, int y)
    {
        CalcIndexes(x, y);
        int[,] sessionM = new int[scaleY, scaleX];
        string outtext = "";
        for (int j = 0; j < scaleY; j++)
        {
            sessionM[j,0]= baseMatrix[currentIndexX + j, currentIndexY];
            outtext += baseMatrix[currentIndexX + j, currentIndexY];
            for (int i = 1; i < scaleX; i++)
            {
                sessionM[j, i] = baseMatrix[j + currentIndexX, i + currentIndexY];
                outtext = outtext + "," + sessionM[j, i];
            }
            outtext += "\n";
        }

        pred.StartArray = Predator.ConvertToJaggedArray(sessionM);
        //File.WriteAllBytes(Application.persistentDataPath + "sesuew", System.Text.Encoding.ASCII.GetBytes(outtext));
        //File.WriteAllBytes("F:\\gas\\sesue.txt", System.Text.Encoding.ASCII.GetBytes(outtext));
    }

    public void CreateSessionBarrierMatrix(int x, int y)
    {
        CalcIndexes(x, y);
        int[,] sessionM = new int[scaleY, scaleX];
        string outtext = "";
        for (int j = 0; j < scaleY; j++)
        {
            if (baseBarrierMatrix[currentIndexX + j, currentIndexY] == 0)
                outtext += baseBarrierMatrix[currentIndexX + j, currentIndexY];
            else
                outtext += baseBarrierMatrix[currentIndexX + j, currentIndexY] + 100;
            for (int i = 1; i < scaleX; i++)
            {
                sessionM[j, i] = baseBarrierMatrix[j + currentIndexX, i + currentIndexY];
                if (sessionM[j, i] != 0) sessionM[j, i] += 100;
                outtext = outtext + "," + sessionM[j, i];
            }
            outtext += "\n";
        }

        pred.EnemyArray = Predator.ConvertToJaggedArray(sessionM);

        //File.WriteAllBytes(Application.persistentDataPath + "barrier", System.Text.Encoding.ASCII.GetBytes(outtext));
        //File.WriteAllBytes("F:\\gas\\sesue.txt", System.Text.Encoding.ASCII.GetBytes(outtext));
    }


    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Texter").GetComponent<TextMeshPro>().text = "Количество монет " + NumberAddMoves.ToString();
    }
}
