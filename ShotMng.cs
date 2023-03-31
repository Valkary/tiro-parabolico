using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ShotMng : MonoBehaviour
{
    // Inputs
    public TMP_InputField AngleText;
    public TMP_Text SpringText;

  

    public float[] GenerateShot(GameObject _Projectile, float grvt, float mass, float k)
    {
        float angle = 74.04741398f, spring = 0.5f; // Test Case
        // float angle = 37.79384353f, spring = 0.95f; // Test Case
        // float angle = float.Parse(AngleText.text);
        // float spring = float.Parse(SpringText.text);

        double angleRad = Math.PI * angle / 180.0;
        float x = (float)Math.Cos(angleRad);
        float y = (float)Math.Sin(angleRad);
        double Vo = Math.Sqrt(k * Mathf.Pow((float)spring, 2) / mass);

        float[] inputs = new float[2] { angle, spring };

        Rigidbody ball = _Projectile.GetComponent<Rigidbody>();
        Physics.gravity = Vector3.up * -grvt;
        ball.useGravity = true;
        ball.mass = mass;
        ball.velocity = _Projectile.transform.TransformDirection((float)Vo * (new Vector3(x, y, 0.0f)));

        return inputs;
    }
}
