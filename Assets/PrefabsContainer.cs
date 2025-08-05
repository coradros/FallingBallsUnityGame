using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsContainer : MonoBehaviour
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


    public GameObject ff1;
    public GameObject ff2;
    public GameObject ff3;
    public GameObject ff4;
    public GameObject ff5;
    public GameObject ff6;
    public GameObject ff7;
    public GameObject ff8;
    public GameObject ff9;
    public GameObject ff10;
    public GameObject ff11;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button10;
    public GameObject button11;


    public GameObject barrier_l0;
    public GameObject barrier_s0;
    public GameObject barrier_l1;
    public GameObject barrier_s1;
    public GameObject barrier_l2;
    public GameObject barrier_s2;
    public GameObject barrier_l3;
    public GameObject barrier_s3;
    public GameObject barrier_l4;
    public GameObject barrier_s4;
    public GameObject barrier_l5;
    public GameObject barrier_s5;
    public GameObject barrier_l6;
    public GameObject barrier_s6;
    public GameObject barrier_l7;
    public GameObject barrier_s7;


    public GameObject winner;
    public GameObject looser;
    public GameObject bottom;
    public GameObject YesNoComplete;

    public GameObject bomb;
    public GameObject rocket;
    public GameObject catapult;
    public GameObject knight;

    public GameObject yellow;
    public GameObject green;
    public GameObject blue;
    public GameObject red;


    public List<GameObject> SquarePrefabs, FallPrefabs, ButtonPrefabs, BarrierPrefabs, BombPrefabs, KeyPrefabs;

    int globalLevel;

    [HideInInspector] public int[,] PaletteMatrix;



    public void StartPrefFill()
    {
        globalLevel = Basic.ReadLevel();

        var PaletteText = Resources.Load<TextAsset>("GameImages/" + globalLevel.ToString() + "/p");
        PaletteMatrix = Basic.List2Matrix(Basic.strArray(PaletteText));

        FillPrefabs();
        FillFallPrefabs();
        FillButtons();
        FillBarriers();
        FillBomb();
        FillKey();
    }

    public void FillPrefabs()
    {
        SquarePrefabs = new List<GameObject>();
        go1.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 1); SquarePrefabs.Add(go1);
        go2.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 2); SquarePrefabs.Add(go2);
        go3.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 3); SquarePrefabs.Add(go3);
        go4.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 4); SquarePrefabs.Add(go4);
        go5.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 5); SquarePrefabs.Add(go5);
        go6.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 6); SquarePrefabs.Add(go6);
        go7.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 7); SquarePrefabs.Add(go7);
        go8.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 8); SquarePrefabs.Add(go8);
        go9.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 9); SquarePrefabs.Add(go9);
        go10.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 10); SquarePrefabs.Add(go10);
    }
    public void FillFallPrefabs()
    {
        FallPrefabs = new List<GameObject>();
        ff1.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 1); FallPrefabs.Add(ff1);
        ff2.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 2); FallPrefabs.Add(ff2);
        ff3.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 3); FallPrefabs.Add(ff3);
        ff4.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 4); FallPrefabs.Add(ff4);
        ff5.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 5); FallPrefabs.Add(ff5);
        ff6.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 6); FallPrefabs.Add(ff6);
        ff7.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 7); FallPrefabs.Add(ff7);
        ff8.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 8); FallPrefabs.Add(ff8);
        ff9.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 9); FallPrefabs.Add(ff9);
        ff10.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 10); FallPrefabs.Add(ff10);
    }
    public void FillButtons()
    {
        ButtonPrefabs = new List<GameObject>();
        button2.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 1); ButtonPrefabs.Add(button2);
        button3.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 2); ButtonPrefabs.Add(button3);
        button4.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 3); ButtonPrefabs.Add(button4);
        button5.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 4); ButtonPrefabs.Add(button5);
        button6.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 5); ButtonPrefabs.Add(button6);
        button7.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 6); ButtonPrefabs.Add(button7);
        button8.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 7); ButtonPrefabs.Add(button8);
        button9.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 8); ButtonPrefabs.Add(button9);
        button10.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 9); ButtonPrefabs.Add(button10);
        button11.GetComponent<Renderer>().material.color = CreateNewColor(PaletteMatrix, 10); ButtonPrefabs.Add(button11);
    }
    public void FillBarriers()
    {
        BarrierPrefabs = new List<GameObject>();
        BarrierPrefabs.Add(barrier_l0);
        BarrierPrefabs.Add(barrier_s0);
        BarrierPrefabs.Add(barrier_l1);
        BarrierPrefabs.Add(barrier_s1);
        BarrierPrefabs.Add(barrier_l2);
        BarrierPrefabs.Add(barrier_s2);
        BarrierPrefabs.Add(barrier_l3);
        BarrierPrefabs.Add(barrier_s3);
        BarrierPrefabs.Add(barrier_l4);
        BarrierPrefabs.Add(barrier_s4);
        BarrierPrefabs.Add(barrier_l5);
        BarrierPrefabs.Add(barrier_s5);
        BarrierPrefabs.Add(barrier_l6);
        BarrierPrefabs.Add(barrier_s6);
        BarrierPrefabs.Add(barrier_l7);
        BarrierPrefabs.Add(barrier_s7);
    }

    public void FillBomb()
    {
        BombPrefabs = new List<GameObject>();
        BombPrefabs.Add(bomb);
        BombPrefabs.Add(rocket);
        BombPrefabs.Add(catapult);
        BombPrefabs.Add(knight);
    }


    public void FillKey()
    {
        KeyPrefabs = new List<GameObject>();
        KeyPrefabs.Add(yellow);
        KeyPrefabs.Add(green);
        KeyPrefabs.Add(blue);
        KeyPrefabs.Add(red);
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

}
