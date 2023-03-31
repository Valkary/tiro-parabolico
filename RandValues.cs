using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Clase que genera valores aleatorios para las propiedades de un objeto
public class RandValues: MonoBehaviour
{
  // Constante k
  // Valores enteros
  public float lwrK = 20000.0f;
  public float uprK = 40000.0f;
  public float rK;

  // Tiempo T
  public float lwrT = 0.5f;
  public float uprT = 3.5f;
  public float rT;

  // Gravedad
  public float lwrGrvt = 1.0f;
  public float uprGrvt = 5.0f;
  public float rGrvt;

  // Altura de la plataforma
  // Valores enteros
  public float lwrPlatHgt = 0.0f;
  public float uprPlatHgt = 150.0f;
  public float rPlatHgt;

  // Altura del objetivo
  // Valores enteros
  public float lwrTrgrHgt = 0.0f;
  public float uprTrgrHgt = 150.0f;
  public float rTrgrHgt;
  
  // Masa del proyectil
  public float lwrPrjMass = 1.0f;
  public float uprPrjMass = 3.0f;
  public float rPrjMass;

  // Distancia (basada en T)
  public float rDist;

  // Genera todas las variables aleatorias usando UnityEngine.Random para las propiedades de los prefabs
  public float[] GenerateValues()
  {
    // Genera valores aleatorios para todas las propiedades
    rK       = UnityEngine.Random.Range(lwrK, uprK);
    rT       = UnityEngine.Random.Range(lwrT, uprT);
    rGrvt    = UnityEngine.Random.Range(lwrGrvt, uprGrvt);
    rPlatHgt = UnityEngine.Random.Range(lwrPlatHgt, uprPlatHgt);
    rTrgrHgt = UnityEngine.Random.Range(lwrTrgrHgt, uprTrgrHgt);
    rPrjMass = UnityEngine.Random.Range(lwrPrjMass, uprPrjMass);

    // Redondea los valores que deben ser enteros
    rK       = (float)Math.Round(rK);
    rPlatHgt = (float)Math.Round(rPlatHgt); 
    rTrgrHgt = (float)Math.Round(rTrgrHgt);

    // Ajusta la altura de la plataforma si es mayor que la altura del objetivo
    if(rPlatHgt > rTrgrHgt){
      rPlatHgt = UnityEngine.Random.Range(lwrPlatHgt, rTrgrHgt);
    }
  
    // Calcula la distancia del proyectil usando una fórmula
    rDist    = 12 * Mathf.Pow(rT, 3) + 5 * Mathf.Pow(rT, 2) + 3 * rT + 10;

    // Retorna los valores aleatorios en un array
    float[] initialVal = new float[7] {rK, rT, rGrvt, rPlatHgt, rTrgrHgt, rPrjMass, rDist};
    return initialVal;
  }

  // Generates Test Case Values
  public float[] GenerateTestValues()
  {
    rK       = 20000.0f;
    rT       = 2.0f;
    rGrvt    = 8.0f;
    rPlatHgt = 60.0f;
    rTrgrHgt = 150.0f;
    rPrjMass = 2.0f;
    
    rDist    = 12 * Mathf.Pow(rT, 3) + 5 * Mathf.Pow(rT, 2) + 3 * rT + 10;
    Debug.Log("Distancia = " + rDist);

    float[] initialVal = new float[7] { rK, rT, rGrvt, rPlatHgt, rTrgrHgt, rPrjMass, rDist };
    return initialVal;
  }
}
