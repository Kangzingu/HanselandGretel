using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blind : MonoBehaviour
{
    public Image image;
    public GameDirector gameDirector;
    Color color;
    public bool init;
    bool isBright;
    bool isDark;
    bool gettingBright;
    bool gettingDark;
    bool isClicked;
    // Use this for initialization
    void Start()
    {
        init = false;
        isDark = false;
        isBright = false;
        gettingBright = false;
        gettingDark = false;
        isClicked = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            color = image.color;
            if (color.a > 0.5f)
            {
            isClicked = true;
                color.a = 0.5f;
                image.color = color;
            }
        }
        if (isClicked == true)
        {
            color = image.color;
            if (color.a < 1)
            {
                color.a += 0.01f;
                image.color = color;
            }
            else
            {
                isClicked = false;
            }
        }
        if (init == true)
        {
            color = image.color;
            if (color.a < 1)
            {
                color.a += 0.01f;
                image.color = color;
            }
            else
            {
                init = false;
                isDark = true;
            }
        }
        if (gameDirector.GetComponent<GameDirector>().isUnderLight == true && isDark == true)
        {
            gettingBright = true;
        }
        else if (gameDirector.GetComponent<GameDirector>().isUnderLight == false && isBright== true)
        {
            gettingDark = true;
        }
        if (gettingBright == true)
        {
            color = image.color;
            if (color.a > 0)
            {
                color.a -= 0.02f;
                image.color = color;
            }
            else//다 밝아지면
            {
                isBright = true;
                gettingBright = false;
                isDark = false;
                gettingDark = false;
            }
        }
        if (gettingDark == true)
        {
            color = image.color;
            if (color.a < 1)
            {
                color.a += 0.02f;
                image.color = color;
            }
            else
            {
                isBright = false;
                gettingBright = false;
                isDark = true;
                gettingDark = false;
            }
        }
        
    }
}
