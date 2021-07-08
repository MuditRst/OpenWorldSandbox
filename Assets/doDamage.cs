using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage : MonoBehaviour
{
    int health = 100;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            health --;
        }
    }
}
