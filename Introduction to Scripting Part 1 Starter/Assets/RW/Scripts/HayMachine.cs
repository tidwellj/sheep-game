﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    public GameObject hayBalePrefab; 
    public Transform haySpawnpoint; 
    public float shootInterval; 
    private float shootTimer; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();


    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); 

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) 
        {

            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) 
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
       
    }
    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime; 

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) 
        {


            shootTimer = shootInterval; 
            ShootHay(); 
        }
    }
    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

}
