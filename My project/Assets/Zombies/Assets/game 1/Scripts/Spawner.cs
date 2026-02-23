using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
    }

    void Spawn()
    {
        int index = Random.Range(0, prefabs.Length);
        
        float x = Random.Range(-6f, 6f);
        float y = Random.Range(-10f, 10f);

        Vector3 pos = new Vector3(x, y, 25f);

        Instantiate(prefabs[index], pos, Quaternion.identity);
    }
}
