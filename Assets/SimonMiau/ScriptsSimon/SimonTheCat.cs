using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonTheCat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D objetoQueColiciona)
    {
        if(objetoQueColiciona.gameObject.tag == "GoodBoy")
        {
            Debug.Log("sumale uno");
            FindObjectOfType<GameManagerSimon>().AddScore();
        }
        else
        {
            Debug.Log("Restale 1");
            FindObjectOfType<GameManagerSimon>().SubstractScore();
        }
        Destroy(objetoQueColiciona.gameObject);
    }
}
