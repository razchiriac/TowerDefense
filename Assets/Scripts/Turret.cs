using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

	private Transform target;
	public float range = 15f;

	public string enemyTag = "Enemy";

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	// Does a renewed search for a target
	void UpdateTarget ()
	{
		// 1. Search all objects tagged "Enemy"
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		// 2. Find closest Enemy
		foreach(GameObject enemy in enemies){
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			// 3. Check if closest Enemy is within range
			if (distanceToEnemy < shortestDistance) {
				// 4. Set target equal to that object's transform
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target == null) {
			return;
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}

}
