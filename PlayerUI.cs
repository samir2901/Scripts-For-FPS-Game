using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text healthAmount, scoreAmount;
    public GameObject player;
    public GameObject gun;
    PlayerControl playerControlScript;
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = player.GetComponent<PlayerControl>();                
        healthAmount.text = "HEALTH: " + playerControlScript.maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int health = playerControlScript.health;        
        
        healthAmount.text = "HEALTH:" + health.ToString();        
    }
}
