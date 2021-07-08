using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float Health = 100f;

    void Start()
    {
    }
    
    public void takeDamagefromenemy(float amount){
        Health -= amount;
    }

    
    void Update()
    {
        if(Health <= 0){
            Destroy(gameObject);
        }   
    }
}
