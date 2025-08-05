using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{

    public long UserId { get; set; }
    public int[][] StartArray { get; set; }
    public int[][] EnemyArray { get; set; }
    public int[][] SaveArray { get; set; }
    public int GlobalLevel { get; set; }
    public int Coins { get; set; }
    public string[] FinishedCovers { get; set; }
    public float PlayerLabyrinthX { get; set; }
    public float PlayerLabyrinthY { get; set; }
    public int[] Artefacts { get; set; }
    public int[] SmallImages { get; set; }
    public float PlayerMapX { get; set; }
    public float PlayerMapY { get; set; }
    public string currentLevel { get; set; }


    public static int[][] ConvertToJaggedArray(int[,] array2D)
    {
        int rows = array2D.GetLength(0);
        int cols = array2D.GetLength(1);

        int[][] jaggedArray = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            jaggedArray[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                jaggedArray[i][j] = array2D[i, j];
            }
        }

        return jaggedArray;
    }

    public static int[,] ConvertTo2DArray(int[][] jaggedArray)
    {
        if (jaggedArray == null || jaggedArray.Length == 0)
            throw new ArgumentException("Jagged array is null or empty.");

        int rows = jaggedArray.Length;
        int cols = jaggedArray[0].Length;

        // Проверка на прямоугольность (все строки одинаковой длины)
        for (int i = 1; i < rows; i++)
        {
            if (jaggedArray[i].Length != cols)
                throw new ArgumentException("Jagged array is not rectangular.");
        }

        int[,] array2D = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array2D[i, j] = jaggedArray[i][j];
            }
        }

        return array2D;
    }

    public static string[] AddToArray(string[] original, string newItem)
    {
        string[] newArray = new string[original.Length + 1];
        for (int i = 0; i < original.Length; i++)
        {
            newArray[i] = original[i];
        }
        newArray[original.Length] = newItem;
        return newArray;
    }

    public void Clear()
    {
        StartArray = null;
        EnemyArray = null;
        SaveArray = null;
        GlobalLevel = 0;
        Coins = 0;
        FinishedCovers = null;
        PlayerLabyrinthX = 0;
        PlayerLabyrinthY = 0;
        Artefacts = null;
        SmallImages = null;
        PlayerMapX = 0;
        PlayerMapY = 0;
        currentLevel = "";
    }

    public void ForPredator(ForPredator aPred)
    {
        UserId = aPred.UserId;
        StartArray = aPred.StartArray;
        EnemyArray = aPred.EnemyArray;
        SaveArray = aPred.SaveArray;
        GlobalLevel = aPred.GlobalLevel;
        Coins = aPred.Coins;
        FinishedCovers = aPred.FinishedCovers;
        PlayerLabyrinthX = aPred.PlayerLabyrinthX;
        PlayerLabyrinthY = aPred.PlayerLabyrinthY;
        Artefacts = aPred.Artefacts;
        SmallImages = aPred.SmallImages;
        PlayerMapX = aPred.PlayerMapX;
        PlayerMapY = aPred.PlayerMapY;
        currentLevel = aPred.currentLevel;
    }

}

public class ForPredator
{
    public ForPredator() { }
    public ForPredator(Predator aPred)
    {
        UserId = aPred.UserId;
        StartArray = aPred.StartArray;
        EnemyArray = aPred.EnemyArray;
        SaveArray = aPred.SaveArray;
        GlobalLevel = aPred.GlobalLevel;
        Coins = aPred.Coins;
        FinishedCovers = aPred.FinishedCovers;
        PlayerLabyrinthX = aPred.PlayerLabyrinthX;
        PlayerLabyrinthY = aPred.PlayerLabyrinthY;
        Artefacts = aPred.Artefacts;
        SmallImages = aPred.SmallImages;
        PlayerMapX = aPred.PlayerMapX;
        PlayerMapY = aPred.PlayerMapY;
        currentLevel = aPred.currentLevel;
    }

    private int[][] _matrix;
    private int[] _matrix1;
    private string[] _str1;
    private int _myValue;
    private string s;


    public long UserId { get; set; }
    public int[][] StartArray
    {
        get => _matrix;
        set => _matrix = value ?? new int[0][];
    }
    public int[][] EnemyArray
    {
        get => _matrix;
        set => _matrix = value ?? new int[0][];
    }
    public int[][] SaveArray
    {
        get => _matrix;
        set => _matrix = value ?? new int[0][];
    }
    public int GlobalLevel
    {
        get => _myValue;
        set => _myValue = (value == 0) ? 1 : value;
    }
    public int Coins { get; set; }
    public string[] FinishedCovers
    {
        get => _str1;
        set => _str1 = value ?? new string[0];
    }
    public float PlayerLabyrinthX { get; set; }
    public float PlayerLabyrinthY { get; set; }
    public int[] Artefacts
    {
        get => _matrix1;
        set => _matrix1 = value ?? new int[0];
    }
    public int[] SmallImages
    {
        get => _matrix1;
        set => _matrix1 = value ?? new int[0];
    }
    public float PlayerMapX { get; set; }
    public float PlayerMapY { get; set; }

    public string currentLevel
    {
        get => s;
        set => s = value ?? "";
    }

}
