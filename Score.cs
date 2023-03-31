using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int _Score;

    public int ScorePerShot = 5;
	public TxtMng _TxtMng;

	void Start(){
		ClearScore();
	}

    public void ClearScore(){
	    _Score = 0;
		_TxtMng.SetScoreText(_Score);
	}

	public void AddScore(){
	    _Score += ScorePerShot;
		_TxtMng.SetScoreText(_Score);
	}
	
}