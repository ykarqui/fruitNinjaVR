using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Katana : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip media;
    public float minCuttingVelocity = 0.00001f;
    private Vector3 _previousPosition;
    [SerializeField] public TextMeshPro VelocityText = null;

    // Start is called before the first frame update
    void Start()
    {
        audio.clip = media;
        audio.volume = 1;
        audio.priority = 1;
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
        _previousPosition = newPosition;
        //VelocityText.text = velocity;


    }
}
