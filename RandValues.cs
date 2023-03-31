using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RandValues: MonoBehaviour
{
    // Constant k
    //valores enteros
    public float lwrK = 20000.0f;
    public float uprK = 40000.0f;
    public float rK;

    // T
    public float lwrT = 0.5f;
    public float uprT = 3.5f;
    public float rT;

    // Gravity
    public float lwrGrvt = 1.0f;
    public float uprGrvt = 5.0f;
    public float rGrvt;

    // Platform Height
    //alturas enteros
    public float lwrPlatHgt = 0.0f;
    public float uprPlatHgt = 150.0f;
    public float rPlatHgt;

    // Target Height
    //alturas que sean enteros
    public float lwrTrgrHgt = 0.0f;
    public float uprTrgrHgt = 150.0f;
    public float rTrgrHgt;
    
    // Projectile Mass
    public float lwrPrjMass = 1.0f;
    public float uprPrjMass = 3.0f;
    public float rPrjMass;

    // Distance (based on T)
    public float rDist;


    // Generates all the UnityEngine.Random variables for the prefabs values
    public float[] GenerateValues()
    {
       
        rK       = UnityEngine.Random.Range(lwrK, uprK);
        rT       = UnityEngine.Random.Range(lwrT, uprT);
        rGrvt    = UnityEngine.Random.Range(lwrGrvt, uprGrvt);
        rPlatHgt = UnityEngine.Random.Range(lwrPlatHgt, uprPlatHgt);
        rTrgrHgt = UnityEngine.Random.Range(lwrTrgrHgt, uprTrgrHgt);
        rPrjMass = UnityEngine.Random.Range(lwrPrjMass, uprPrjMass);


        rK = (float)Math.Round(rK);
        rPlatHgt = (float)Math.Round(rPlatHgt); 
        rTrgrHgt = (float)Math.Round(rTrgrHgt);
        //conditions
        if(rPlatHgt > rTrgrHgt){
            rPlatHgt = UnityEngine.Random.Range(lwrPlatHgt, rTrgrHgt);
        }
      
        rDist    = 12 * Mathf.Pow(rT, 3) + 5 * Mathf.Pow(rT, 2) + 3 * rT + 10;

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
