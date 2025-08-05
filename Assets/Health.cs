using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HealthPoint;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoint < 0) HealthPoint = 0;

        if (HealthPoint <= 0)
        {
            GameObject exp=GameObject.Instantiate(explosion);
            exp.transform.position=transform.position;
            GameObject.Destroy(gameObject);
        }
    }
}
