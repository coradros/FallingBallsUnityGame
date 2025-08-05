using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadLabirinth : MonoBehaviour
{
    public GameObject wall;
    public GameObject BP;

    int globalLevel;

    int[,] LabArray;
    // Start is called before the first frame update
    void Start()
    {
        globalLevel = Basic.ReadLevel();

        var textBarrierFile = Resources.Load<TextAsset>("GameImages/" + globalLevel.ToString() + "/nl");
        LabArray = Basic.List2Matrix(Basic.strArray(textBarrierFile));

        DrawLabirinth(-4.3f, 9.5f);

        Saver.DrawLevelMatrix(BP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int[,] ReadArrayFromFile(string aFileName)
    {
        string[] lines = File.ReadAllLines(Application.persistentDataPath + aFileName);
        List<string[]> lst = Basic.strArray(lines);

        int[,] arr = Basic.List2Matrix(lst);

        return arr;
    }

    void DrawLabirinth(float dx, float dy)
    {
        for(int i=0;i<LabArray.GetLength(0);i++)
        {
            for(int j=0;j<LabArray.GetLength(1);j++)
            {
                if (LabArray[i, j] == 1)
                {
                    GameObject wl = GameObject.Instantiate(wall);
                    wl.transform.position = new Vector2(dx+j, dy-i);
                }
            }
        }
    }

}
