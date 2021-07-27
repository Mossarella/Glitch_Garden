using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public int health;
    public int maxHealth;


    public GameObject vfxParent;
    const string VFX_PARENT_NAME = "VFXGroup";

    public GameObject deathVFX;
    void Start()
    {
        health = maxHealth;
        CreateVfxParentGroup();
    }
    void CreateVfxParentGroup()
    {
        vfxParent = GameObject.Find(VFX_PARENT_NAME);

        if (!vfxParent)
        {
            vfxParent = new GameObject(VFX_PARENT_NAME);
        }
    }


    // Update is called once per frame
    

    public void TakeDamage(int damage)
    {
        if(health-damage<=0)
        {
            Die();
        }
        else if(health-damage>0)
        {

            health -= damage;
        }
        
    }
    void Die()
    {
        Destroy(this.gameObject);
        TriggerDeathVFX();
    }
    void TriggerDeathVFX()
    {
        if(deathVFX!=null)
        {
            GameObject deathEffect= Instantiate(deathVFX, transform.position, Quaternion.identity);
            deathEffect.transform.SetParent(vfxParent.transform);

            Destroy(deathEffect, 2f);
        }
    }
}
