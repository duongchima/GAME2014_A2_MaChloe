using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 bottomLeft; 
    private Vector3 bottomRight;
    PlayerBehaviour player;
    public float platformLeft;
    public float platformRight;
    BoxCollider2D collider;
    bool didGeneratePlatform = false;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        Vector3 bottomLeftScreen = new Vector3(0, 0, 0);
        Vector3 bottomRightScreen = new Vector3(Screen.width, 0, 0);
        bottomLeft = mainCam.ScreenToWorldPoint(bottomLeftScreen);
        bottomRight = mainCam.ScreenToWorldPoint(bottomRightScreen);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= player.velocity.x * Time.fixedDeltaTime;
        platformLeft = transform.position.x - (collider.size.x / 2);
        platformRight = transform.position.x + (collider.size.x / 2);
        if (platformRight < bottomLeft.x)
        {
            Destroy(gameObject);

            return;
        }
        if (!didGeneratePlatform)
        {
            if(platformLeft < bottomLeft.x)
            {
                didGeneratePlatform = true;
                GeneratePlatform();
            }
        }
        transform.position = pos;
    }

    void GeneratePlatform()
    {
        GameObject go = Instantiate(gameObject);
        BoxCollider2D goCollider = go.GetComponent<BoxCollider2D>();
        Vector2 pos;


        pos.x = bottomRight.x + 20;
        pos.y = Random.Range(-20,-13);
        go.transform.position = pos;

    }
}
