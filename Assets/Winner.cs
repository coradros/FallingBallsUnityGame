using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    public bool isWinner;

    public GameObject loosePref;

    // Start is called before the first frame update
    void Start()
    {

    }

    float time = 0, delay = 1;
    bool isContinue=true;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > delay&&isContinue)
        {
            if (isWinner)
            {
                SceneManager.LoadScene("SelectSession");
                GameObject.Destroy(gameObject);
            }
            else
            {
                isContinue = false;
                GameObject.Instantiate(loosePref).transform.position = new Vector2(5f, -8f);
                GameObject.Destroy(gameObject);
            }

        }
    }
}
