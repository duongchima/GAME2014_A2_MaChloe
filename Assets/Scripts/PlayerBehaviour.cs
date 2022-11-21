using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Player Behaviour
Name: Chloe Ma 
Student #: 101260013
Date last modified: 20/11/22
Description: Controls the Player's movement and behaviours.
 */
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameover.SetActive(true);
        }
    }
}
