using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //화면 변환시 사용

public class GameDirector : MonoBehaviour {
    // Use this for initialization
    
    public GameObject door;
    bool isDoorStart;
    bool isOpened;
    int rotateCount;

    public GameObject mChild;
    bool isChildStart;

    public GameObject mMotorCycle;
    bool isMotorCycleStart;
    bool isMotorCycle;

    public GameObject mCar;
    bool isCarStart;

    public GameObject mPeople;
    bool isPeoplesStart;
    bool isPeopleTurnStart;
    float turnValue;

    public GameObject mPlayer;

    //Light 제어
    public Transform mPlayer_position;
    public Transform light_position;
    public Light light1;
    public Light light2;
    public Light light3;
    public Light light4;
    public Light light5;
    public Light light6;
    public Light light7;
    public Light light8;
    public Light light9;

    public Light light10;
    public Light light11;

    public Light light12;
    public Light light13;
    public Light light14;


    float distance;


    public AudioClip childLaugh;
    public AudioClip autoBike;
    public AudioClip bikeBell;
    AudioSource aud;

    //오토바이 객체 삭제 제어
    public GameObject flag_box;
    bool isconflict;

    //엔딩 제어
    public GameObject endingObject;
    bool isEnding;

    //시야 제어
    public bool isUnderLight;

