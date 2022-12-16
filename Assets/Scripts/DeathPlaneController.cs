using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Death Plane Controller
Name: Chloe Ma 
Student #: 101260013
Date last modified: 16/12/22
Description: Collider that triggers the player to respawn back to its checkpoint.
 */
[System.Serializable]
public class DeathPlaneController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<UIController>().PlayerDeath();

            FindObjectOfType<SoundManager>().PlaySoundFX(Sound.DEATH, Channel.PLAYER_DEATH_FX);
        }

    }
}
