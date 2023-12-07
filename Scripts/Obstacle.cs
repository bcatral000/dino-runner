using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //variable for the left edge of the game
    private float leftEdge;

    //calculates the variable for the left edge
    private void Start()
    {
        //when obstacle leaves the screen
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;

        //when obstacle is past the left edge the object will be destroyed
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}
