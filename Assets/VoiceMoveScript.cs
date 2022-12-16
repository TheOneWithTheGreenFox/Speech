using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMoveScript : MonoBehaviour
{
    public float increment;

    private KeywordRecognizer keywordRecogniser;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("left", Left);
        actions.Add("right", Right);

        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Up()
    {
        transform.position += new Vector3(0, increment, 0);
    }
    private void Down()
    {
        transform.position += new Vector3(0, -increment, 0);
    }
    private void Left()
    {
        transform.position += new Vector3(-increment, 0, 0);
    }
    private void Right()
    {
        transform.position += new Vector3(increment, 0, 0);
    }
}
