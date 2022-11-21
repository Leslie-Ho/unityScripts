using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToSpeed : MonoBehaviour
{
    float speed;
    Vector3 oldPosition;

    public Color[] colors;
    private TrailRenderer myTrail;

    public int currentIndex = 0;
    private int nextIndex;

    private float changeColourTime = 10.0f;

    private float timer = 0.0f;
    private float distCol = 0;

    Color lerpColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    Color updateLerpColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    void Start()
    {
        myTrail = GetComponentInChildren<TrailRenderer>();
        if (colors == null || colors.Length < 2)
            Debug.Log("Need to setup colors array in inspector");

        nextIndex = (currentIndex + 1) % colors.Length;
    }


    void Update()
    {
        speed = Vector3.Distance(oldPosition, transform.position) * 100f;
        oldPosition = transform.position;

        Debug.Log("Speed: " + speed.ToString("F2"));

        timer += Time.deltaTime;

        if(speed < 1)
        {
            changeColourTime = 10.0f;
        } else if (speed >=1 && speed < 5)
        {
            changeColourTime = 5.0f;
        } else if (speed >=5 && speed < 8)
        {
            changeColourTime = 3.0f;
        } else 
        {
            changeColourTime = 1.0f;
        }

        if (timer > changeColourTime)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            nextIndex = (currentIndex + 1) % colors.Length;
            timer = 0.0f;
        }
        lerpColor = Color.Lerp(colors[currentIndex], colors[nextIndex], timer / changeColourTime);

        if(tag == "closeDist")
        {
            distCol = 0.0f;
        } else if (tag == "medDist")
        {
            distCol = 0.5f;
        } else if (tag == "farDist")
        {
            distCol = 1.0f;
        }

        updateLerpColor = Color.Lerp(lerpColor, Color.black, distCol);
        GetComponent<Renderer>().material.SetColor("_Color", updateLerpColor);
        myTrail.material.color = updateLerpColor;

    }
}
