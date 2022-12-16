using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SoundManager>().PlayMusic(Sound.MENU_MUSIC);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
