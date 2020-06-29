using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public List<Transform> attachPoints = new List<Transform>();

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && attachPoints[0].GetComponent<FishInputAttach>().fishType != null)
        {
            CountFish(0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && attachPoints[1].GetComponent<FishInputAttach>().fishType != null)
        {
            CountFish(1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && attachPoints[1].GetComponent<FishInputAttach>().fishType != null)
        {
            CountFish(2);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && attachPoints[1].GetComponent<FishInputAttach>().fishType != null)
        {
            CountFish(3);
        }
    }

    void CountFish(int attachPoint)
    {
        FishBehavior[] allFish = FindObjectsOfType<FishBehavior>();
        List<FishBehavior> fishOfType = new List<FishBehavior>();

        foreach (FishBehavior fishScript in allFish)
        {
            if (fishScript.fishType == attachPoints[attachPoint].GetComponent<FishInputAttach>().fishType && !fishScript.counted)
                fishOfType.Add(fishScript);
        }

        Debug.Log("Fish found: " + fishOfType.Count);

        if (fishOfType.Count > 0)
        {
            FishBehavior furthestRightFish = null;

            foreach (FishBehavior fishScript in fishOfType)
            {
                if (furthestRightFish == null)
                {
                    furthestRightFish = fishScript;
                }
                else if (fishScript.transform.position.x > furthestRightFish.transform.position.x)
                {
                    furthestRightFish = fishScript;
                }
            }
            furthestRightFish.CountFish();

            int indexForTally = 0;
            for (int i = 0; i < 4; i++)
            {
                if (FindObjectOfType<FishSpawner>().fishFreqs[i].fishType == furthestRightFish.fishType) { indexForTally = i; }
            }
            FindObjectOfType<ScoreKeeper>().AddToCounted(indexForTally);

        }
    }
}
