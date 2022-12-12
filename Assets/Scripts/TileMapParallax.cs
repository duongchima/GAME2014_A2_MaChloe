using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileMapParallax : MonoBehaviour
{
    [SerializeField] float depth = 1;
    PlayerBehaviour player;
    [SerializeField] float minBoundsX;
    [SerializeField] float maxBoundsX;

    Tilemap tileMap;
    private void Start()
    {
        tileMap = GetComponent<Tilemap>();
        player = FindObjectOfType<PlayerBehaviour>();
    }

    private void FixedUpdate()
    {
        float velocity = player.velocity.x / depth;
        Vector2 pos = tileMap.transform.position;

        pos.x -= velocity * Time.fixedDeltaTime;
        if(pos.x <= minBoundsX)
        {
            pos.x = maxBoundsX;
        }

        tileMap.transform.position = pos;
    }
}
