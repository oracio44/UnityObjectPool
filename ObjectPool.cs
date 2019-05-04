using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int InitialPoolCount = 20;

    int creationCount = 0;

    Queue<GameObject> pooledObjects = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < InitialPoolCount; i++)
        {
            CreatePooledObject();
        }
    }

    public void AddObject(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjects.Enqueue(obj);
    }

    //Get GameObject from pool
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

    private void CreatePooledObject()
    {
        creationCount++;
        GameObject newObj = Instantiate(prefab);
        SetupNewObject(newObj);
        AddObject(newObj);
    }

    private void SetupNewObject(GameObject newObject)
    {
        newObject.name = prefab.name + creationCount;
        newObject.transform.SetParent(this.transform);
        newObject.GetComponent<PooledObject>().Pool = this;
    }
}