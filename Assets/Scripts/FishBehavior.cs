using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    public float speed = 1f;
    public FishType fishType;
    public float size;
    public float swaySpeed;
    public float swayAmount;


    private float initialYPos;
    private float swayRange;
    private int swayDir = 1;

    // Start is called before the first frame update
    void Start()
    {
        initialYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 currentMove = Vector3.right * speed * Time.deltaTime;
        transform.Translate(currentMove);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "LevelBoundaries") {
            Destroy(gameObject);
        }
        Debug.Log("OUT");
    }
}
