using UnityEngine;

public class GemFallScript : MonoBehaviour
{
    public GameObject gemPrefab;
    public float timer;
    public float spawnInterval = 3f;
    public bool isGameOver = false;

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer>= spawnInterval)
        {
            SpawnGem();
            timer = 0;
        }
    }

    void SpawnGem()
    {
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0);
        Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
    }
}