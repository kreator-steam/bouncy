using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    [Header("Variables publicas")]
    //[Tooltip("es la velocidad con la que se mueve el carro")]
    //public float speedMovement = 3.0f;
    [Tooltip("Este se le asigna el script del GameManager para tener acceso a sus funciones y variables publicas")]
    public GameManagerScript GMscript;

	// Use this for initialization
	void Start () {
      //  GMscript = FindObjectOfType<GameManagerScript>();
		
	}
	
	// Update is called once per frame
	void Update () {
        // solo para ver el valor de time delta time
       // Debug.Log("Valor de Time.deltaTiame =  " + Time.deltaTime);
        /* Input es un arreglo que se puede modificar en el editor
         * Edit/Project Settigs/Input
         * Si quisieramos cambiar los botones habra que modificar los campos en "Axes" buscar Horizontal y mover los valores
         */
       
	}
    /* Esta funcion se "Activa" cuando se detecta una colision con otro GameObject que tambien tiene RigidBody2D
     * (Collision2D collision) es el objeto que colociono con el coche en este caso
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Se evalua si el objeto que coliciono tiene como "Tag" el valor "Ball"
         * entonces haz que la funcion llamada "AddScore", escrita en el Script GameManagerScript se active
         * Caso contrario no hacer nada
         */
        if(collision.gameObject.tag == "Ball")
        {
            GMscript.AddScore();
            collision.gameObject.GetComponent<BallScript>().PlaySound();
        }
    }
}
