using System.Collections;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING}

    //alows us to change the values of the instances within unity 
    
    [System.Serializable]
    public class Wave {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawPoints; 

    public float timebetweenwaves = 5f;
    public float waveCountdown = 0f;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timebetweenwaves;

    }
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check if enemies are alive
            if (!EnemyIsAlive())
            {
                //start new round
                WaveCompleted();
                return;
            }
            else {
                return;
            }

        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

        }
        else {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted() {
        
        state = SpawnState.COUNTING;
        waveCountdown = timebetweenwaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else {
            nextWave++;
        }

        
    }

    bool EnemyIsAlive() {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f) {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
      
        }
        return true;
        
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        // spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning enemy" + _enemy.name);

        Transform sp = spawPoints[Random.Range(0, spawPoints.Length)];

        Instantiate(_enemy, sp.transform.position, sp.rotation);
        
    }

}
