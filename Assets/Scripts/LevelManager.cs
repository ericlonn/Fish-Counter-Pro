using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Transform> attachPoints = new List<Transform>();
    public FishSpawner fishSpawner;

    // Start is called before the first frame update
    void Start()
    {
        fishSpawner = GameObject.FindObjectOfType<FishSpawner>();

        for (int i = 0; i < 4; i++)
        {
            if (i > fishSpawner.fishFreqs.Count) { break; }
            attachPoints[i].GetComponent<FishInputAttach>().fishType = fishSpawner.fishFreqs[i].fishType;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
