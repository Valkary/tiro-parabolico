using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timer_start;
    public float timer_end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer_start += Time.deltaTime;

        if (timer_start >= timer_end) 
        {
            SceneManager.LoadScene("end");
        }
    }
}


