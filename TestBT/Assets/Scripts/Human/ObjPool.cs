using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용할 프리팹들을 열거형으로 정의 편의를 위해 피와 스킬 이펙트의 열거형을 다르게 정의함
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

public class ObjPool : MonoBehaviour
{
    // 생성할 프리팹들을 담아둘 클래스

    #region Prefabs Class

    public Prefabs[] m_Prefab;
    public BloodPrefabs[] m_BloodPrefab;

    [Serializable]
    public class Prefabs
    {
        public GameObject m_Prefab;
        public int m_ProduceCount;
        public EPrefabsName m_ObjectName;
        public Queue<GameObject> m_ObjectQueue = new Queue<GameObject>();
        [HideInInspector] public Transform m_ObjectTransform;
    }

    [Serializable]
    public class BloodPrefabs
    {
        public GameObject m_Prefab;
        public int m_ProduceCount;
        public EBloodPrefabsName m_ObjectName;
        public Queue<GameObject> m_ObjectQueue = new Queue<GameObject>();
        [HideInInspector] public Transform m_ObjectTransform;
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
        for (var i = 0; i < m_Prefab.Length; i++)
        {
            var obj = new GameObject(m_Prefab[i].m_ObjectName.ToString());
            m_Prefab[i].m_ObjectTransform = obj.transform;
            obj.transform.SetParent(this.transform);
            SetPool(m_Prefab[i], m_Prefab[i].m_ProduceCount);
        }

        for (var i = 0; i < m_BloodPrefab.Length; i++)
        {
            var obj = new GameObject(m_BloodPrefab[i].m_ObjectName.ToString());
            m_BloodPrefab[i].m_ObjectTransform = obj.transform;
            obj.transform.SetParent(this.transform);
            SetPool(m_BloodPrefab[i], m_BloodPrefab[i].m_ProduceCount);
        }
    }

    private static void SetPool(Prefabs prefab, int count)
    {
        for (var i = 0; i < count; i++)
        {
            prefab.m_ObjectQueue.Enqueue(CreateNewObj(prefab));
        }
    }

    private static void SetPool(BloodPrefabs prefab, int count)
    {
        for (var i = 0; i < count; i++)
        {
            prefab.m_ObjectQueue.Enqueue(CreateNewObj(prefab));
        }
    }

    private static GameObject CreateNewObj(Prefabs prefab)
    {
        var obj = Instantiate(prefab.m_Prefab);
        obj.SetActive(false);
        obj.transform.SetParent(prefab.m_ObjectTransform);
        return obj;
    }

    private static GameObject CreateNewObj(BloodPrefabs prefab)
    {
        var obj = Instantiate(prefab.m_Prefab);
        obj.SetActive(false);
        obj.transform.SetParent(prefab.m_ObjectTransform);
        return obj;
    }

    private static Prefabs FindPrefabName(EPrefabsName name)
    {
        for (var i = 0; i < Instance.m_Prefab.Length; i++)
        {
            if (Instance.m_Prefab[i].m_ObjectName == name)
            {
                return Instance.m_Prefab[i];
            }
        }

        return null;
    }

    private static BloodPrefabs FindPrefabName(EBloodPrefabsName name)
    {
        for (var i = 0; i < Instance.m_BloodPrefab.Length; i++)
        {
            if (Instance.m_BloodPrefab[i].m_ObjectName == name)
            {
                return Instance.m_BloodPrefab[i];
            }
        }

        return null;
    }

    #endregion

    // 프리팹을 가져옴
    public GameObject GetObject(EPrefabsName prefabName)
    {
        var currentPrefab = FindPrefabName(prefabName);

        if (currentPrefab.m_ObjectQueue.Count > 0)
        {
            var obj = currentPrefab.m_ObjectQueue.Dequeue();
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

    public GameObject GetObject(EBloodPrefabsName name)
    {
        var currentPrefab = FindPrefabName(name);
        if (currentPrefab.m_ObjectQueue.Count > 0)
        {
            var obj = currentPrefab.m_ObjectQueue.Dequeue();
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
        obj.transform.SetParent(currentPrefab.m_ObjectTransform.transform);
        currentPrefab.m_ObjectQueue.Enqueue(obj);
    }

    public void ReturnObject(GameObject obj, EBloodPrefabsName name)
    {
        var currentPrefab = FindPrefabName(name);

        obj.gameObject.SetActive(false);
        obj.transform.SetParent(currentPrefab.m_ObjectTransform.transform);
        currentPrefab.m_ObjectQueue.Enqueue(obj);
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
    
    public void ReturnObject(GameObject obj, EBloodPrefabsName name, float time)
    {
        StartCoroutine(DelayReturn(obj, name, time));
    }

    private IEnumerator DelayReturn(GameObject obj, EBloodPrefabsName name, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnObject(obj, name);
    }
}