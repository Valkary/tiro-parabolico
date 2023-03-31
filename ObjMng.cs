using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMng : MonoBehaviour
{
  // Prefabs
  public GameObject prefabPlatform; // prefab de la plataforma
  public GameObject prefabTarget; // prefab del objetivo
  public GameObject prefabProjectile; // prefab del proyectil
  public GameObject prefabBullseye ; // prefab del "bullseye" (el centro del objetivo)

  // Instances
  public GameObject _Platform; // instancia de la plataforma
  public GameObject _Target; // instancia del objetivo
  public GameObject _Projectile; // instancia del proyectil
  public GameObject _Bullseye ; // instancia del "bullseye"

  // Positions
  private Vector3 PlatformInitialPosition; // posición inicial de la plataforma
  private Vector3 TargetInitialPosition; // posición inicial del objetivo

  // Este método se encarga de instanciar todos los prefabs en sus posiciones iniciales.
  public void InstantiatePrefabs(float platHgt, float dist, float trgrHgt)
  {
    PlatformInitialPosition = new Vector3(0, platHgt, 0); // posición inicial de la plataforma en el eje Y
    TargetInitialPosition   = new Vector3(dist, trgrHgt, 0); // posición inicial del objetivo en el eje X y Y
    
    // Instantiate prefabs (instanciar prefabs)
    _Platform   = Instantiate(prefabPlatform,   PlatformInitialPosition, Quaternion.identity); // instanciar la plataforma
    _Target     = Instantiate(prefabTarget,     TargetInitialPosition,   Quaternion.identity); // instanciar el objetivo
    _Projectile = Instantiate(prefabProjectile, PlatformInitialPosition, Quaternion.identity); // instanciar el proyectil
    _Bullseye   = Instantiate(prefabBullseye,   TargetInitialPosition,   Quaternion.identity); // instanciar el "bullseye" (centro del objetivo)

    // Obtener la altura más baja entre la plataforma y el objetivo.
    float lowerHeight = platHgt;
    if (trgrHgt < lowerHeight) lowerHeight = trgrHgt;

    // Configurar la altura máxima a la que el proyectil puede volar.
    _Projectile.GetComponent<ProjectileDestroy>()._HeightLimit = lowerHeight;
  }

  // Este método se encarga de destruir todas las instancias de los prefabs.
  public void DestroyAll() {
    Destroy(_Platform); // destruir la plataforma
    Destroy(_Target); // destruir el objetivo
    Destroy(_Projectile); // destruir el proyectil
    Destroy(_Bullseye); // destruir el "bullseye"
  }
}

