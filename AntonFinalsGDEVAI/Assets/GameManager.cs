using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Transform[] Spawnpoints;
    public GameObject Police;
    public GameObject Civilians;
    [SerializeField] private float spawnRange;
    private float policeSpawnTimer = 0;
    private float civiliansSpawnTimer = 0;
    private void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        civiliansSpawnTimer += Time.deltaTime;
        if (civiliansSpawnTimer > 3)
        {
            Instantiate(Civilians, transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange)), Quaternion.identity);
            civiliansSpawnTimer = 0;
        }
        policeSpawnTimer += Time.deltaTime;
        if (policeSpawnTimer > 12)
        {
            Instantiate(Police, transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange)), Quaternion.identity);
            policeSpawnTimer = 0;
        }
    }
}