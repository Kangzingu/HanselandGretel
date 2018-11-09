using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //화면 변환시 사용


public class GameDirector2 : MonoBehaviour
{
    // Use this for initialization
    public GameObject[] stopObject = new GameObject[3];
    public bool crossState;
    private float changeTime = 5;
    private float countTime;

    //엔딩 제어
    public GameObject endingObject;
    bool isEnding;

    void Start()
    {
        crossState = false;
        countTime = changeTime;
        isEnding = false;
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
            if (countTime < changeTime - 1f)
            {
                stopObject[2].GetComponent<Collider>().enabled = false;
                stopObject[3].GetComponent<Collider>().enabled = false;

            }
        }
        else
        {
            if (countTime < changeTime - 1f)
            {
                stopObject[0].GetComponent<Collider>().enabled = false;
                stopObject[1].GetComponent<Collider>().enabled = false;
            }
            stopObject[2].GetComponent<Collider>().enabled = true;
            stopObject[3].GetComponent<Collider>().enabled = true;
        }

        /*
         * ending 제어
         */
        if (isEnding == true)
        {
            Debug.Log("엔딩");
            //씬 전환->홈으로
            SceneManager.LoadScene("Menu 3D");


        }

    }
    public void CollisionEndingObject2()
    {
        Debug.Log("엔딩입니당");
        isEnding = true;
    }


}