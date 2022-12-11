using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileMapParallax : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.3f;
    [SerializeField] float offset = 0f;
    [SerializeField] GameObject viewTarget;
    [SerializeField] bool xOnly = true;

    Tilemap tileMap;
    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        float newXPos = viewTarget.transform.position.x * (scrollSpeed + offset);
        float newYPos = viewTarget.transform.position.y * (scrollSpeed + offset);
        if (xOnly)
        {
            tileMap.transform.position = new Vector3(newXPos, tileMap.transform.position.y, tileMap.transform.position.z);
        }
        else
        {
            tileMap.transform.position = new Vector3(newXPos, newYPos, tileMap.transform.position.z);
        }
    }
}