    void Start () {
        isUnderLight = false;
        isOpened = false;
        isDoorStart = false;
        rotateCount = 0;
        turnValue= 90.0f;
        //door 제어

        isChildStart = false;
        isCarStart = false;
        isPeoplesStart = false;
        isPeopleTurnStart = false;

        //Audio
        this.aud = GetComponent<AudioSource>();

        //오토바이 객체 삭제 제어
        isconflict = false;

        //엔딩 제어
        isEnding = false;

        //오토바이 삭제 에러
        isMotorCycle = false;
    }
    // Update is called once per frame
    void Update () {
        if (isDoorStart == true)//문 열기 시작
        {
            Debug.Log(rotateCount);
            if (rotateCount > 30)//90도 이상 열렸다면
            {
                //회전 멈추고
                Debug.Log("child뛰기시작");
                isDoorStart = false;//문 그만 작동
                isOpened = true;//다 열렸다!
            }
            else//아직 다 안열렸다면
            {
                door.transform.Rotate(new Vector3(0, -3, 0));//조금씩 열자
                rotateCount++;
            }

            if (isOpened == true)//만약 다 열렸다면
            {
                //Audio
                this.aud.PlayOneShot(this.childLaugh);
                //애기 뛰어라
                this.ChildRun();     
            }

        }
        if (isChildStart == true)//애기 뛰는거 시작
        {
            //mChild.transform.Translate(0.1f, 0, 0);
            //mChild.GetComponent<Rigidbody>().AddForce(10,0,0);
            //isChildStart = false;
            mChild.GetComponent<Animator>().SetFloat("h", 1.0f);
        }
        if (isMotorCycleStart == true&&isconflict==false)//오토바이 출발
        {
            mMotorCycle.transform.Translate(0, -0.1f, 0f);
        }
        if (isCarStart == true)//차 출발
        {
            //mCar.transform.Translate(0, 0, 0.25f);
        }
        if (isPeoplesStart == true)//아이 출발
        {
            mPeople.transform.Translate(-0.03f,0,0);
        }
        if (isPeopleTurnStart == true)//학생들이 한번만 돈다
        {
            turnValue += -0.5f;
            mPeople.transform.Rotate(0, -0.5f, 0);
            //한번만 돌게 한다.
            if (turnValue < 0) {
                isPeopleTurnStart = false;
            }
            
        }

        /*
        * 가로등 제어
        */

        //light와 플레이어의 거리 비교

        LightOn_Off(mPlayer_position, light_position, light1);
        LightOn_Off(mPlayer_position, light_position, light2);
        LightOn_Off(mPlayer_position, light_position, light3);
        LightOn_Off(mPlayer_position, light_position, light4);
        LightOn_Off(mPlayer_position, light_position, light5);
        LightOn_Off(mPlayer_position, light_position, light6);
        LightOn_Off(mPlayer_position, light_position, light7);
        LightOn_Off(mPlayer_position, light_position, light8);
        LightOn_Off(mPlayer_position, light_position, light9);
        LightOn_Off(mPlayer_position, light_position, light10);
        LightOn_Off(mPlayer_position, light_position, light11);
        LightOn_Off(mPlayer_position, light_position, light12);
        LightOn_Off(mPlayer_position, light_position, light13);
        LightOn_Off(mPlayer_position, light_position, light14);
        if (light1.enabled || light2.enabled || light3.enabled ||
            light4.enabled || light5.enabled || light6.enabled ||
            light7.enabled || light8.enabled || light9.enabled ||
            light10.enabled || light11.enabled || light12.enabled ||
            light13.enabled || light14.enabled)
        {
            Debug.Log("dldld");
            isUnderLight = true;
        }
        else
        {
            isUnderLight = false;
        }
            /*
             * 오토바이 객체 삭제 제어
             */
            if (!isMotorCycle)
        {
            isconflict = deleteMotoCycle();
        }
        
        if (isconflict == true)
        {
            Debug.Log("삭제 고고");
            Destroy(mMotorCycle);
            isMotorCycle = true;
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
    public void Stage1Clear()
    {
        Debug.Log("Stage1Clear");
    }
    public void Stage2Clear()
    {
        Debug.Log("Stage2Clear");
        //문돌리기 시작
        this.DoorRotate();
    }
    public void Stage3Clear()
    {
        Debug.Log("Stage3Clear");
        isChildStart = false;//애기 그만움직이게
        this.MotorCycleStart();//오토바이 출발

    }
    public void Stage4Clear()
    {
        Debug.Log("Stage4Clear");
        //this.CarStart();
        //차가 앞에서 출발함
        
    }
    public void Stage5Clear()
    {
        Debug.Log("Stage5Clear");
        this.ChildsStart();
    }
    public void Stage6Clear()
    {
        Debug.Log("Stage6Clear");
        this.ChildTurnStart();
    }

    public void TrashCollide()
    {
        Debug.Log("TrashCollide");
    }                                 
    public void DoorRotate()
    {
        isDoorStart = true;//문 열자
    }
    public void ChildRun()
    {
        mChild.GetComponent<Animator>().SetBool("isChildStart", true);
        isChildStart = true;//애기 뛰게 하자
    }
    public void MotorCycleStart()
    {
        mMotorCycle.transform.position = new Vector3(18, -0.5f,5);
        isMotorCycleStart = true;
        //Audio
        this.aud.PlayOneShot(this.autoBike);
    }
    public void CarStart()
    {
        isCarStart = true;//차를 움직인다.
    }
    public void ChildsStart()
    {
        isPeoplesStart = true;//아이들을 움직인다.
    }
    public void ChildTurnStart()
    {
        this.isPeopleTurnStart = true;//학생들이 돌아서 나가도록 한다.
    }
    public void DestroyChild()
    {
        Debug.Log("DestroyChild");

        Destroy(mChild);//아이를 없앤다
        this.isChildStart = false;
    }
    public void CollsionChild()
    {
        Debug.Log("아이 닿음");
        mChild.GetComponent<Animator>().SetFloat("h", 0.0f);
        isChildStart = false;
    }
    public void CollisionMotorCycle()
    {
        Debug.Log("오토바이 닿음");
        //Audio
        this.aud.PlayOneShot(this.bikeBell);
        isMotorCycleStart = false;
    }
    public void ExitCollisionMotorCycle()
    {
        isMotorCycleStart = true;
        //Audio
        this.aud.PlayOneShot(this.autoBike);
    }
    public void CollisionCar()
    {
        Debug.Log("차 닿음");
        isCarStart = false;
    }
    public void ExitCollisionCar()
    {
        isCarStart = true;
        this.aud.PlayOneShot(this.autoBike);
    }
    public void DestroyStudents()
    {
        Destroy(mPeople);
    }

    public void LightOn_Off(Transform player_pos, Transform light_pos, Light light)
    {
        player_pos = mPlayer.transform;
        light_pos = light.transform;
        distance = Vector3.Distance(light_pos.position, player_pos.position);
        if (distance <= 5.0f)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }

    bool deleteMotoCycle()
    {
        Transform motoCycle_position;
        Transform flag_box_position;

        motoCycle_position = mMotorCycle.transform;
        flag_box_position = flag_box.transform;
        distance = Vector3.Distance(motoCycle_position.position, flag_box_position.position);

        if (distance <= 5.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void CollisionPeople()
    {
        Debug.Log("학생들 닿음");
        isPeoplesStart = false;
    }

    public void ExitCollisionPeople()
    {
        Debug.Log("학생들이랑 떨어졌어요!");
        isPeoplesStart = true;
        mPeople.transform.Translate(-0.03f, 0, 0);

    }


    public void ExitCollisionChild()
    {
        isChildStart = true;

    }

    public void CollisionEndingObject()
    {
        Debug.Log("엔딩입니당");
        isEnding = true;

    }


}
