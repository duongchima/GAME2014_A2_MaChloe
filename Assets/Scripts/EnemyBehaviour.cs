using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    PlayerBehaviour player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x = player.velocity.x * Time.fixedDeltaTime;
        if(pos.x < -100)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
