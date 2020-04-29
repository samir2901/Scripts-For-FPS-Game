using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    float stoppingDist = 3f;
    float lastAttackTime = 0f;
    float attackCoolDown = 3f;

    public float lookRadius = 10f;
    public AudioClip attackSound;
    public AudioSource enemyAudioSource;

    GameObject target;

    NavMeshAgent agent;
    Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        //Debug.Log(dist);
        if (dist < stoppingDist)
        {            
            StopEnemy();
            if (Time.time - lastAttackTime > attackCoolDown)
            {
                enemyAudioSource.PlayOneShot(attackSound);
                lastAttackTime = Time.time;                
                enemyAnim.SetBool("attack", true);
                enemyAnim.SetBool("isWalking", false);
                //Debug.Log("Attacked by enemy");
                PlayerControl playerControlScript = target.GetComponent<PlayerControl>();
                playerControlScript.health -= 1;
            }
        }
        else
        {
            GotoTarget();
        }
    }

    private void GotoTarget() 
    {        
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        enemyAnim.SetBool("isWalking", true);
        enemyAnim.SetBool("attack", false);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
        enemyAnim.SetBool("isWalking", false);       
        
    }
}
