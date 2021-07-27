using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletBound : MonoBehaviour
{
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        

        if(other.CompareTag("Bullet"))
        {
            
            Destroy(other.gameObject);
        }
        
    }
}
