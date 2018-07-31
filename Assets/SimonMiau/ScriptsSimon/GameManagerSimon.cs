using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSimon : MonoBehaviour {
    [Header("GameObjects tipo Texto del canvas")]
    public Text score; // GameObject de texto del score 
    public Text gameOverText; // GameObject de texto Gameover
    public GameObject panelCreditos;
    [Header("Variables")]
    public int scoreInt = 0;
    [Header("Prefabs")]
    public GameObject pezBueno;
    public GameObject botaMala;
    [Header("Variables de muestra no modificar")]
    public float anchoDePantalla;
    public float altoDePantalla;

    [Header("Estados de Juego")]
    public bool seEstaJugando = true;


    // Use this for initialization
    void Start () {
        Camera cam = Camera.main; //// obtenemos la camara
        Vector3 esquinaDeArriba = new Vector3(Screen.width, Screen.height, 0.0f);// Obtenemos la esquina superior derecha de la pantalla en pixeles
        //valores del vector x = ancho de pantalla en pixeles, y = Alto de Pantall en pixeles , Z= 0 (la pantalla es 2D)
        Vector3 pantallaEnPosicionesDelMundo = cam.ScreenToWorldPoint(esquinaDeArriba); // se convierte de pixeles a coordenadas del mundo del juego

        anchoDePantalla = pantallaEnPosicionesDelMundo.x;// limnite de pantalla en x en espacio del mundo
        altoDePantalla = pantallaEnPosicionesDelMundo.y;
        score.text = "00000"; // ponemos el texto en 0
        gameOverText.gameObject.SetActive(false); // hacemos invisible el gameobject de texto GameOver
        StartCoroutine(CadaCaundoNaceElPez());
        StartCoroutine(CadaCaundoNacenLasBotas());
    }
	
	// Update is called once per frame
	void Update () {
        
		
	}
    IEnumerator CadaCaundoNaceElPez()
    {
        while (seEstaJugando)
        {
            NacePez();
            yield return new WaitForSeconds(Random.Range(1.3f, 2.5f));
        }
    }
    IEnumerator CadaCaundoNacenLasBotas()
    {
        while (seEstaJugando)
        {
            NaceBota();
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
    }
    public void NacePez()
    {
        Vector3 pezAleatorio = new Vector3(Random.Range(-anchoDePantalla, anchoDePantalla), altoDePantalla + .5f, 0);
        Instantiate(pezBueno, pezAleatorio, Quaternion.identity);
    }
    public void NaceBota()
    {
        Vector3 botaAleatoria = new Vector3(Random.Range(-anchoDePantalla, anchoDePantalla), altoDePantalla + .5f, 0);
        Instantiate(botaMala, botaAleatoria, Quaternion.identity);
    }
    public void AddScore()
    {
        scoreInt += 1;
        score.text = scoreInt.ToString().PadLeft(5, '0');

    }
    public void SubstractScore()
    {
        scoreInt -= 1;
        score.text = scoreInt.ToString().PadLeft(5, '0');
        if (scoreInt <= 0)
        {
            seEstaJugando = false;
            gameOverText.gameObject.SetActive(true);// activa el GameObject de texto gameover
            Invoke("ShowCredits", 1.5f);
        }
    }
    void ShowCredits()
    {
        gameOverText.gameObject.SetActive(false);
        panelCreditos.SetActive(true);
    }
}
