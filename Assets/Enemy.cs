
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float damage = 15f;

    public void takeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider col)
    {
        col.gameObject.GetComponent<playerHealth>().takeDamagefromenemy(damage);
    }

}
