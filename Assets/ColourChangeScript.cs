using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Windows.Speech;

public class ColourChangeScript : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public Renderer _renderer;
    public GameObject light;
    public GameObject sun;

    private void Start()
    {
        

        actions.Add("white", white);
        actions.Add("red", red);
        actions.Add("green", green);
        actions.Add("blue", blue);

        actions.Add("light on", lightOn);
        actions.Add("light off", lightOff);

        actions.Add("sun on", sunOn);
        actions.Add("sun off", sunOff);

        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void white()
    {
        _renderer.material.color = Color.white;
    }
    private void red()
    {
        _renderer.material.color = Color.red;
    }
    private void green()
    {
        _renderer.material.color = Color.green;
    }
    private void blue()
    {
        _renderer.material.color = Color.blue;
    }
    private void lightOn()
    {
        light.SetActive(true);
    }
    private void lightOff()
    {
        light.SetActive(false);
    }
    private void sunOn()
    {
        sun.SetActive(true);
    }
    private void sunOff()
    {
        sun.SetActive(false);
    }

}
