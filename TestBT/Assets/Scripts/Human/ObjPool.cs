using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Prefab Name

public enum EPrefabsName
{
    Area = 0,
    AreaEffect,
    FlyAttackArrow,
    FlyAttackEffect,
    ChargingFullSwing,
    FullSwingEffect,
    HealWeapon
}

public enum EBloodPrefabsName
{
    Blood1 = 0,
    Blood2,
    Blood2L,
    Blood2R,
    Blood3,
    Blood4,
    Blood5,
    Blood6,
    Blood7,
    Blood8,
    Blood9,
    Blood10,
    Blood11,
    Blood12,
    Blood13,
    Blood14,
    Blood15,
}
#endregion

public class ObjPool : MonoBehaviour
{
    // 생성할 프리팹들을 담아둘 클래스

    #region Prefabs Class

    public Prefabs[] prefab;
    public BloodPrefabs[] bloodPrefab;

    [Serializable]
    public class Prefabs
    {
        public GameObject prefab;
        public int produceCount;
        public EPrefabsName objectName;
        public Queue<GameObject> objectQueue = new Queue<GameObject>();
        [HideInInspector] public Transform objectTransform;
    }

    [Serializable]
    public class BloodPrefabs
    {
        public GameObject prefab;
        public int produceCount;
        public EBloodPrefabsName objectName;
        public Queue<GameObject> objectQueue = new Queue<GameObject>();
        [HideInInspector] public Transform objectTransform;
    }

    #endregion

    public static ObjPool Instance { get; private set; }

    // 프리팹들을 처음에 생성하고 비활성화 시킴

    #region Make Parent

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
        CreatePrefabsParent();
    }

    private void CreatePrefabsParent()
    {
        for (var i = 0; i < prefab.Length; i++)
        {
            var _obj = new GameObject(prefab[i].objectName.ToString());
            prefab[i].objectTransform = _obj.transform;
            _obj.transform.SetParent(this.transform);
            SetPool(prefab[i], prefab[i].produceCount);
        }

        for (var i = 0; i < bloodPrefab.Length; i++)
        {
            var _obj = new GameObject(bloodPrefab[i].objectName.ToString());
            bloodPrefab[i].objectTransform = _obj.transform;
            _obj.transform.SetParent(this.transform);
            SetPool(bloodPrefab[i], bloodPrefab[i].produceCount);
        }
    }

    private static void SetPool(Prefabs prefab, int count)
    {
        for (var i = 0; i < count; i++)
        {
            prefab.objectQueue.Enqueue(CreateNewObj(prefab));
        }
    }

    private static void SetPool(BloodPrefabs prefab, int count)
    {
        for (var i = 0; i < count; i++)
        {
            prefab.objectQueue.Enqueue(CreateNewObj(prefab));
        }
    }

    private static GameObject CreateNewObj(Prefabs prefab)
    {
        var obj = Instantiate(prefab.prefab);
        obj.SetActive(false);
        obj.transform.SetParent(prefab.objectTransform);
        return obj;
    }

    private static GameObject CreateNewObj(BloodPrefabs prefab)
    {
        var obj = Instantiate(prefab.prefab);
        obj.SetActive(false);
        obj.transform.SetParent(prefab.objectTransform);
        return obj;
    }

    private static Prefabs FindPrefabName(EPrefabsName name)
    {
        for (var i = 0; i < Instance.prefab.Length; i++)
        {
            if (Instance.prefab[i].objectName == name)
            {
                return Instance.prefab[i];
            }
        }

        return null;
    }

    private static BloodPrefabs FindPrefabName(EBloodPrefabsName name)
    {
        for (var i = 0; i < Instance.bloodPrefab.Length; i++)
        {
            if (Instance.bloodPrefab[i].objectName == name)
            {
                return Instance.bloodPrefab[i];
            }
        }

        return null;
    }

    #endregion

    // 프리팹을 가져옴
    public GameObject GetObject(EPrefabsName prefabName)
    {
        var currentPrefab = FindPrefabName(prefabName);

        if (currentPrefab.objectQueue.Count > 0)
        {
            var obj = currentPrefab.objectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var obj = CreateNewObj(currentPrefab);
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
    }

    public GameObject GetObject(EBloodPrefabsName BloodName)
    {
        var currentPrefab = FindPrefabName(BloodName);
        if (currentPrefab.objectQueue.Count > 0)
        {
            var obj = currentPrefab.objectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var obj = CreateNewObj(currentPrefab);
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
    }

    // 풀링에 반환
    public void ReturnObject(GameObject obj, EPrefabsName name)
    {
        var currentPrefab = FindPrefabName(name);

        obj.gameObject.SetActive(false);
        obj.transform.SetParent(currentPrefab.objectTransform.transform);
        currentPrefab.objectQueue.Enqueue(obj);
    }

    public void ReturnObject(GameObject obj, EBloodPrefabsName BloodName)
    {
        var currentPrefab = FindPrefabName(BloodName);

        obj.gameObject.SetActive(false);
        obj.transform.SetParent(currentPrefab.objectTransform.transform);
        currentPrefab.objectQueue.Enqueue(obj);
    }
    
    // 일정시간 딜레이후 반환
    public void ReturnObject(GameObject obj, EPrefabsName name, float time)
    {
        StartCoroutine(DelayReturn(obj, name, time));
    }

    private IEnumerator DelayReturn(GameObject obj, EPrefabsName name, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnObject(obj, name);
    }
    
    public void ReturnObject(GameObject obj, EBloodPrefabsName BloodName, float time)
    {
        StartCoroutine(DelayReturn(obj, BloodName, time));
    }

    private IEnumerator DelayReturn(GameObject obj, EBloodPrefabsName name, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnObject(obj, name);
    }
}