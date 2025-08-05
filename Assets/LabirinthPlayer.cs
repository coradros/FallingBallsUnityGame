using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabirinthPlayer : MonoBehaviour
{
    JoyMamager JM, SC;

    GameObject Joy, Sca;

    public Camera MC;

    public float Delta = 10f;

    public bool isTide = false;

    float dx = 1.8f, dy = -4;

    // Start is called before the first frame update
    void Start()
    {
        Joy = GameObject.Find("Joystick");
        JM = Joy.transform.GetChild(0).gameObject.GetComponent<JoyMamager>();

        if (isTide)
        {
            Sca = GameObject.Find("Scaler");
            SC = Sca.transform.GetChild(0).gameObject.GetComponent<JoyMamager>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTide) Limits(-4.4f, 4.4f, -9.4f, 9.4f);
        ManagerOfMove(JM.r, JM.l, JM.u, JM.d, Delta);

        if (isTide)
        {
            Joy.transform.position = new Vector2(transform.position.x + dx * MC.orthographicSize / 5, transform.position.y + dy * MC.orthographicSize / 5);
            Joy.transform.localScale = new Vector2(MC.orthographicSize / 5, MC.orthographicSize / 5);


            Sca.transform.position = new Vector2(transform.position.x + dx * MC.orthographicSize / 5, transform.position.y + dy * MC.orthographicSize / 5 + 2 * MC.orthographicSize / 5);
            ManagerOfScale(SC.u, SC.d, 0.02f);
            Sca.transform.localScale = new Vector2(MC.orthographicSize / 5, MC.orthographicSize / 5);
        }

    }

    public void ManagerOfMove(bool r, bool l, bool u, bool d, float aDelta)
    {
        if (r) { gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 2, ForceMode2D.Force); return; }
        if (l) { gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -2, ForceMode2D.Force); return; }
        if (u) { gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 2, ForceMode2D.Force); return; }
        if (d) { gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * -2, ForceMode2D.Force); return; }
    }

    public void ManagerOfScale(bool u, bool d, float aDelta)
    {
        if (u) { MC.orthographicSize += aDelta; return; }
        if (d) { MC.orthographicSize -= aDelta; return; }
        //if (MC.orthographicSize > 10) MC.orthographicSize = 10;
        //if (MC.orthographicSize < 2) MC.orthographicSize = 2;
    }

    void Limits(float l, float r, float u, float d)
    {
        if (transform.position.x < l) transform.position = new Vector2(l, transform.position.y);
        if (transform.position.x > r) transform.position = new Vector2(r, transform.position.y);
        if (transform.position.y > d) transform.position = new Vector2(transform.position.x, d);
        if (transform.position.y < u) transform.position = new Vector2(transform.position.x, u);
    }

    private void OnMouseUp()
    {
        SceneManager.LoadScene("SelectSession");
    }
}
