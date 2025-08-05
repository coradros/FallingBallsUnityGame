using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Unity.VisualScripting;


public class ClickOnBlack : MonoBehaviour
{
    int globlev;
    public GameObject touch;

    Predator pred;

    // Start is called before the first frame update
    void Start()
    {
        pred = GameObject.Find("Predator").GetComponent<Predator>();

        globlev = pred.GlobalLevel;
        if (globlev == 1)
        {
            string[] deletedLevels = pred.FinishedCovers;

            if (deletedLevels.Length!=0)
            {
                if (deletedLevels.Length == 1)
                {
                    if (gameObject.name == "10")
                    {
                        GameObject go = GameObject.Instantiate(touch);
                        go.transform.position = transform.position;
                    }
                }
                if (deletedLevels.Length == 2)
                {
                    if (gameObject.name == "20")
                    {
                        GameObject go = GameObject.Instantiate(touch);
                        go.transform.position = transform.position;
                    }
                }
                if (deletedLevels.Length == 3)
                {
                    if (gameObject.name == "30")
                    {
                        GameObject go = GameObject.Instantiate(touch);
                        go.transform.position = transform.position;
                    }
                }
            }
            else
            {
                if (gameObject.name == "0")
                {
                    GameObject go = GameObject.Instantiate(touch);
                    go.transform.position = transform.position;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Vector2 thisPoint = gameObject.transform.position;
        GameObject.Find("BasicElement").GetComponent<Basic>().CreateSessionMatrix((int)thisPoint.y, (int)thisPoint.x);
        GameObject.Find("BasicElement").GetComponent<Basic>().CreateSessionBarrierMatrix((int)thisPoint.y, (int)thisPoint.x);

        pred.currentLevel = gameObject.name;

        StartCoroutine(WebAppBridge.PutPlayerData(pred));


        if (globlev == 1)
        {
            switch (gameObject.name)
            {
                case "0":
                    SceneManager.LoadScene("TrainingSession");
                    break;

                case "10":
                    SceneManager.LoadScene("TrainingSession");
                    break;

                case "20":
                    SceneManager.LoadScene("TrainingSession");
                    break;

                case "30":
                    SceneManager.LoadScene("TrainingSession");
                    break;

                default:
                    SceneManager.LoadScene("GameSession");
                    break;
            }

        }
    }
}
