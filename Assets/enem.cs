using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enem : MonoBehaviour
{
    private float doDamage = 15f;
    public float movespeed = 5f;
    public float maxdist = 10f;
    public float mindist = 4f;
    public float Rotationspeed = 3f;
    public float stop = 0f;
    private float range = 10f;
    public Transform target;
    public Transform myTransform;

    void Awake(){
        target = GameObject.FindWithTag("Player").transform;

        myTransform = transform;

    }


    void Update()
    {
        var distance = Vector3.Distance(transform.position,target.position);
        if(distance <= range)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position),Rotationspeed * Time.deltaTime);
        }
        if(distance > stop && distance > mindist)
        {
            myTransform.position += myTransform.forward * movespeed * Time.deltaTime;
        }
    }
}
