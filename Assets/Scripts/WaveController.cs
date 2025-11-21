using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{

    public GameObject zombiePrefab;

    public int zombiesPerWave = 5;

    public int currentWave = 0;

    public int totalWaves = 1;

    public float delayBetweenWaves = 5f;

    public bool isCooldown = false;

    public List<Zombie> zombies;

    //Cooldown counter
    public float cooldownCounter = 0f;

    [Header("Text")]
    public TextMeshProUGUI waveUI;
    public TextMeshProUGUI currentWaveUI;
    public TextMeshProUGUI winUI;

    public RawImage winImage;



    void Start()
    {
        StartNextWave();
        cooldownCounter = delayBetweenWaves;

    }

    void Update()
    {

        if(AllZombiesDead() && currentWave >= totalWaves)
        {
            waveUI.text = "Todas as waves completas!";
            winUI.gameObject.SetActive(true);
            winImage.gameObject.SetActive(true);
            return;
        }

        if (AllZombiesDead() && !isCooldown)
        {
            StartCoroutine(WaveCooldown());
        }

        if (isCooldown)
        {
            cooldownCounter -= Time.deltaTime;
            waveUI.text = "Proxima wave em: " + Mathf.CeilToInt(cooldownCounter).ToString();
        } else
        {
            cooldownCounter = delayBetweenWaves;
            waveUI.text = "";
        }


    }

    private void StartNextWave()
    {
        currentWave++;
        currentWaveUI.text = "Wave: " + currentWave.ToString();

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
        return true;
    }

    private IEnumerator WaveCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(delayBetweenWaves);
        isCooldown = false;

        List<Zombie> zombiesToRemove = new List<Zombie>();
        foreach (var zombie in zombies)
        {
            if (zombie.isDead)
            {
                zombiesToRemove.Add(zombie);
            }
        }

        foreach (var zombie in zombiesToRemove)
        {
            Destroy(zombie.gameObject);
        }

        zombies.Clear();
        zombiesPerWave = zombiesPerWave * 2;
        StartNextWave();
    }
}
