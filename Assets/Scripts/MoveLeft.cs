using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speedMove = 30f;
    private PlayerController playerontroller;
    private float lefBound = -10f;
    private void Awake()
    {
        playerontroller = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < lefBound && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
        if (playerontroller.gameOver == false) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * speedMove);
        }
    }
}
