using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnding : MonoBehaviour {

    public GameObject gameDirector;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //사람들이 플레이어와 닿음
            gameDirector.GetComponent<GameDirector>().ExitCollisionEndingObject();
            Debug.Log("ExitCollisionEndingObject 호출");
        }
    }
}
