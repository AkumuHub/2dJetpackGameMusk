using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public GameObject Error;
    public GameObject Team;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time > spawnTime)
        {
            spawnTeam();
            spawnError();
            spawnTime = Time.time + timeBetweenSpawn;
        }

    }

    void spawnError()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(Error, transform.position + new Vector3(x, y, 0), transform.rotation);
        
    }
    void spawnTeam()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        
        Instantiate(Team, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
