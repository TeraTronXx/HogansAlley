using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletHandler : MonoBehaviour {

    private ParticleSystem ps;
    private AudioSource audioSource;
    private Rigidbody rb;

    [SerializeField]
    private AudioClip hitSound;

    public float impulseMagnitude = 20f;

	// Use this for initialization
	void Start () {

        ps = GetComponent<ParticleSystem>();
        if (ps == null)
            Debug.Log("No se ha encontrado el sistema de particulas");

        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
            Debug.Log("No se ha encontrado el audioSource en la bala");

        rb = GetComponent<Rigidbody>();

        

    }

    public void Shoot(Vector3 dir)
    {
        Start();
        rb.AddForce(dir * impulseMagnitude, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {

        ps.Play();
        /* forma 1*/
        //audioSource.clip = hitSound;
        //audioSource.Play();


        /* forma 2 */
        audioSource.PlayOneShot(hitSound);
        
    }

}
