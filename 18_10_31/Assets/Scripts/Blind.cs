using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blind : MonoBehaviour
{
    public Image image;
    Color color;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        color = image.color;
        if (color.a > 0)
        {
            color.a-=0.01f;
            image.color = color;
        }
    }
}
