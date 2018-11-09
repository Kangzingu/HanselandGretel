using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControl : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public float rotSpeed = 3.0f;
    public Camera fpsCam;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        MoveCtrl();
        RotCtrl();
	}
    void MoveCtrl()
    {
        if (Input.GetKey(KeyCode.W))//앞
        {
            //GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * moveSpeed * Time.deltaTime);
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))//뒤
        {
            //GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * moveSpeed * Time.deltaTime);
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))//왼
        {
            //GetComponent<Rigidbody>().AddRelativeForce(Vector3.left * moveSpeed * Time.deltaTime);
            //this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))//오
        {
            //GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * moveSpeed * Time.deltaTime);
            //this.transform.Translate(Vector3.right* moveSpeed * Time.deltaTime);
        }
    }
    void RotCtrl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);//Y축 기준, 양옆으로 도는겅
        //양옆이니 this=>동그란 캐릭터를 회전
        fpsCam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);//X축 기준, 위아래로 도는겅
        //위아래니 카메라를 회전
    }
}
