using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    private string recordFileName = "recordFile.txt";

    public GameObject canvaStart;
    public GameObject canva1;
    /*public Button yourButton;


    // Start is called before the first frame update
    void Start()
    {
        yourButton.GetComponent<Button>().onClick.AddListener(changeCanva);
    }*/

    public void changeCanva()
    {

        System.IO.File.AppendAllText(recordFileName, "----------------------------------------\n");
        //SceneManager.LoadScene(nameScene);
        canvaStart.SetActive(false);
        canva1.SetActive(true);
        Debug.Log("You are in");

    }
}
