using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{

    public GameObject fishPrefab;
    public float spawnRange = 10f;
    public float spawnFrequency = 1f;
    public List<FishFreq> fishFreqs = new List<FishFreq>();

    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnFrequency)
        {
            SpawnFish();
            spawnTimer = 0f;
        }
    }

    void SpawnFish()
    {
        float spawnRandomYPos = Random.Range(-spawnRange, spawnRange);
        GameObject newFish = Instantiate(fishPrefab, transform.position, transform.rotation);
        FishType newFishType = ChooseFish();

        newFish.transform.position = new Vector2(newFish.transform.position.x, newFish.transform.position.y + spawnRandomYPos);
        newFish.GetComponent<SpriteRenderer>().sprite = newFishType.fishSprite;
        newFish.GetComponent<FishBehavior>().speed = newFishType.speed;
        newFish.GetComponent<FishBehavior>().fishType = newFishType;

    }

    FishType ChooseFish()
    {
        float freqTotal = 0f;

        foreach (FishFreq fishFreq in fishFreqs)
        {
            freqTotal += fishFreq.fishFrequency;
        }

        float randomFish = Random.Range(0f, freqTotal);
        float probabilityCounter = 0f;

        foreach (FishFreq fishFreq in fishFreqs)
        {
            if (randomFish >= probabilityCounter && randomFish <= probabilityCounter + fishFreq.fishFrequency) { return fishFreq.fishType; }
            probabilityCounter += fishFreq.fishFrequency;

        }

        return fishFreqs[0].fishType;

    }

    private void OnDrawGizmos()
    {
        float lineDistance = 15f;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            new Vector2(transform.position.x, transform.position.y + spawnRange), 
            new Vector2(transform.position.x + lineDistance, transform.position.y + spawnRange));
        Gizmos.DrawLine(
            new Vector2(transform.position.x, transform.position.y - spawnRange), 
            new Vector2(transform.position.x + lineDistance, transform.position.y - spawnRange));
    }
}
