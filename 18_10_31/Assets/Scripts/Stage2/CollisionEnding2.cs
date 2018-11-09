using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnding2 : MonoBehaviour {

    public GameObject gameDirector2;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //end object와 플레이어와 닿음
            gameDirector2.GetComponent<GameDirector2>().CollisionEndingObject2();
            Debug.Log("CollisionEndingObject 호출");
        }
    }
}
