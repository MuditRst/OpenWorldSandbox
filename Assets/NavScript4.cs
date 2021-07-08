using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavScript4 : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent nav;

    private float patrolRadius = 20f;
    private float patrolTimer = 10f;
    private float Timer;

    
    
    void Awake(){
        anim = GetComponent<Animator>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Start()
    {
        Timer = patrolTimer;
    }

    
    void Update()
    {
        patrol();
    }

    void patrol(){
        Timer += Time.deltaTime;
        if(Timer > patrolTimer){
            SetRandomDes();
            Timer = 0f;
        }
    }

    void SetRandomDes(){
        Vector3 newDes = RandomNavSphere(transform.position,patrolRadius,-1);
        nav.SetDestination(newDes);
    }
    Vector3 RandomNavSphere(Vector3 originPos, float radius, int layermask){

        Vector3 randomDir = Random.insideUnitSphere * radius;
        randomDir += originPos;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDir, out navHit, radius, layermask);
        return navHit.position;
    }
}
