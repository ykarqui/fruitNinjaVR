using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    
    public AudioSource audio;
    public AudioClip media;
    public float minCuttingVelocity = 0.01f;
    private Vector3 _previousPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        audio.clip = media;
        audio.volume = 1;
        audio.priority = 106;
    }

    // Update is called once per frame
    void Update()
    {
        // get pos
        Vector3 newPosition = transform.position;
        // get speed
        float velocity = (newPosition - _previousPosition).magnitude / Time.deltaTime;
        
        if (velocity > minCuttingVelocity)
        {
            audio.Play();
        }
        
    }
}
