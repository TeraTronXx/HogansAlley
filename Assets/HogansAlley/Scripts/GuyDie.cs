using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyDie : MonoBehaviour {

    public float minStayTime = 3f;
    public float maxStayTime = 5f;

    public float pointsHit = 0f;
    public float pointsMiss = 0f;

    private float waitTime = 0f;

    Animator anim;


    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        waitTime = Random.Range(minStayTime, maxStayTime);
        StartCoroutine(Stay());

	}

    IEnumerator Stay()
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetTrigger("DieNow");

        //TODO: quitar puntos si es enemigo -> pointsMiss
        GamePlayManager.GetInstance().points += pointsMiss;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BulletHandler>() != null)
        {
            anim.SetTrigger("DieNow");
            //TODO: si es malo sumar puntos y si es bueno restar puntos. 
            GamePlayManager.GetInstance().points += pointsHit;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
