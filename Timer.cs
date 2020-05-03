using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float startTime = 60f;
    private float timer;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        timer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
            timerText.text = (Mathf.Round(timer)).ToString();            
        }else if(timer <= 0f)
        {
            Cursor.visible = true;
            gameManager.Win();            
        }
    }
}
