using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    [Header("GameObjects tipo Texto del canvas")]
    public Text score; // GameObject de texto del score 
    public Text gameOverText; // GameObject de texto Gameover
    public GameObject panelCreditos;
    [Header("Variables")]
    public int scoreInt = 0; // Score en valor entero
    public int balls = 3; // pelotas activas en la escena
	// Use this for initialization
	void Start () {
        score.text = "0000"; // ponemos el texto en 0
        gameOverText.gameObject.SetActive(false); // hacemos invisible el gameobject de texto GameOver
	}
	
	public void AddScore() {
        scoreInt += 1; // agrega +1 al valor entero de Score
        /* el metodo "ToString()" convierte un valor del tipo entero a tipo string
         * se hace esto porque el GameObject de texto solo acepta String como texto
         * el metodo PadLeft(entero, char) hace rellenar el texto con el caracter que pasemos y nunca va atener mas ni menos caracteres que el entero que pasemos
         */
        score.text = scoreInt.ToString().PadLeft(4, '0');
    }
    public void SubstractBall()
    {
        balls -= 1;
        if(balls <= 0)
        {

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
