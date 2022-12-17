using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class TeleportPlayerScript : MonoBehaviour
{
    public GameObject rings;
    public Material teleportMat;
    public Material normalMat;
    public Renderer _renderer;

    public GameObject TpCam;

    private KeywordRecognizer keywordRecogniser;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public GameObject player;

    public Vector3 tpLocation;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        actions.Add("energise", Energise);
        actions.Add("Beam me up scotty", Energise);

        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Energise()
    {
        TpCam.SetActive(true);
        rings.SetActive(true);
        _renderer.material = teleportMat;
        FindObjectOfType<SpawnEffect>().teleport = true;
    }
    public void DisableTp()
    {
        _renderer.material = normalMat;
        TpCam.SetActive(false);
        rings.SetActive(false);
        player.transform.position = tpLocation;
        Debug.Log("Teleported");
    }
}
