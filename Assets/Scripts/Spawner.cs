using System;
using System.Collections;
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
    
    // Start is called before the first frame update
    void Start()
    {
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
            rotPosition.z = rotPosition.z + Random.Range(-5f, 5f);
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
            rotPosition.z = rotPosition.z + Random.Range(-5f, 5f);
            spawnedFruit = Instantiate(prefab[getIndexValue()], spawnPoint.position, Quaternion.Euler(rotPosition));
            Destroy(spawnedFruit, 5f);
        }
    }

    int getIndexValue()
    {
        float val = Random.value;
        if (val <= 0.2f)
        {
            return 0;
        }
        else // 0.2 y 1
        {
            if (val<=0.7f)
            {
                return 1;
            }
            else if (val<=0.9f)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }

}
