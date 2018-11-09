using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector2 : MonoBehaviour
{
    // Use this for initialization
    public GameObject[] stopObject = new GameObject[3];
    public bool crossState;
    private float changeTime = 5;
    private float countTime;
    void Start()
    {
        crossState = false;

        countTime = changeTime;
    }
    // Update is called once per frame
    void Update()
    {
        countTime -= Time.deltaTime;
        if (countTime < 0)//시간 바꼇졍
        {
            countTime = changeTime;
            if (crossState)
                crossState = false;
            else
                crossState = true;
        }
        if (crossState == true)
        {
            stopObject[0].GetComponent<Collider>().enabled = true;
            stopObject[1].GetComponent<Collider>().enabled = true;
            if (countTime < changeTime - 0.5f)
            {
                stopObject[2].GetComponent<Collider>().enabled = false;
                stopObject[3].GetComponent<Collider>().enabled = false;

            }
        }
        else
        {
            if (countTime < changeTime - 0.5f)
            {
                stopObject[0].GetComponent<Collider>().enabled = false;
                stopObject[1].GetComponent<Collider>().enabled = false;
            }
            stopObject[2].GetComponent<Collider>().enabled = true;
            stopObject[3].GetComponent<Collider>().enabled = true;
        }
    }
}