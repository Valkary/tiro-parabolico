using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MatchMng : MonoBehaviour
{
  // Declaración de variables y objetos
  public GameObject canva1; // Objeto Canvas 1
  public GameObject canvaEnd; // Objeto Canvas End
  public int TotalShots; // Total de tiros
  public float TimePerShot; // Tiempo por tiro
  private float _MatchTimer; // Temporizador de la partida
  private float _ShotTimer; // Temporizador del tiro
  private bool MatchStarted = false; // Indica si la partida ha comenzado
  private bool ShotStarted  = false; // Indica si el tiro ha comenzado
  public float timer_start; // Tiempo de inicio
  public float timer_end; // Tiempo de finalización
  public int shots; // Número de tiros realizados
  public bool shoot = false; // Indica si se ha realizado un disparo
  public bool shotEnded = false; // Indica si el tiro ha terminado
  private string recordFileName = "recordFile.txt"; // Nombre del archivo de registro
  private float[] initialVal; // Valores iniciales
  public ObjMng _ObjMng; // Objeto ObjMng
  public TxtMng _TxtMng; // Objeto TxtMng
  public ShotMng _ShotMng; // Objeto ShotMng
  public RandValues _RndVals; // Objeto RandValues

  // Función Update, se ejecuta en cada cuadro
  void Update()
  {
    // Comienza el temporizador de la partida si MatchStarted es verdadero
    if (MatchStarted)
    {
      _MatchTimer += Time.deltaTime;
      // Comienza el temporizador del tiro si no se ha realizado un disparo
      if (!shoot) {
        _ShotTimer -= Time.deltaTime;
      }
      // Establece el texto del temporizador
      _TxtMng.SetTimerText(_MatchTimer, _ShotTimer);

      // Si el temporizador del tiro se ha acabado o el tiro ha terminado, se ejecuta NewShot()
      if (_ShotTimer <= 0 || shotEnded)
      {
        NewShot();
      }

      timer_start += Time.deltaTime;

      // Si el tiempo ha superado el tiempo de finalización, se termina la partida
      if (timer_start >= timer_end)
      {
        MatchStarted = false;
        canva1.SetActive(false);
        canvaEnd.SetActive(true);
        // Registra los resultados en el archivo de registro
        string line="Final Shots: "+shots+" - Score: "+ Score._Score;
        System.IO.File.AppendAllText(recordFileName, line + "\n");
        // Destruye todos los objetos
        _ObjMng.DestroyAll();
        //SceneManager.LoadScene("end");
      }
    }
  }

  // OnClick BtnStart
  public void StartMatch()
  {
    _MatchTimer  = 0;
    MatchStarted = true;
    
    shots=0;
    NewShot();
  }

  // OnClick BtnShoot
  public void ShootProjectile() {
    // Indica que se ha iniciado un disparo
    shoot = true;
    // Genera valores aleatorios para el ángulo y la velocidad del proyectil
    float[] inputs =_ShotMng.GenerateShot(_ObjMng._Projectile, _RndVals.rGrvt, _RndVals.rPrjMass, _RndVals.rK);

    // Actualiza la cantidad de disparos realizados
    shots += 1;
    // Actualiza el texto de la UI que muestra la cantidad de disparos realizados
    _TxtMng.SetShotText(shots);

    // Obtiene la fecha y hora actual para registrar los valores iniciales y los valores de entrada generados para el disparo
    System.DateTime dateTime = System.DateTime.Now;
    string timestamp = "[" + dateTime.ToString("yyyy/MM/dd_HH:mm:ss_fff") + "]";
    string line = timestamp + "," + shots + ", Values["+initialVal[0]+","+ initialVal[1] +","+ initialVal[2] + "," + initialVal[3] + ","+initialVal[4] + ","+initialVal[5] + ","+initialVal[6] + "], Inputs["+inputs[0]+","+inputs[1]+"]";

    // Agrega una línea al archivo recordFileName con los valores iniciales y los valores de entrada generados para el disparo
    System.IO.File.AppendAllText(recordFileName, line + "\n");
  }

    // When _ShotTimer is over resets all with new values
    public void NewShot()
    {
      if (ShotStarted) {
        _ObjMng.DestroyAll();
      }

      ShotStarted = true;
      shoot       = false;
      shotEnded   = false;
      _ShotTimer  = TimePerShot;

      //initialVal = _RndVals.GenerateValues();
      initialVal = _RndVals.GenerateTestValues();
      _ObjMng.InstantiatePrefabs(_RndVals.rPlatHgt, _RndVals.rDist, _RndVals.rTrgrHgt);
      _TxtMng.SetValuesText(_RndVals.rPrjMass, _RndVals.rT, _RndVals.rGrvt,
              _RndVals.rK, _RndVals.rTrgrHgt, _RndVals.rPlatHgt);
    }
}
