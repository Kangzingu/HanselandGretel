using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAdjust : MonoBehaviour {

    public GameObject Player;
    bool startTutorial;

    public AudioClip Tutorial;
    public AudioClip subway;
    public AudioClip afterSubway;
    AudioSource aud;
    bool hereSubway;
    bool nosubwayMusic;

	// Use this for initialization
	void Start () {
        startTutorial = true;
        this.aud = GetComponent<AudioSource>();
        hereSubway = true;
        nosubwayMusic = false;
    }
	
	// Update is called once per frame
	void Update () {

        //들어가자마자 바로 튜토리얼 재생.
        if (startTutorial == true)
        {
            //tutorial audio 재생
            Debug.Log("tutorial 재생");
            this.aud.PlayOneShot(this.Tutorial);
            startTutorial = false;
        }

        if(hereSubway)
            hereSubway=musicChange();

        if (hereSubway)
        {
            Debug.Log("subway음악 재생");
            if (!this.aud.isPlaying)
            {
                this.aud.PlayOneShot(this.subway);
            }
 
        }
        else
        {
            if (nosubwayMusic)
            {
                this.aud.Stop();
                nosubwayMusic = false;
            }

            Debug.Log("시끌시끌 소리 재생");
            if (!this.aud.isPlaying)
            {
                this.aud.PlayOneShot(afterSubway);
            }
           
        }

    }
    public bool musicChange()
    {
        Transform player;

        player = Player.transform;
        Vector3 flag = new Vector3((float)-14.78, (float)7.7, (float)0.168);
        float distance = Vector3.Distance(player.position, flag);

        if (distance <= 6.0f)
        {
            return false;
        }
        else
        {
            nosubwayMusic = true;
            return true;

        }
    }
}
