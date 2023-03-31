using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
	public  float    _HeightLimit;
	private Vector3  _InitialPosition;

	private Score    _Score;
	private MatchMng _MatchMng;

	void Start()
	{
        _Score    = GameObject.Find("Mng").GetComponent<Score>();
        _MatchMng = GameObject.Find("Mng").GetComponent<MatchMng>();
		
		_InitialPosition = gameObject.GetComponent<Transform>().position;
	}

	void Update()
	{
		float actualHeight = gameObject.GetComponent<Transform>().position.y; 
		if (actualHeight <= _HeightLimit) {
			gameObject.GetComponent<Transform>().position = _InitialPosition;
			_MatchMng.shoot = false;
		}
	}

	// Bullseye hit
	void OnCollisionEnter(Collision collision)
	{
		_MatchMng.shotEnded = true;
		_Score.AddScore();
		Destroy(gameObject);
	}
}