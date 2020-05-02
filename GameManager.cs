using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject fpsPlayer, gun, fpsCamera;
    public GameObject gameOverPanel, gameUIPanel;    
    public GameObject[] spawners;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fpsPlayer.GetComponent<PlayerControl>().health <= 0)
        {
            gameUIPanel.SetActive(false);
            gameOverPanel.SetActive(true);            
            foreach (GameObject spawner in spawners)
            {
                spawner.SetActive(false);
            }
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            fpsPlayer.GetComponent<PlayerControl>().enabled = false;
            fpsCamera.GetComponent<MouseLook>().enabled = false;
            gun.GetComponent<Gun>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            gameOverPanel.SetActive(false);            
        }
    }
}
