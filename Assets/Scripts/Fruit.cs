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
        if (col.CompareTag("Katana") /*&& OVRInput.Get(OVRInput.Button.One)*/)
        {
            Score.scoreValue = Score.scoreValue + fruitScore;
            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Debug.Log("We hit a watermelon");

            GameObject slicedFruit = Instantiate(fruitSlicePrefab, transform.position, rotation);
            Destroy(gameObject);
            Destroy(slicedFruit, 3f);

        }
        /*else if (col.CompareTag("DeadZone"))
        {
            // initialGAP--;

            // Score.scoreValue = Score.scoreValue - 20;
            Debug.Log("Pega en el dead zone");
            ComboBar.comboValue -= 0.1f;
            if (Score.scoreValue == -1110)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }*/
    }
}
