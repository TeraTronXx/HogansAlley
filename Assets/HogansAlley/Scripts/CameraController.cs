using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraController : MonoBehaviour {

    Vector3 lastMouse = new Vector3 (255, 255, 2555);

    public GameObject bulletPrefab;

    [Range(0f, 1f)]
    public float camSens = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CameraPosition();

        if (!XRSettings.enabled)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootABullet();
            }
        }
        else
        {
            foreach (Touch touch in Input.touches)
            {
                if(touch.phase == TouchPhase.Began)
                {
                    ShootABullet();
                }
            }
        }
		
	}

    private void ShootABullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        BulletHandler bh = bullet.GetComponent<BulletHandler>();
        bh.Shoot(transform.forward);
        Destroy(bullet, 3f);

    }

    void CameraPosition()
    {
        if (!XRSettings.enabled)
        {


            Vector3 deltaMouse = Input.mousePosition - lastMouse;
            deltaMouse = deltaMouse * camSens;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x - deltaMouse.y, transform.eulerAngles.y + deltaMouse.x, 0);
            lastMouse = Input.mousePosition;
        }
    }

}
