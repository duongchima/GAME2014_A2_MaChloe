using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    PlayerBehaviour player;
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        scoreText.text = distance.ToString();
    }
}
