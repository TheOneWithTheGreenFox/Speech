using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class ExplodeScript : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public GameObject cube;
    public GameObject explosion;
    public GameObject cubePrefab;

    public GameObject sun;

    private void Start()
    {
        actions.Add("explode", Explode);

        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Explode()
    {
        Transform pos = cube.transform;
        Instantiate(explosion, pos.position, Quaternion.identity);
        Destroy(cube);
        StartCoroutine(RespawnCube());
    }

    private IEnumerator RespawnCube()
    {
        yield return new WaitForSeconds(3);
        cube = Instantiate(cubePrefab);
        
        cube.GetComponent<ColourChangeScript>().sun = sun;
    }
}
