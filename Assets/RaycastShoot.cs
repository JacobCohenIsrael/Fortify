using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

    public int gunDamage = 50;
    public float fireRate = 0.25f;
    public float weaponRange = 50;
    public float hitForce = 100f;
    public Transform gunEnd;
    public Camera mainCamera;

    private WaitForSeconds shotDuratoin = new WaitForSeconds(0.7f);
    private LineRenderer laserLine;
    private float nextFire;


	void Start () {
        laserLine = GetComponent<LineRenderer>();
        mainCamera = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(shotEffect());

            Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (mainCamera.transform.forward * weaponRange));
            }
        }
	}

    private IEnumerator shotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuratoin;
        laserLine.enabled = false;
    }
}
