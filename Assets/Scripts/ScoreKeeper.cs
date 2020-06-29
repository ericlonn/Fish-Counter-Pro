using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    int[] fishTotal = new int[4];
    int[] fishCounted = new int[4];
    int miscounts = 0;

    public TextMeshProUGUI[] textElementsTotal = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] textElementsCounted = new TextMeshProUGUI[4];
    public TextMeshProUGUI miscountTMP;

    private void Update()
    {
        RefreshUIElements();
    }

    public void AddToTotal(int fishID) { fishTotal[fishID]++; }

    public void AddToCounted(int fishID) { fishCounted[fishID]++; }

    public void AddToMiscounts() { miscounts++; }

    void RefreshUIElements()
    {
        for (int i = 0; i < 4; i++)
        {
            textElementsTotal[i].text = fishTotal[i].ToString();
        }

        for (int i = 0; i < 4; i++)
        {
            textElementsCounted[i].text = fishCounted[i].ToString();
        }


    }
}
