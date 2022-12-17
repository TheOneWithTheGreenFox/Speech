using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;

    public ParticleSystem ps;
    float timer = 0;
    Renderer _renderer;

    int shaderProperty;

    public bool teleport = false;
    public bool teleported = true;


    void Start ()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();

        var main = ps.main;
        main.duration = spawnEffectTime;
    }
	
	void Update ()
    {
        Teleport();

        if (timer < spawnEffectTime + pause)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            if (teleported) 
            {
                DisableTp();
                teleported = true;
            }
        }
        Debug.Log(teleported);

        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate( Mathf.InverseLerp(0, spawnEffectTime, timer)));
        
    }

    private void Teleport()
    {
        if (teleport)
        {
            ps.Play();
            teleport = false;
            teleported = false;
        }
    }

    public void DisableTp()
    {
        GetComponent<TeleportPlayerScript>().DisableTp();
    }
}
