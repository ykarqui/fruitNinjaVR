using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject SlicePrefab = null;
    public float startForce = 13f;
    Rigidbody rb;
    public AudioSource audio;
    public AudioClip media;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * startForce, ForceMode.Impulse);
        audio.clip = media;
        Debug.Log("Inicio Bomba");
        audio.volume = 1;
        audio.priority = 106;
        Debug.Log("INICIADA");
    }

    // Method called whenever we detect something on trigger
    private void OnTriggerEnter(Collider col)
    {
        // We hit a bomb
        if ((col.CompareTag("KatanaRight") && OVRInput.Get(OVRInput.Button.One)) ||
            (col.CompareTag("KatanaLeft") && OVRInput.Get(OVRInput.Button.Three)))
        {
            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Debug.Log("We hit a bomb");
            // Life.lifeValue = Life.lifeValue - 1;
            GameObject slicedBomb = Instantiate(SlicePrefab, transform.position, rotation);
            Destroy(gameObject);
            //audio.
            audio.Play();
            Destroy(slicedBomb, 1f);
        }
        else if (col.CompareTag("DeadZone"))
        {
            audio.Play();
            // Score.scoreValue = Score.scoreValue - 20;
            Debug.Log("BOMBA");
        }
    }
}