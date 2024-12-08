using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject enemyBallType1; 
    public GameObject enemyBallType2; 
    public Transform spawnPoint1;
    public Transform spawnPoint2; 
    public float initialSpawnInterval = 2f; 
    public float spawnIntervalDecreaseRate = 0.05f; 
    public float minSpawnInterval = 0.5f; 
    public float speedIncreaseRate = 0.1f; 

    private float currentSpawnInterval;
    private float enemySpeed = 2f; 

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        Invoke("SpawnEnemy", currentSpawnInterval);
    }

    private void SpawnEnemy()
    {
        if (FirstGameManager.instance.isGameOver == false)
        {
            GameObject selectedEnemy = Random.value > 0.5f ? enemyBallType1 : enemyBallType2;
            Transform selectedSpawnPoint = Random.value > 0.5f ? spawnPoint1 : spawnPoint2;
            GameObject enemy = Instantiate(selectedEnemy, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
            EnemyBall enemyBallScript = enemy.GetComponent<EnemyBall>();
            if (enemyBallScript != null)
            {
                enemyBallScript.speed = enemySpeed;
            }
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecreaseRate, minSpawnInterval);
            enemySpeed += speedIncreaseRate;
            Invoke("SpawnEnemy", currentSpawnInterval);
        }
    }
}
