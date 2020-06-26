using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelBoundaries : MonoBehaviour
{
    Vector2 topLeftCorner;
    Vector2 topRightCorner;
    Vector2 botLeftCorner;
    Vector2 botRightCorner;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        RefreshCollider();

    }

    // Update is called once per frame
    void Update()
    {
        RefreshCollider();
    }

    void RefreshCollider()
    {
        topLeftCorner = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f));

        botLeftCorner = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f));
        botRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        boxCollider.size = new Vector2(topRightCorner.x - topLeftCorner.x, botLeftCorner.y - topLeftCorner.y);
    }
}
