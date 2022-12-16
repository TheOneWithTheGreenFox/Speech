using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour
{
    public bool startTimer =  false;

    public float time;

    void Update()
    {
        if (startTimer)
        {
            Destroy(gameObject, time);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
