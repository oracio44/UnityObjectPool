using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int PoolCount;

    int creationCount = 0;

    Queue<GameObject> pooledObjects = new Queue<GameObject>();
    void Start()
    {
        for (int i = 0; i < PoolCount; i++)
        {
            CreatePooledObject();
        }
    }

    private void CreatePooledObject()
    {
        creationCount++;
        GameObject newObj = Instantiate(prefab);
        newObj.name = prefab.name + creationCount;
        newObj.transform.SetParent(this.transform);
        newObj.GetComponent<PooledObject>().Pool = this;
        AddObject(newObj);
    }

    public void AddObject(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjects.Enqueue(obj);
    }

    public GameObject GetObject()
    {
        if (pooledObjects.Count == 0)
        {
            CreatePooledObject();
        }
        GameObject poolObj = pooledObjects.Dequeue();
        poolObj.SetActive(true);
        return poolObj;
    }
}