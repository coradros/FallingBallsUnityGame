using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class JoyMamager : MonoBehaviour
{

    private Vector3 offset, StartPosition;

    public bool r, l, u, d;

    // Start is called before the first frame update
    void Start()
    {
        r = false;
        l = false;
        u = false;
        d = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (math.abs(transform.localPosition.x) > math.abs(transform.localPosition.y))
        {
            u = false;
            d = false;

            if (transform.localPosition.x > 0)
            {
                r = true;
                l = false;
            }

            if (transform.localPosition.x < 0)
            {
                r = false;
                l = true;
            }

            if (transform.localPosition.x == 0)
            {
                r = false;
                l = false;
            }
        }
        else
        {
            r = false;
            l = false;

            if (transform.localPosition.y > 0)
            {
                u = true;
                d = false;
            }

            if (transform.localPosition.y < 0)
            {
                u = false;
                d = true;
            }

            if (transform.localPosition.y == 0)
            {
                u = false;
                d = false;
            }

        }

        Limits(-0.5f, 0.5f, -0.5f, 0.5f);
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        StartPosition = gameObject.transform.position;
    }


    private void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }

    private void OnMouseUp()
    {
        transform.localPosition = new Vector2(0, 0);
    }

    void Limits(float l, float r, float u, float d)
    {
        if (transform.localPosition.x < l) transform.localPosition = new Vector2(l, transform.localPosition.y);
        if (transform.localPosition.x > r) transform.localPosition = new Vector2(r, transform.localPosition.y);
        if (transform.localPosition.y > d) transform.localPosition = new Vector2(transform.localPosition.x, d);
        if (transform.localPosition.y < u) transform.localPosition = new Vector2(transform.localPosition.x, u);
    }

}
