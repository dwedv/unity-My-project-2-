using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance; // Singleton instance for easy access

    public GameObject objectToPool; // The prefab you want to pool
    public int amountToPool = 10; // Initial and minimum number of objects in the pool

    private List<GameObject> pooledObjects; // List to hold the pooled objects

    void Awake()
    {
        Instance = this;

        // Initialize the pool
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // Method to get an object from the pool
    public GameObject GetPooledObject()
    {
        // Look for an inactive object in the pool
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // If all objects are active, instantiate a new one and add it to the pool
        GameObject obj = Instantiate(objectToPool);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
