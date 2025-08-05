using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    int[,] PuzzleMatrix;
    int globalLevel;
    public GameObject PuzzleElement;
    List<GameObject> PuzzlesList;

    // Start is called before the first frame update
    void Start()
    {
        globalLevel =Basic.ReadLevel();

        var PaletteText = Resources.Load<TextAsset>("GameImages/" + globalLevel.ToString()+"/coors");
        PuzzleMatrix = Basic.List2Matrix(Basic.strArray(PaletteText));

        CreatePuzzleImages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject CreatePuzzle(int aNumber, int[,] aMatrix, GameObject aPrefab, int aLevel)
    {
        GameObject go = GameObject.Instantiate(aPrefab);
        string path = "GameImages/" + aLevel.ToString() + "/" + aNumber;
        Sprite sprt = Resources.Load<Sprite>(path);
        go.GetComponent<SpriteRenderer>().sprite = sprt;
        go.transform.position = new Vector2(-5, aNumber * -8);
        Small_Image si = go.GetComponent<Small_Image>();
        if (si != null)
        {
            si.fx = aMatrix[aNumber - 1, 0];
            si.fy = aMatrix[aNumber - 1, 1];
            si.NumberOfImage = aNumber;
        }
        return go;
    }

    void CreatePuzzleImages()
    {
        PuzzlesList = new List<GameObject>();
        for(int i=0;i<PuzzleMatrix.GetLength(0);i++)
        {
            PuzzlesList.Add(CreatePuzzle(i+1, PuzzleMatrix, PuzzleElement, globalLevel));
        }
    }
}
