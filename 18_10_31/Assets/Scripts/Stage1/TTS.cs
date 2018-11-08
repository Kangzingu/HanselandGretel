using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpeechLib;

public class TTS : MonoBehaviour {

    public UnityEngine.UI.Text txt;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonPress();
        }

    }

    public void ButtonPress()
    {
        SpVoice voice;
        voice = new SpVoice();
        voice.Speak("Hello.");
        voice.Speak(txt.text);



    }

}
