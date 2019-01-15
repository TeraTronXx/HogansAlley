using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour {

    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject[] personType;

    public float minSpawnTime = 3f;
    public float maxSpawnTime = 10f;

    private int[] posiciones;

    bool stop = false;


    // Use this for initialization
    void Start () {
        posiciones = new int[spawnPoints.Length];
        StartCoroutine(SpawnPeople());
        for(int i=0; i<spawnPoints.Length; i++)
        {
            posiciones[i] = 0;
        }
    }

    IEnumerator SpawnPeople()
    {
        

        while (!stop)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            int a = Random.Range(0, personType.Length);
            int b = elegirPosicion();
            
            Instantiate(personType[a], spawnPoints[b]);
        }
    }

    public int elegirPosicion()
    {
        int todolleno = 0;

        int b = Random.Range(0, spawnPoints.Length);
       /* while (b == 1)
        {
            b = Random.Range(0, spawnPoints.Length);
            for(int j=0; j<spawnPoints.Length; j++)
            {
                if(posiciones[j] == 1)
                {
                    todolleno = todolleno + 1;
                }
            }
        }
        posiciones[b] = 1;*/

        return b;
    }

    public void Stop()
    {
        stop = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
