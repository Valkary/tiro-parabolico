using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    // Límite de altura antes de que el proyectil sea destruido
    public float _HeightLimit;

    // Posición inicial del proyectil
    private Vector3 _InitialPosition;

    // Referencias a otros scripts
    private Score _Score;
    private MatchMng _MatchMng;

    void Start()
    {
      // Obtiene referencias a otros scripts
      _Score = GameObject.Find("Mng").GetComponent<Score>();
      _MatchMng = GameObject.Find("Mng").GetComponent<MatchMng>();

      // Obtiene la posición inicial del proyectil
      _InitialPosition = gameObject.GetComponent<Transform>().position;
    }

    void Update()
    {
      // Comprueba si la altura actual del proyectil es menor o igual al límite de altura
      float actualHeight = gameObject.GetComponent<Transform>().position.y;
      if (actualHeight <= _HeightLimit)
      {
        // Si es así, devuelve el proyectil a su posición inicial y establece que no se ha realizado ningún disparo
        gameObject.GetComponent<Transform>().position = _InitialPosition;
        _MatchMng.shoot = false;
      }
    }

  // Cuando el proyectil colisiona con el Bullseye
  void OnCollisionEnter(Collision collision)
  {
    // Establece que el disparo ha terminado, suma la puntuación y destruye el proyectil
    _MatchMng.shotEnded = true;
    _Score.AddScore();
    Destroy(gameObject);
  }
}

