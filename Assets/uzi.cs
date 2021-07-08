using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uzi : MonoBehaviour
{
   public float damage = 20f;
    public float range = 100f;
    public float firerate = 20f;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject ImpactEffect;

    private float nextfire = 0f;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextfire )
        {
            nextfire = Time.time + 1f/firerate;
            shoot();
        }
    }
    void shoot()
    {
        muzzleFlash.Play();

        RaycastHit hitInfo;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward,out hitInfo, range))
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.takeDamage(damage);
            }

            GameObject impeff = Instantiate(ImpactEffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
            Destroy(impeff,1f);
        }
    }
}
