using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMng : MonoBehaviour
{
    // Prefabs
    public GameObject prefabPlatform;
    public GameObject prefabTarget;
    public GameObject prefabProjectile;
    public GameObject prefabBullseye ;

    // Instances
    public GameObject _Platform;
    public GameObject _Target;
    public GameObject _Projectile;
    public GameObject _Bullseye ;
    
    
    // Positions
    private Vector3 PlatformInitialPosition;
    private Vector3 TargetInitialPosition;

    public void InstantiatePrefabs(float platHgt, float dist, float trgrHgt)
    {
        PlatformInitialPosition = new Vector3(0, platHgt, 0);
        TargetInitialPosition   = new Vector3(dist, trgrHgt, 0);
        
        // Instantiate prefabs
        _Platform   = Instantiate(prefabPlatform,   PlatformInitialPosition, Quaternion.identity);
        _Target     = Instantiate(prefabTarget,     TargetInitialPosition,   Quaternion.identity);
        _Projectile = Instantiate(prefabProjectile, PlatformInitialPosition, Quaternion.identity);
        _Bullseye   = Instantiate(prefabBullseye,   TargetInitialPosition,   Quaternion.identity);

        float lowerHeight = platHgt;
        if (trgrHgt < lowerHeight) lowerHeight = trgrHgt;
        _Projectile.GetComponent<ProjectileDestroy>()._HeightLimit = lowerHeight;
    }

    public void DestroyAll() {
            Destroy(_Platform);
            Destroy(_Target);
            Destroy(_Projectile);
            Destroy(_Bullseye);
    }
}
