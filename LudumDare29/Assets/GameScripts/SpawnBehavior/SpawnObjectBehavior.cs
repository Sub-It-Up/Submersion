using UnityEngine;
using System.Collections;

public class SpawnObjectBehavior : MonoBehaviour
{
    public GameObject[] SpawnObject;
    public float DelayTime = 4;

    private float elapsedTimeSinceSpawn;

    void Start()
    {
        elapsedTimeSinceSpawn = DelayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTimeSinceSpawn > DelayTime)
        {
            int randomSpawnObject = Random.Range(0, SpawnObject.Length);
            int randomSpawnArea = Random.Range(0, 4);
            Vector2 spawnPos = Vector2.zero;
            Vector2 extents = SpawnObject[randomSpawnObject].GetComponent<BoxCollider2D>().size * .5f;

            if (randomSpawnArea == 0)
            {
                spawnPos = new Vector2(-2 * Camera.main.orthographicSize - extents.x, Camera.main.transform.position.y + Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize));
            }
            else if (randomSpawnArea == 1)
            {
                spawnPos = new Vector2(Random.Range(-2 * Camera.main.orthographicSize, 2 * Camera.main.orthographicSize), Camera.main.transform.position.y + Camera.main.orthographicSize + extents.y);
            }
            else if (randomSpawnArea == 2)
            {
                spawnPos = new Vector2(2 * Camera.main.orthographicSize + extents.x, Camera.main.transform.position.y +  Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize));
            }
            else if (randomSpawnArea == 3)
            {
                spawnPos = new Vector2(Random.Range(-2 * Camera.main.orthographicSize, 2 * Camera.main.orthographicSize), Camera.main.transform.position.y +  -Camera.main.orthographicSize - extents.y);
            }

            GameObject.Instantiate(SpawnObject[randomSpawnObject], spawnPos, Quaternion.identity);
            
            elapsedTimeSinceSpawn = 0;
        }

        elapsedTimeSinceSpawn += Time.deltaTime;
    }
}
