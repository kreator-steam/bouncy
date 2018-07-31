using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoScript : MonoBehaviour {
    [Header("Direcciones en que se Mueve")]
    [Tooltip("Movimiento vertical")]
    public bool seMueveEnY;
    [Tooltip("Se mueve en Horizontal")]
    public bool seMueveEnX = true;
    [Tooltip("Velocidad de movimiento")]
    public float speed = 3.0f;
    [Header("Variables de muestra no modificar")]
    public float anchoDePantalla;
    public float altoDePantalla;

    
	// Use this for initialization
	void Start () {
        //////Obtener el Ancho y alto de pantalla
        Camera cam = Camera.main; //// obtenemos la camara
        Vector3 esquinaDeArriba = new Vector3(Screen.width, Screen.height, 0.0f);// Obtenemos la esquina superior derecha de la pantalla en pixeles
        //valores del vector x = ancho de pantalla en pixeles, y = Alto de Pantall en pixeles , Z= 0 (la pantalla es 2D)
        Vector3 pantallaEnPosicionesDelMundo = cam.ScreenToWorldPoint(esquinaDeArriba); // se convierte de pixeles a coordenadas del mundo del juego

        anchoDePantalla = pantallaEnPosicionesDelMundo.x;// limnite de pantalla en x en espacio del mundo
        altoDePantalla = pantallaEnPosicionesDelMundo.y; // limite en pantall en y en escacio del mundo


		
	}
	
	// Update is called once per frame
	void Update () {
        if (seMueveEnX)
        {
            Vector3 vectorMovimientoX = Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            if((transform.position + vectorMovimientoX).x >= -anchoDePantalla && (transform.position + vectorMovimientoX).x <= anchoDePantalla)
            {
                transform.Translate(vectorMovimientoX);
            }

        }
        if (seMueveEnY)
        {
            Vector3 vectorMovimientoY = Vector2.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
            if ((transform.position + vectorMovimientoY).y >= -altoDePantalla && (transform.position + vectorMovimientoY).y <= altoDePantalla)
            {
                transform.Translate(vectorMovimientoY);
            }
        }
		
	}
}
