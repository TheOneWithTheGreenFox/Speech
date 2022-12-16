using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class AttackScript : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public Animator animator;
    public Transform rightHand;
    public Transform leftHand;


    public GameObject fireballPrefab;
    private GameObject fireballInstance;
    public float fireballSpeed;
    public bool fireActive;

    private void Start()
    {
        actions.Add("fireball", fireball);
        actions.Add("lightning", lightning);
        actions.Add("ice", ice);
        actions.Add("earth", earth);

        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void fireball()
    {
        animator.SetTrigger("fireball");
        fireballInstance = Instantiate(fireballPrefab);
        fireActive = true;
    }
    private void lightning()
    {
        
    }
    private void ice()
    {
        
    }
    private void earth()
    {
        
    }

    public void UnlockFireball()
    {
        fireActive = false;
        fireballInstance.GetComponent<Rigidbody>().velocity = rightHand.transform.up * fireballSpeed;
        fireballInstance.GetComponent<fireballScript>().startTimer = true;
    }

    private void Update()
    {
        if (fireActive)
        {
            fireballInstance.transform.position = rightHand.position;
        }
    }
}
