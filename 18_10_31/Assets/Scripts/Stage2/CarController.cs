using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject gameDirector;
    public GameObject startObject;
    public GameObject endObject;//차 도착지
    public GameObject stopObject;//횡단보도
    Vector3 startPoint;
    public float speed;
    bool crossState;//신호등 상태
    public bool isStop;
    bool isHitChild;
    //출발 - 도착시 출발지점으로 순간이동, 출발 - 도착 다시 반복
    public int dir;//x+-, z+-
                   //0 1 2 3
                   // Use this for initialization
    //소리 추가
    public AudioClip clark;
    AudioSource aud;

    void Start()
    {
        isHitChild = false;
        startPoint = this.transform.position;
        speed = 0.3f;
        isStop = false;
        if (dir == 0 || dir == 1)
            crossState = !gameDirector.GetComponent<GameDirector2>().crossState;
        else
            crossState = gameDirector.GetComponent<GameDirector2>().crossState;

        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHitChild == false)
        {
            if (dir == 0 || dir == 1)
                crossState = !gameDirector.GetComponent<GameDirector2>().crossState;
            else
                crossState = gameDirector.GetComponent<GameDirector2>().crossState;
            if (isStop == false)
            {
            }


            if (isStop == true)//지금 멈춰있는데
            {
                if (crossState == false)//사람이 안건너고 있다면
                {
                    isStop = false;//가라
                }
            }
            else if (isStop == false)//가라
            {

                switch (dir)
                {
                    case 0://x+
                           //this.GetComponent<Rigidbody>().AddForce(speed, 0, 0);
                        this.transform.position += new Vector3(speed, 0, 0);
                        break;
                    case 1://x-
                           //this.GetComponent<Rigidbody>().AddForce(-speed, 0, 0);
                        this.transform.position += new Vector3(-speed, 0, 0);
                        break;
                    case 2://z+
                           //this.GetComponent<Rigidbody>().AddForce(0, 0, speed);
                        this.transform.position += new Vector3(0, 0, speed);
                        break;
                    case 3://z-
                           //this.GetComponent<Rigidbody>().AddForce(0, 0, -speed);
                        this.transform.position += new Vector3(0, 0, -speed);
                        break;
                    default:
                        break;
                }

            }
        }
        else//isHitChild==true
        {

        }
    }
    private void OnCollisionEnter(Collision collision)//끝점 도착
    {
        if (collision.collider.tag == "BCar")
        {
            isStop = true;
        }
        if (collision.collider.tag == "Player")
        {
            isHitChild = true;
            ///////////////
            ///소리 플레이
            ///////////////
            ///
            this.aud.PlayOneShot(this.clark);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            isHitChild = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == endObject.GetComponent<Collider>())
        {//끝지점이면
            this.transform.position = startPoint;//다시
        }
        else if (collision.collider == stopObject.GetComponent<Collider>())
        {//횡단보도인데
            if (crossState == true)//사람이 건너고 있다면
            {
                isStop = true;//멈춰라
            }
        }
    }
}
