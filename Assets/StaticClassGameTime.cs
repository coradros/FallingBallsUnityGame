using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticClassGameTime : MonoBehaviour
{
    public static GameObject FindGObyIJ(int i, int j)
    {
        List<GameObject> FallObjects = FallObjectsList();
        foreach (GameObject gob in FallObjects)
        {
            int curi = (int)math.round(gob.transform.position.x);
            int curj = -(int)math.round(gob.transform.position.y);
            if (curi == i && curj == j) return gob;
        }
        return null;
    }
    public static GameObject FindFall2BarrbyIJ(int i, int j)
    {
        List<GameObject> FallObjects = Fall2BarrObjectsList();
        foreach (GameObject gob in FallObjects)
        {
            int curi = (int)math.round(gob.transform.position.x);
            int curj = -(int)math.round(gob.transform.position.y);
            if (curi == i && curj == j) return gob;
        }
        return null;
    }
    public static GameObject FindBarrierbyIJ(int i, int j)
    {
        List<GameObject> FallObjects = BarrierObjectsList();
        foreach (GameObject gob in FallObjects)
        {
            int curi = (int)math.round(gob.transform.position.x);
            int curj = -(int)math.round(gob.transform.position.y);
            if (curi == i && curj == j) return gob;
        }
        return null;
    }
    public static GameObject FindFallbyIJ(int i, int j)
    {
        List<GameObject> FallObjects = FallObjectsList();
        foreach (GameObject gob in FallObjects)
        {
            int curi = (int)math.round(gob.transform.position.x);
            int curj = -(int)math.round(gob.transform.position.y);
            if (curi == i && curj == j) return gob;
        }
        return null;
    }

    public static List<GameObject> FallObjectsList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.GetComponent<Fall>() != null) FallObjects.Add(gob);
        }
        return FallObjects;
    }


    public static List<GameObject> PlayerList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.tag == "Player") FallObjects.Add(gob);
        }
        return FallObjects;
    }


    public static List<GameObject> FallObjectsListByNumber(int aNumber)
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (
                gob.GetComponent<Fall>() != null &&
                gob.GetComponent<Fall>().number == aNumber &&
                !gob.GetComponent<Fall>().isButton &&
                gob.transform.position.x >= 0 &&
                gob.transform.position.x <= 9
                ) FallObjects.Add(gob);
        }
        return FallObjects;
    }

    public static List<GameObject> FullLevelObjectsList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.transform.position.x >= 0 && gob.transform.position.x <= 9)
            {
                if (gob.GetComponent<Fall>() != null && !gob.GetComponent<Fall>().isButton) FallObjects.Add(gob);
                if (gob.GetComponent<Barriers>() != null) FallObjects.Add(gob);
                if (gob.GetComponent<Fly>() != null) FallObjects.Add(gob);
            }
        }
        return FallObjects;
    }
    public static List<GameObject> FullTriggerList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.transform.position.x >= 0 && gob.transform.position.x <= 9)
            {
                if (gob.GetComponent<FallTrigger>() != null) FallObjects.Add(gob);
                if (gob.GetComponent<SwitchTrigger>() != null) FallObjects.Add(gob);
            }
        }
        return FallObjects;
    }


    public static List<GameObject> BarrierObjectsList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.GetComponent<Barriers>() != null) FallObjects.Add(gob);
        }
        return FallObjects;
    }
    public static List<GameObject> EnemyObjectsList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.GetComponent<Barriers>() != null) FallObjects.Add(gob);
            if (gob.GetComponent<Fly>() != null) FallObjects.Add(gob);
        }
        return FallObjects;
    }
    public static GameObject GetFly()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.GetComponent<Fly>() != null) return gob;
        }
        return null;
    }


    public static List<GameObject> Fall2BarrObjectsList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.tag == "Fall" || gob.tag == "Barrier") FallObjects.Add(gob);
        }
        return FallObjects;
    }
    public static List<GameObject> BombObjectsList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.GetComponent<Bomb>() != null && !gob.GetComponent<Bomb>().isButton) FallObjects.Add(gob);
        }
        return FallObjects;
    }
    public static List<GameObject> TriggerObjectsList()
    {
        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        List<GameObject> FallObjects = new List<GameObject>();
        foreach (GameObject gob in allGameObjects)
        {
            if (gob.GetComponent<FallTrigger>() != null) FallObjects.Add(gob);
        }
        return FallObjects;
    }


    public static List<int> CheckEmpty(int[,] aSessionStartMatrix)
    {
        List<int> lst = new List<int>();
        for (int i = 0; i < aSessionStartMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < aSessionStartMatrix.GetLength(1); j++)
            {
                if (FindGObyIJ(j, i) == null)
                    lst.Add(j * 100 + i);
            }
        }
        return lst;
    }

    public static GameObject GetRandomFall(int aNumFall, List<GameObject> aFallinPrefs, int aLimit)
    {
        int k;
        if (aNumFall == 0)
        {
            k = UnityEngine.Random.Range(0, aLimit);
        }
        else
            k = aNumFall - 1;
        return aFallinPrefs[k];
    }

    public static bool MatrixComparison(int[,] aSessionStartMatrix, int[,] aSessionFallMatrix)
    {
        for (int i = 0; i < aSessionStartMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < aSessionStartMatrix.GetLength(1); j++)
            {
                if (aSessionStartMatrix[i, j] != aSessionFallMatrix[i, j]) return false;
            }
        }
        return true;
    }

    public static bool ForBomb(int i, int j, int[,] mtrx1, int[,] mtrx2)
    {
        if (mtrx1[i, j] != mtrx2[i, j]) return false;
        if (mtrx1[i, j + 1] != mtrx2[i, j + 1]) return false;
        if (mtrx1[i, j - 1] != mtrx2[i, j - 1]) return false;
        if (mtrx1[i + 1, j] != mtrx2[i + 1, j]) return false;
        if (mtrx1[i - 1, j] != mtrx2[i - 1, j]) return false;
        if (mtrx1[i + 1, j + 1] != mtrx2[i + 1, j + 1]) return false;
        if (mtrx1[i + 1, j - 1] != mtrx2[i + 1, j - 1]) return false;
        if (mtrx1[i - 1, j + 1] != mtrx2[i - 1, j + 1]) return false;
        if (mtrx1[i - 1, j - 1] != mtrx2[i - 1, j - 1]) return false;
        return true;
    }


    public static void HealthDecrease(GameObject go, int aCapacity)
    {
        int decrease = 0;
        if (aCapacity < 5) decrease = 1;
        else decrease = 2;
        if (go.GetComponent<Health>() != null) go.GetComponent<Health>().HealthPoint -= decrease;
    }

    public static void ExChange(int i, int j, List<GameObject> aFallinPrefs, int aCapacity, int aFallsColorsNumber)
    {
        GameObject go = FindGObyIJ(i, j);
        HealthDecrease(go, aCapacity);
        GameObject.Instantiate(GetRandomFall(0, aFallinPrefs, aFallsColorsNumber)).transform.position = new Vector2(i, -j);
    }
    public static void FallExChange(int i, int j, List<GameObject> aFallinPrefs, int aFallsColorsNumber)
    {
        GameObject go = FindFall2BarrbyIJ(i, j);
        if (go != null)
        {
            if (go.tag == "Barrier")
            {

            }
            HealthDecrease(go, 0);
        }
        GameObject.Instantiate(GetRandomFall(0, aFallinPrefs, aFallsColorsNumber)).transform.position = new Vector2(i, j);
    }
    public static void FallExCleare(int i, int j, List<GameObject> aFallinPrefs, int aCapacity)
    {
        GameObject go = FindFall2BarrbyIJ(i, j);
        if (go != null)
        {
            HealthDecrease(go, aCapacity);
        }
    }

    public static void BombInst(int i, int j, List<GameObject> aFallinPrefs, int aFallsColorsNumber)
    {
        ExChange(i, j + 1, aFallinPrefs, 0, aFallsColorsNumber);
        ExChange(i, j - 1, aFallinPrefs, 0, aFallsColorsNumber);
        ExChange(i + 1, j, aFallinPrefs, 0, aFallsColorsNumber);
        ExChange(i - 1, j, aFallinPrefs, 0, aFallsColorsNumber);
        ExChange(i + 1, j + 1, aFallinPrefs, 0, aFallsColorsNumber);
        ExChange(i + 1, j - 1, aFallinPrefs, 0, aFallsColorsNumber);
        ExChange(i - 1, j + 1, aFallinPrefs, 0, aFallsColorsNumber);
        ExChange(i - 1, j - 1, aFallinPrefs, 0, aFallsColorsNumber);
    }

    public static void BombExp(int i, int j, List<GameObject> aFallinPrefs, int[,] aMatrix, int aCapacity, int aFallsColorsNumber)
    {
        FallExCleare(i, j + 1, aFallinPrefs, aCapacity);
        FallExCleare(i, j - 1, aFallinPrefs, aCapacity);
        FallExCleare(i + 1, j, aFallinPrefs, aCapacity);
        FallExCleare(i - 1, j, aFallinPrefs, aCapacity);
        FallExCleare(i + 1, j + 1, aFallinPrefs, aCapacity);
        FallExCleare(i + 1, j - 1, aFallinPrefs, aCapacity);
        FallExCleare(i - 1, j + 1, aFallinPrefs, aCapacity);
        FallExCleare(i - 1, j - 1, aFallinPrefs, aCapacity);

        FallExCleare(i, j + 2, aFallinPrefs, aCapacity);
        FallExCleare(i, j - 2, aFallinPrefs, aCapacity);
        FallExCleare(i + 2, j, aFallinPrefs, aCapacity);
        FallExCleare(i - 2, j, aFallinPrefs, aCapacity);
        FallExCleare(i + 2, j + 2, aFallinPrefs, aCapacity);

        FallExCleare(i + 2, j - 2, aFallinPrefs, aCapacity);
        FallExCleare(i - 2, j + 2, aFallinPrefs, aCapacity);
        FallExCleare(i - 2, j - 2, aFallinPrefs, aCapacity);
        FallExCleare(i + 1, j + 2, aFallinPrefs, aCapacity);
        FallExCleare(i + 1, j - 2, aFallinPrefs, aCapacity);

        FallExCleare(i + 2, j + 1, aFallinPrefs, aCapacity);
        FallExCleare(i - 2, j + 1, aFallinPrefs, aCapacity);
        FallExCleare(i + 2, j - 1, aFallinPrefs, aCapacity);
        FallExCleare(i - 2, j - 1, aFallinPrefs, aCapacity);
        FallExCleare(i - 1, j + 2, aFallinPrefs, aCapacity);
        FallExCleare(i - 1, j - 2, aFallinPrefs, aCapacity);

        //FullFall(aMatrix, aFallinPrefs, aFallsColorsNumber);

    }

    public static void CatapultExp(int i, int j, List<GameObject> aFallinPrefs, int[,] aMatrix, int aCapacity, int aFallsColorsNumber)
    {
        FallExCleare(i, j, aFallinPrefs, aCapacity);
        FallExCleare(i, j + 1, aFallinPrefs, aCapacity);
        FallExCleare(i, j - 1, aFallinPrefs, aCapacity);
        FallExCleare(i + 1, j, aFallinPrefs, aCapacity);
        FallExCleare(i - 1, j, aFallinPrefs, aCapacity);
        FallExCleare(i + 1, j + 1, aFallinPrefs, aCapacity);
        FallExCleare(i + 1, j - 1, aFallinPrefs, aCapacity);
        FallExCleare(i - 1, j + 1, aFallinPrefs, aCapacity);
        FallExCleare(i - 1, j - 1, aFallinPrefs, aCapacity);


        //FullFall(aMatrix, aFallinPrefs, aFallsColorsNumber);

    }


    public static void RocketExp(int i, int j, List<GameObject> aFallinPrefs, int[,] aMatrix, int aCapacity, int aFallsColorsNumber)
    {
        for (int k = 0; k < aMatrix.GetLength(1); k++)
            FallExCleare(k, j, aFallinPrefs, aCapacity);
        for (int k = 0; k < aMatrix.GetLength(0); k++)
            FallExCleare(i, k, aFallinPrefs, aCapacity);

        //FullFall(aMatrix, aFallinPrefs, aFallsColorsNumber);
    }

    public static Vector2 RoundIntPosition(Vector2 aPosition)
    {
        int xpos = RoundIntPosition(aPosition.x);
        int ypos = RoundIntPosition(aPosition.y);
        return new Vector2(xpos, ypos);
    }

    public static int RoundIntPosition(float aPosition)
    {
        return (int)math.round(aPosition);
    }

    public static void FillFallMatrix(GameObject aGo, SessionElement se, int aNumber)
    {
        int i = (int)math.round(aGo.transform.position.x);
        int j = -(int)math.round(aGo.transform.position.y);
        if (i >= 0 && j >= 0
            && i < se.SessionFallMatrix.GetLength(1)
            && j < se.SessionFallMatrix.GetLength(0))
            se.SessionFallMatrix[j, i] = aNumber;
        else
            return;
    }

    public static void ChangeToRight(int i, int j, int aNumPrefab, List<GameObject> aFallinPrefs, int aLimit)
    {
        GameObject go = FindFallbyIJ(i, j);
        if (go != null)
        {
            Vector2 objPos = RoundIntPosition(go.transform.position);
            GameObject.Destroy(go);
            go = GameObject.Instantiate(GetRandomFall(aNumPrefab, aFallinPrefs, aLimit));
            go.transform.position = objPos;
        }
    }

    public static void FillFullMatrix(SessionElement se)
    {
        for (int i = 0; i < se.SessionStartMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < se.SessionStartMatrix.GetLength(1); j++)
            {
                GameObject go = FindFallbyIJ(j, i);
                if (go == null)
                {
                    go = GameObject.Instantiate(GetRandomFall(0, se.FallinPrefs, se.FallsColorsNumber));
                    go.transform.position = new Vector2(j, -i);
                }
                ChangeToRight(j, i, se.SessionStartMatrix[i, j], se.FallinPrefs, se.FallsColorsNumber);
            }
        }
    }

    public static void MagicBig(SessionElement se, int aj, int ai)
    {
        for (int i = ai - 2; i < ai + 2; i++)
        {
            for (int j = aj - 2; j < aj + 3; j++)
            {
                ChangeToRight(j, i, se.SessionStartMatrix[i, j], se.FallinPrefs, se.FallsColorsNumber);
            }
        }
    }

    public static void MagicSmall(SessionElement se, int aj, int ai)
    {
        for (int i = ai - 1; i < ai + 2; i++)
        {
            for (int j = aj - 1; j < aj + 2; j++)
            {
                ChangeToRight(j, i, se.SessionStartMatrix[i, j], se.FallinPrefs, se.FallsColorsNumber);
            }
        }
    }
    public static void MagicRow(SessionElement se, int ai)
    {
        for (int i = ai; i < ai + 1; i++)
        {
            for (int j = 0; j < se.SessionStartMatrix.GetLength(1); j++)
            {
                ChangeToRight(j, i, se.SessionStartMatrix[i, j], se.FallinPrefs, se.FallsColorsNumber);
            }
        }
    }

    public static void MagicColumn(SessionElement se, int aj)
    {
        for (int i = 0; i < se.SessionStartMatrix.GetLength(0); i++)
        {
            for (int j = aj; j < aj + 1; j++)
            {
                ChangeToRight(j, i, se.SessionStartMatrix[i, j], se.FallinPrefs, se.FallsColorsNumber);
            }
        }
    }

    public static void ChangeToNeed(SessionElement se, int aColNumber, GameObject aFall)
    {
        try
        {
            Vector2 tp = aFall.transform.position;
            GameObject.Destroy(aFall);
            GameObject go = GameObject.Instantiate(GetRandomFall(aColNumber, se.FallinPrefs, se.FallsColorsNumber));
            go.transform.position = tp;
        }
        catch
        {
            return;
        }
    }
    public static void ChangeToNeed(SessionElement se, int aColNumber, int i, int j)
    {
        try
        {
            GameObject destgo = FindFallbyIJ(i, j);
            if (destgo != null)
            {
                Vector2 tp = destgo.transform.position;
                GameObject.Destroy(destgo);
                GameObject go = GameObject.Instantiate(GetRandomFall(aColNumber, se.FallinPrefs, se.FallsColorsNumber));
                go.transform.position = tp;
            }
            else
            {
                Vector2 tp = new Vector2(i, -j);
                GameObject go = GameObject.Instantiate(GetRandomFall(aColNumber, se.FallinPrefs, se.FallsColorsNumber));
                go.transform.position = tp;
            }
        }
        catch
        {
            return;
        }
    }
    public static void ChangeToBomb(SessionElement se, GameObject aFall)
    {
        try
        {
            Vector2 tp = aFall.transform.position;
            GameObject.Destroy(aFall);
            GameObject go = GameObject.Instantiate(se.BombPrefabs[0]);
            go.transform.position = tp;
        }
        catch
        {
            return;
        }
    }
    public static void ChangeToRocket(SessionElement se, GameObject aFall)
    {
        try
        {
            Vector2 tp = aFall.transform.position;
            int capacity = aFall.GetComponent<Bomb>().Capacity;
            GameObject.Destroy(aFall);
            GameObject go = GameObject.Instantiate(se.BombPrefabs[1]);
            go.GetComponent<Bomb>().Capacity = capacity;
            go.transform.position = tp;
        }
        catch
        {
            return;
        }
    }
    public static void ChangeToCatapult(SessionElement se, GameObject aFall)
    {
        try
        {
            Vector2 tp = aFall.transform.position;
            int capacity = aFall.GetComponent<Bomb>().Capacity;
            GameObject.Destroy(aFall);
            GameObject go = GameObject.Instantiate(se.BombPrefabs[2]);
            go.GetComponent<Bomb>().Capacity = capacity;
            go.transform.position = tp;
        }
        catch
        {
            return;
        }
    }

    public static void FillFallWithBariiers(SessionElement se)
    {
        for (int i = 0; i < se.SessionStartMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < se.SessionStartMatrix.GetLength(1); j++)
            {

                if (FindBarrierbyIJ(i, j) == null)
                {
                    GameObject go = GameObject.Instantiate(GetRandomFall(0, se.FallinPrefs, se.FallsColorsNumber));
                    go.transform.position = new Vector2(i, -j);
                }
            }
        }
    }
    public static void FillFallWithoutBariiersByColor(SessionElement se, int aColNumber)
    {
        for (int i = 0; i < se.SessionStartMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < /*se.SessionStartMatrix.GetLength(1)*/5; j++)
            {
                GameObject destgo = FindFallbyIJ(i, j);
                if (destgo != null)
                {
                    Vector2 vec = destgo.transform.position;
                    GameObject.Destroy(destgo);
                    GameObject go = GameObject.Instantiate(GetRandomFall(aColNumber, se.FallinPrefs, se.FallsColorsNumber));
                    go.transform.position = vec;
                }
            }
        }
    }
    public static void ClearFallWithoutBariiersByColor(SessionElement se, int aColNumber)
    {
        for (int i = 0; i < se.SessionStartMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < se.SessionStartMatrix.GetLength(1); j++)
            {
                GameObject destgo = FindFallbyIJ(i, j);
                GameObject.Destroy(destgo);
            }
        }
    }

    public static void AnimeOfChange(GameObject aGo1, GameObject aGo2)
    {
        GameObject go1 = GameObject.Instantiate(aGo1);
        go1.transform.position = new Vector2(500, 500);
        go1.GetComponent<Collider2D>().enabled = false;
        go1.transform.position = aGo1.transform.position;
    }
}

public class InOut
{
    public int[,] StartArray;
    public int[,] EnemyArray;
    public int[,] SaveArray;
    public int GlobalLevel;
    public int Coins;
    public string[] FinishedCovers;
    public float PlayerLabirinth_X;
    public float PlayerLabirinth_Y;
    public int[] Artefacts;
    public int[] SmallImages;
    public float PlayerMap_X;
    public float PlayerMap_Y;
}

