using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //bool alive = true;
    //public float shootInterval;
    public GameObject bulletPrefab;
    public Transform firePointPos;

    public Animator thisAnimator;

    public EnemySpawner myLaneSpawner;
    /*private IEnumerator Start()
    {
        while (alive)
        {
            yield return new WaitForSeconds(shootInterval);
            Shoot();
        }
    }*/
    private void Start()
    {
        thisAnimator = GetComponent<Animator>();
        MyLaneSpawnerIs();
    }
    void Shoot()
    {

        GameObject spawnedBullet=Instantiate(bulletPrefab, firePointPos.transform.position, Quaternion.identity);

        spawnedBullet.transform.SetParent(this.gameObject.transform);
    }
    private void MyLaneSpawnerIs()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
    private void Update()
    {
        if(AttackerInLane())
        {
            thisAnimator.SetBool("EnemyInLane", true);
        }
        else
        {
            thisAnimator.SetBool("EnemyInLane", false);
        }
    }
    public bool AttackerInLane()
    {
        if(myLaneSpawner.transform.childCount<=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
