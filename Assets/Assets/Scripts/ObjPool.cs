using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum EPrefabsName
{
    PLAYERSKILL
}

public class ObjPool : MonoBehaviour
{
    #region Prefabs Class

    public Prefabs[] m_Prefab;
    
    [System.Serializable]
    public class Prefabs
    {
        public GameObject m_Prefab;
        public int m_ProduceCount;
        public EPrefabsName m_ObjectName;
        public Queue<GameObject> m_ObjectQueue = new Queue<GameObject>();
        [HideInInspector] public Transform m_ObjectTransform;

    }
    
    #endregion

    public static ObjPool ObjectPoolInstance;

    #region Make Parent

    private void Awake()
    {
        if (ObjectPoolInstance != null && ObjectPoolInstance != this)
        {
            Destroy(this);
        }
        ObjectPoolInstance = this;
        CreatePrefabsParent();
    }

    private void CreatePrefabsParent()
    {
        for (var i = 0; i < m_Prefab.Length; i++)
        {
            var obj = new GameObject(m_Prefab[i].m_ObjectName.ToString());
            m_Prefab[i].m_ObjectTransform = obj.transform;
            obj.transform.SetParent(this.transform);
            SetPool(m_Prefab[i],m_Prefab[i].m_ProduceCount);
        }
    }

    private static void SetPool(Prefabs prefab, int count)
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

    private static Prefabs FindPrefabName(EPrefabsName name)
    {
        for (var i = 0; i < ObjectPoolInstance.m_Prefab.Length; i++)
        {
            if (ObjectPoolInstance.m_Prefab[i].m_ObjectName == name)
            {
                return ObjectPoolInstance.m_Prefab[i];
            }
        }
        return null;
    }
    
    #endregion

    public static GameObject GetObject(EPrefabsName name)
    {
        var currentPrefab = FindPrefabName(name);
        if (currentPrefab == null)
        {
            Debug.Log($"Can't Find {name.ToString()} In GetObject");
            return null;
        }
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

    /// <summary>
    /// Object Return To Object Pool If you Want Delay Add Float
    /// </summary>
    /// <param name="obj">Return Obj</param>
    /// <param name="name">Return Obj Name</param>
    public static void ReturnObject(GameObject obj, EPrefabsName name)
    {
        var currentPrefab = FindPrefabName(name);
        
        if (currentPrefab == null)
        {
            Debug.Log($"Can't Find {name.ToString()} In ReturnObject");
        }
        else
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(currentPrefab.m_ObjectTransform.transform);
            currentPrefab.m_ObjectQueue.Enqueue(obj);
        }
    }

    public void ReturnObject(GameObject obj, EPrefabsName name, float time)
    {
        StartCoroutine(DelayReturn(obj, name, time));
    }

    private IEnumerator DelayReturn(GameObject obj, EPrefabsName name, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnObject(obj,name);
    }
}
