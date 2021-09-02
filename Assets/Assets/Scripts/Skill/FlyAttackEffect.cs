using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttackEffect : MonoBehaviour
{
    void Start()
    {
        ObjPool.ObjectPoolInstance.ReturnObject(this.gameObject,EPrefabsName.FLYATTACKEFFECT,5.0f);
    }

}
