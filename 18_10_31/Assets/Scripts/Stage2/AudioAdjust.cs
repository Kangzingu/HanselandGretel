using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAdjust : MonoBehaviour {

    public GameObject Player;
    bool startTutorial;

    public AudioClip Tutorial;
    AudioSource aud;
    

	// Use this for initialization
	void Start () {
        startTutorial = true;
        this.aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //들어가자마자 바로 튜토리얼 재생.
        if (startTutorial == true)
        {
            //tutorial audio 재생
            this.aud.PlayOneShot(this.Tutorial);
            startTutorial = false;
        }
        



	}
}
