using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAdjust2 : MonoBehaviour {

    public GameObject Player;
    bool startTutorial;
    bool startTutorial2;


    public AudioClip Tutorial;
    public AudioClip Tutorial2;
    public AudioClip streetLamp;

    AudioSource aud;

    void Start () {
        startTutorial = true;
        startTutorial2 = false;
        this.aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (startTutorial&&!aud.isPlaying)
        {
            Debug.Log("tutorial 재생");
            this.aud.PlayOneShot(this.Tutorial);
            startTutorial = false;
            startTutorial2 = true;
        }
        if (startTutorial2 && !aud.isPlaying)
        {
            this.aud.PlayOneShot(this.Tutorial2);
            startTutorial2 = false;
        }
	}
}
