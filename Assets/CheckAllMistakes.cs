using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckAllMistakes : MonoBehaviour
{
    SessionElement SessElement;
    int OldNumberOfMoves;

    // Start is called before the first frame update
    void Start()
    {
        SessElement = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        SessElement.OldNumberOfMoves = SessElement.NumberOfMoves;
    }

    int count = 0;
    bool isStart = true;
    // Update is called once per frame
    void Update()
    {
        if (MovesChange(SessElement))
        {
            isStart = true;
        }

    }
    public static void FillEmptyCells(int[,] aMatrix, List<GameObject> aFallingPrefs, SessionElement aSe)
    {
        List<GameObject> lstFall = StaticClassGameTime.FallObjectsList();
        foreach (GameObject go in lstFall)
        {
            StaticClassGameTime.FillFallMatrix(go, aSe, go.GetComponent<Fall>().number);
        }

        for (int i = 0; i < aMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < aMatrix.GetLength(1); j++)
            {
                if (aMatrix[i, j] == 0)
                {
                    GameObject bar = StaticClassGameTime.FindBarrierbyIJ(j, i - 1);
                    if (bar != null)
                    {
                        GameObject go = GameObject.Instantiate(StaticClassGameTime.GetRandomFall(0, aFallingPrefs, aSe.FallsColorsNumber));
                        go.transform.position = new Vector2(j, -i);
                    }
                }
            }
        }
    }


    public static void RemoveOutsideObjects()
    {
        List<GameObject> AllFallObjects = StaticClassGameTime.FallObjectsList();
        foreach (GameObject fo in AllFallObjects)
        {
            if ((int)math.round(fo.transform.position.y) > 0 || (int)math.round(fo.transform.position.y) < -25) GameObject.Destroy(fo);
        }
    }

    public static bool MovesChange(SessionElement se)
    {
        if (se.NumberOfMoves == se.OldNumberOfMoves) return false;
        se.OldNumberOfMoves = se.NumberOfMoves;
        return true;
    }

    public static bool MovesChange(SessionElement se, ref int aOldNumberOfMoves)
    {
        if (se.NumberOfMoves == aOldNumberOfMoves) return false;
        aOldNumberOfMoves = se.NumberOfMoves;
        return true;
    }
}
