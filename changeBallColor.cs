using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballColor : MonoBehaviour
{
    Color color1 = new Color(0.5f, 0.7f, 1.0f, 0.5f);
    Color color2 = new Color(0.8f, 0.6f, 0.9f, 0.5f);

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color1);
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color2);
    }
}