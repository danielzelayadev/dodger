using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemyPrefab;
    public int enemyLimit = 5;
    public float msBetweenSpawn = 100;
    public float minX, maxX;

    private float msSinceLastSpawn;
    private readonly List<GameObject> enemies = new List<GameObject>();

	// Use this for initialization
	void Start () {
        msSinceLastSpawn = msBetweenSpawn;
	}

    // Update is called once per frame
    void Update() {
        if (enemies.Count < enemyLimit) SpawnEnemy();
        if (enemies.Count > 0) CheckToDelete();
    }

    void SpawnEnemy()
    {
        if (msSinceLastSpawn < msBetweenSpawn) msSinceLastSpawn += Time.deltaTime * 1000;
        else
        {
            var randomX = Random.Range(minX, maxX);
            enemies.Add(Instantiate(enemyPrefab, new Vector3(randomX, 5.332f, 0), Quaternion.identity));
            msSinceLastSpawn = 0;
        }
    }

    void CheckToDelete()
    {
        for (var i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];

            if (enemy.transform.position.y <= -5.316f)
            {
                Destroy(enemy);
                enemies.RemoveAt(i);
            }
        }
    }
}
