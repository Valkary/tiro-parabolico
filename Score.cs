using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Creo que esta clase se explica sola pero xD aqui ando
public class Score : MonoBehaviour
{
  // Se inicializan variables
  public static int _Score;

  public int ScorePerShot = 5;
	public TxtMng _TxtMng;

  // Esta funcion es un poco random pero ps asi venia
	void Start(){
		ClearScore();
	}

  // Regresamos el valor de _Score a 0 y actualizamos el texto que lo muestra
  public void ClearScore(){
    _Score = 0;
    _TxtMng.SetScoreText(_Score);
	}

  // actualizamos el valor de _Score y el texto que lo muestra
	public void AddScore(){
    _Score += ScorePerShot;
		_TxtMng.SetScoreText(_Score);
	}
}
