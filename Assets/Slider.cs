using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;

    public int Capacity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ViewCapacity(Capacity);
    }

    public void ViewCapacity(int aCapacity)
    {
        if (aCapacity == 0)
        {
            s1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s3.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s4.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s5.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (aCapacity == 1)
        {
            s1.GetComponent<SpriteRenderer>().sortingOrder = 9;
            s2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s3.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s4.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s5.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (aCapacity == 2)
        {
            s1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s2.GetComponent<SpriteRenderer>().sortingOrder = 9;
            s3.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s4.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s5.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (aCapacity == 3)
        {
            s1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s3.GetComponent<SpriteRenderer>().sortingOrder = 9;
            s4.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s5.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (aCapacity == 4)
        {
            s1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s3.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s4.GetComponent<SpriteRenderer>().sortingOrder = 9;
            s5.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (aCapacity == 5)
        {
            s1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s3.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s4.GetComponent<SpriteRenderer>().sortingOrder = 0;
            s5.GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
    }
}
