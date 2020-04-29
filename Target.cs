using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float enemyhealth = 50f;    
    Animator enemyAnim;
    public AudioClip deadSound;
    public AudioSource enemyAudioSource;
    //ScoreManager scoreManager;
    private void Start()
    {
        enemyAnim = GetComponent<Animator>();        
    }

    public void TakeDamage(float amount)
    {
        enemyhealth -= amount;
        Debug.Log(enemyhealth);
        if (enemyhealth <= 0f)
        {            
            Die();            
        }
    }

    void Die()
    {
        ScoreManager.currScore += 10;
        enemyAudioSource.PlayOneShot(deadSound);
        enemyAnim.SetBool("isDead", true);
        Destroy(gameObject, 2f);
    }
}
