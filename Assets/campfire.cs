using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfire : MonoBehaviour
{
    public ParticleSystem fire;
    void Start()
    {
      fire.Play();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
