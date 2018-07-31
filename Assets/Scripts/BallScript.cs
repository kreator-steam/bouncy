using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
   public Rigidbody2D thisRigidBody;
    AudioSource thisAudioSource;

	// Use this for initialization
	void Start () {
        thisRigidBody = GetComponent<Rigidbody2D>(); // obtiene el componenete rigidbody pegado a el Gameobject (lol)
        thisAudioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnBecameInvisible() // se invoca cuando el gameobject deja de ser visible por la camara
    {
        if (thisRigidBody != null)
        {
            thisRigidBody.gravityScale = Random.Range(0.5f, 1.2f);// modifica el valor de grvedad
            // Random.Range(float,float) genera un numero aleatorio entre el primer valor y el segundo (tambien puede caer en el primero o el segundo valor)
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            FindObjectOfType<GameManagerScript>().SubstractBall();// invoca la funcion 
            Destroy(this.gameObject);// se destruye asi mismo (como las drogas)
        }
    }
    public void PlaySound()
    {
        if (thisAudioSource.isPlaying)
            thisAudioSource.Stop();
        thisAudioSource.Play();
    }
}
