using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnding : MonoBehaviour {

    public GameObject gameDirector;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //end object와 플레이어와 닿음
            gameDirector.GetComponent<GameDirector>().CollisionEndingObject();
            Debug.Log("CollisionEndingObject 호출");
        }
    }
}
