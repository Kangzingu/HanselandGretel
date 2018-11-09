using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPeople : MonoBehaviour {

    // Use this for initialization
    public GameObject gameDirector;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //사람들이 플레이어와 닿음
            gameDirector.GetComponent<GameDirector>().CollisionPeople();
            Debug.Log("CollsionPeople 호출");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //사람이 플레이어와 닿음
            gameDirector.GetComponent<GameDirector>().ExitCollisionPeople();
            Debug.Log("ExitCollisionPeople 호출");
        }

    }
}
