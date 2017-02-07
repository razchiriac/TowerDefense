using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	
	private Transform target;

	public float speed = 70f;

	// pass the target from the turret to the bullet
	public void Seek (Transform _target)
	{
		target = _target;
	}

	void Update ()
	{
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		// if we hit something
		if (dir.magnitude <= distanceThisFrame) {
			HitTarget ();
			return;
		}

		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget ()
	{
		Debug.Log ("Bullet has hit Target!");
		// hit logic

		Destroy (gameObject);
	}

}
