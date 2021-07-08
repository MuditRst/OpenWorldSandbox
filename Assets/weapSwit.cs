
using UnityEngine;

public class weapSwit : MonoBehaviour
{
    public int Selectedweapon = 0;
    void Start()
    {
        Selectweapon();
    }

    // Update is called once per frame
    void Update()
    {
        int prevWeap = Selectedweapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(Selectedweapon >= transform.childCount - 1)
            {
                Selectedweapon = 0;
            }else
            {
                Selectedweapon++;
            }
        } 
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(Selectedweapon <= 0)
            {
                Selectedweapon = transform.childCount - 1;
            }else
            {
                Selectedweapon--;
            }
        }
        
        if(prevWeap != Selectedweapon)
        {
            Selectweapon();
        }
          
    }
    void Selectweapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == Selectedweapon)
            {
                weapon.gameObject.SetActive(true);
            }else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
