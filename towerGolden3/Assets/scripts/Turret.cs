using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [Header("Attributes")]

    private GameObject Zamok;
	public float range = 10f;
	public float damage = 1f;
    public int turretprice;

	public float fireCountdown = 0f;

	[Header("Unity Setup Fields")]
	public string enemyTag = "Enemy";

	public Transform target;

	public GameObject bulletPrefab;
	public Transform firePoint;
   

    void Start ()
    {
        InvokeRepeating ("UpdateTarget", 0f, 0.1f);
        Zamok = GameObject.FindGameObjectWithTag("Zamok");
    }

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
        float shortestDistance = Mathf.Infinity;
      
        GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) 
		{

            float distanceToZamok = Vector3.Distance(Zamok.transform.position, enemy.transform.position);
            if (distanceToZamok < shortestDistance)
            {
                shortestDistance = distanceToZamok;
                nearestEnemy = enemy;
            }
        }

        if (shortestDistance <= range && nearestEnemy != null)
       
        {
			target = nearestEnemy.transform;
		} else 
		{
			target = null;
		}

    }

	void Update () {
		if (target == null) {
			return;
		}

		if (fireCountdown <= 0f)
		{
			ShootTarget ();
			fireCountdown = 1f / damage;
		}

		fireCountdown -= Time.deltaTime;

	}

	void ShootTarget()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null) {
			bullet.Seek (target);
		}
	}

}
