using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	
	private Transform target;

	public GameObject impactEffect;
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
		GameObject effectInst = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (target.gameObject);
		Destroy (effectInst, 2f);
		Destroy (gameObject);
	}

}
