using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector2 : MonoBehaviour {
    public int carNum;
    public float speed;
    public GameObject[] carPrefabLtoR = new GameObject[5];
    public GameObject[] carPrefabRtoL = new GameObject[5];
    int startZ;
    int endZ;
    // Use this for initialization
    void Start () {
        carNum = carPrefabLtoR.Length;
        startZ = -90;
        endZ = 130;
        speed = 1;
    }
	
	// Update is called once per frame
	void Update() { 
        for(int i = 0; i < carNum; i++)
        {
            carPrefabLtoR[i].transform.position += new Vector3(0, 0, speed);
            if (carPrefabLtoR[i].transform.position.z > endZ)
            {
                carPrefabLtoR[i].transform.position = new Vector3(carPrefabLtoR[i].transform.position.x,
                    carPrefabLtoR[i].transform.position.y,
                    startZ);
            }
            carPrefabRtoL[i].transform.position -= new Vector3(0, 0, speed);
            if (carPrefabRtoL[i].transform.position.z < startZ)
            {
                carPrefabRtoL[i].transform.position = new Vector3(carPrefabRtoL[i].transform.position.x,
                    carPrefabRtoL[i].transform.position.y,
                    endZ);
            }
        }

    }
}
