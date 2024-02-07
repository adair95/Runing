using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawPos = new Vector3(25,0,0);
    private float starDelay = 2f;
    private float repeartRate = 2f;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Start()
    {
        InvokeRepeating("SpawObstacle", starDelay, repeartRate);      
    }


    private void SpawObstacle()
    {
        if (playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawPos, obstaclePrefab.transform.rotation);
        } 
    }
}
