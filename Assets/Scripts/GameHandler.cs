using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public float timer = 3.0f;
    float timeLeft = 0.0f;

    public Transform[] spawnPoints;
    public Transform player;
    public Enemy enemy;

    int maxEnemies = 1;
    int currentEnemies = 0;
    // Start is called before the first frame update

    void OnEnable()
    {
        Enemy.OnDeath += SpawnEnemies;
    }

    void OnDisable()
    {
        Enemy.OnDeath -= SpawnEnemies;
    }
    void Start()
    {
        Enemy newEnemy = Instantiate(enemy, spawnPoints[0].position, Quaternion.identity);
        newEnemy.target = player;
        currentEnemies++;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = player.position;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            UpgradeEnemies();
            timeLeft = timer;
        }
    }

    void SpawnEnemies()
    {
        int point = UnityEngine.Random.Range(0, 3);
        Enemy newEnemy = Instantiate(enemy, spawnPoints[point].position, Quaternion.identity);
        newEnemy.target = player;
        maxEnemies++;
    }

    private void UpgradeEnemies()
    {
        int point = 0;
        for (int i = maxEnemies - currentEnemies; i > 0; i-- ) {
            point = UnityEngine.Random.Range(0, 3);
            Enemy newEnemy = Instantiate(enemy, spawnPoints[point].position, Quaternion.identity);
            newEnemy.target = player;
        }
    }


}
