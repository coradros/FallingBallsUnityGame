using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;



public class ButtonClick : MonoBehaviour
{
    public TextMeshPro tmp;
    string curtext;
    public bool isLevelButton = false;
    public int variant = 0;
    public GameObject Work;
    public GameObject InstPrefab;

    Predator pred;

    // Start is called before the first frame update
    void Start()
    {
        curtext = tmp.text;
        pred = GameObject.Find("Predator").GetComponent<Predator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelButton) tmp.text = curtext + "\n" + pred.GlobalLevel.ToString();
    }

    private void OnMouseDown()
    {
        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * 1.2f, gameObject.transform.localScale.y * 1.2f);
    }

    private void OnMouseUp()
    {
        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x / 1.2f, gameObject.transform.localScale.y / 1.2f);
        if (variant == 0) { BeginScene.NextLevel(); SceneManager.LoadScene("SelectSession"); }
        if (variant == 1) isYes();
        if (variant == 2) isNo();
        if (variant == 3) GameObject.Instantiate(InstPrefab);
        if (variant == 4) SceneManager.LoadScene("BeginScene");
        if (variant == 5) Application.Quit();
        if (variant == 6) isYesMoves();
        if (variant == 7) isNoMoves();
        if (variant == 8) isYesComplete();
        if (variant == 9) isNoComplete();
        if (variant == 10) SceneManager.LoadScene("LabirinthSecondScene");
        if (variant == 11) SceneManager.LoadScene("SelectSession");
        if (variant == 12) SceneManager.LoadScene("MapSession");

    }


    void isNo()
    {
        pred.Clear();
        StartCoroutine(WebAppBridge.PutPlayerData(pred));
        GameObject.Destroy(Work);
    }

    void isYes()
    {
        GameObject.Destroy(Work);
    }

    void isNoMoves()
    {
        SceneManager.LoadScene("SelectSession");
        GameObject.Destroy(gameObject);
    }

    void isYesMoves()
    {
        SessionElement se = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        if (se.NumberAddMoves > 0)
        {
            se.NumberEqAdd();
            se.isOnce = true;
            se.isCanTouch = true;
            GameObject par = gameObject.transform.parent.GameObject();
            GameObject.Destroy(par);
        }
        else
        {
            SceneManager.LoadScene("SelectSession");
            GameObject.Destroy(gameObject);
        }
    }

    void isYesComplete()
    {
        SessionElement se = GameObject.Find("SessionElement").GetComponent<SessionElement>();
        List<GameObject> lst = StaticClassGameTime.EnemyObjectsList();
        if (se.NumberAddMoves >=100&&lst.Count==0)
        {
            se.NumberAddMoves -= 100;
            //se.isOpenFullMatrix = true;
            StaticClassGameTime.FillFullMatrix(se);
            GameObject par = gameObject.transform.parent.GameObject();
            GameObject.Destroy(par);
        }
    }

        void isNoComplete()
    {
        GameObject par = gameObject.transform.parent.GameObject();
        GameObject.Destroy(par);
    }

}
