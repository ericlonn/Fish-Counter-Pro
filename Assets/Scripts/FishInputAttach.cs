using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishInputAttach : MonoBehaviour
{
    public FishType fishType;

    private void Update()
    {
        GetComponent<SpriteRenderer>().sprite = fishType.fishSprite;
    }
}
