using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public GameObject zombiePrefab;

    public int zombiesPerWave = 5;

    public int currentWave = 0;

    public int totalWaves = 3;

    public float delayBetweenWaves = 5f;

    public bool isCooldown = false;

    public List<Zombie> zombies;

    void Start()
    {
        SpawnWave();

    }

    void Update()
    {
        if(AllZombiesDead() && !isCooldown)
        {
            StartCoroutine(SpawnWaveWithCooldown());
        }
    }

    private IEnumerator SpawnWaveWithCooldown()
    {

        isCooldown = true;

        yield return new WaitForSeconds(2f);

        isCooldown = false;

        zombiesPerWave = zombiesPerWave * 2;
        currentWave++;
        zombies.Clear();

        SpawnWave();

    }
    private void SpawnWave()
    {
        for (int i = 0; i < zombiesPerWave; i++)
        {
            var spawnOffset = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            var spawnPosition = transform.position + spawnOffset;
            var spawned = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

            zombies.Add(spawned.GetComponent<Zombie>());
        }
     
        // Toca o grito de início de rodada
        SoundManager.Instance.PlayRoundStartSound();
        
        // Toca o som da horda em loop
        SoundManager.Instance.PlayZombieHordeSound();
    }

    private bool AllZombiesDead()
    {
        foreach (var zombie in zombies)
        {
            if (!zombie.isDead)
            {
                return false;
            }
        }
        
        // Se todos os zumbis morreram, para o som da horda
        if (zombies.Count > 0)
        {
            SoundManager.Instance.StopZombieHordeSound();
        }
        
        return true;
    }
}
