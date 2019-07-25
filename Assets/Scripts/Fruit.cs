using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

// [RequireComponent(typeof(AudioSource))]
public class Fruit : MonoBehaviour
{
    
    public GameObject fruitSlicePrefab = null;
    public float startForce = 13f;
    public int fruitScore;
    Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * startForce, ForceMode.Impulse);
    }

    // Method called whenever we detect something on trigger
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Obj Trigger: " + col.gameObject.name);
        // We hit a watermelon/fruit
        if ((col.CompareTag("KatanaRight") && OVRInput.Get(OVRInput.Button.One)) ||
            (col.CompareTag("KatanaLeft") && OVRInput.Get(OVRInput.Button.Three)))
        {
            Score.scoreValue = Score.scoreValue + fruitScore;
            Debug.Log("Score: " + Score.scoreValue);
            ComboBar.comboValue += 0.05f;
            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Debug.Log("We hit a watermelon");

            GameObject slicedFruit = Instantiate(fruitSlicePrefab, transform.position, rotation);
            Destroy(gameObject);
            Destroy(slicedFruit, 3f);

        }
        else if (col.CompareTag("DeadZone"))
        {
            // initialGAP--;
            if (Score.scoreValue > 0)
            {
                Score.scoreValue = Score.scoreValue - 20;
            }
            if (Score.scoreValue < 0)
            {
                Score.scoreValue = 0;
            }
            ComboBar.comboValue -= 0.05f;
        }
    }
}
