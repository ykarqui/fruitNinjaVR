using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    // reference to a single fruit
    public GameObject [] prefab;
    public Transform [] spawnPoints;
    
    // random generator
    public float minDelay = 0.1f;
    public float maxDelay = 1f;
    public float bombRate;
    public float watermelonRate;
    public float appleRate;
    public float orangeRate;
    public float kiwiRate;
    
    // Array of Rates
    [NonSerialized] private List<float> rates = new List<float>();
    [NonSerialized] private List<int> indexes = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        orderRates();
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        // We spawn a obj between min & max random number of seconds
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            // spawn obj
            var rotPosition = spawnPoint.rotation.eulerAngles;
            rotPosition.z = rotPosition.z + Random.Range(-3f, 3f);
            GameObject spawnedFruit = Instantiate(prefab[getIndexValue()], spawnPoint.position, Quaternion.Euler(rotPosition));
            Destroy(spawnedFruit, 5f);
            switch (spawnIndex)
            {
                case 0:
                    spawnIndex = 2;
                    break;
                case 1:
                    spawnIndex = 0;
                    break;
                case 2:
                    spawnIndex = 1;
                    break;
            }
            spawnPoint = spawnPoints[spawnIndex];
            // spawn obj
            rotPosition = spawnPoint.rotation.eulerAngles;
            rotPosition.z = rotPosition.z + Random.Range(-3f, 3f);
            spawnedFruit = Instantiate(prefab[getIndexValue()], spawnPoint.position, Quaternion.Euler(rotPosition));
            Destroy(spawnedFruit, 5f);
        }
    }

    void orderRates()
    {
        rates.Add(fixRate(watermelonRate));
        indexes.Add(1);
        rates.Add(fixRate(appleRate));
        indexes.Add(2);
        rates.Add(fixRate(orangeRate));
        indexes.Add(3);
        rates.Add(fixRate(kiwiRate));
        indexes.Add(4);
        
        float temp = 0f;
        int temp2 = 0;
        Debug.Log("Start SORT");
        for (int sort = 0; sort < rates.Count - 1; sort++)
        {
            if (rates[sort] > rates[sort + 1])
            {
                temp = rates[sort + 1];
                temp2 = indexes[sort + 1];
                rates[sort + 1] = rates[sort];
                rates[sort] = temp;
                indexes[sort + 1] = indexes[sort];
                indexes[sort] = temp2;
            }
        }
    }

    float fixRate(float fruit)
    {
        float max = 1f - bombRate;
        if (fruit == 0)
        {
            return 0;
        }
        else
        {
            return 1f - (fruit * max);
        }
    }

    int getIndexValue()
    {
        float val = Random.value;
        if (val <= bombRate)
        {
            return 0;
        }
        else // bombRate y 1
        {
            if (val<=rates[0])
            {
                return indexes[0];
            }
            if (val<=rates[1])
            {
                return indexes[1];
            }
            if (val<=rates[2])
            {
                return indexes[2];
            }
            if (val <= rates[3])
            {
                return indexes[3];
            }
        }

        return 1;
    }

}
