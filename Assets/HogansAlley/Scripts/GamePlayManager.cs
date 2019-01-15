using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

    static GamePlayManager instance;
    
    [HideInInspector]
    public float points = 0f;
    public float playTime = 60f;

    public TextMesh textMesh;

	// Use this for initialization
	void Start () {

        if (instance == null)
            instance = this;
		
	}

    public static GamePlayManager GetInstance()
    {
        return instance;
    }
	
	// Update is called once per frame
	void Update () {

        playTime = playTime - Time.deltaTime;
        if (playTime < 0)
        {
            Application.Quit();
        }
        textMesh.text = "Puntos: \n " + points + "\n Tiempo; \n" + playTime + "s";
        

	}
}
