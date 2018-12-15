/*
 * Jenna Meador
 * Nightmare spawner script for MG3 - spawns three different nightmares from top of screen
 */

using UnityEngine;

public class MG3NightmareSpawner : MonoBehaviour {

    public GameObject nightmareToSpawn1;
    public GameObject nightmareToSpawn2;
    public GameObject nightmareToSpawn3;
    private GameObject currentNightmare;

    public float timeBetweenSpawn;

    float spawnTime = float.MinValue;

    // Use this for initialization
    void Start ()
    {
        timeBetweenSpawn = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Time.time - spawnTime >= timeBetweenSpawn)
        {
            spawnTime = Time.time;

            if (!currentNightmare)
                currentNightmare = nightmareToSpawn1;
            else if (currentNightmare = nightmareToSpawn1)
                currentNightmare = nightmareToSpawn2;
            else
                currentNightmare = nightmareToSpawn3;

            GameObject newNightmare = Instantiate(currentNightmare, gameObject.transform.position, Quaternion.identity);
            newNightmare.transform.position += new Vector3(Random.Range(-8.0f, 8), 0, 0);
        }
	}
}
