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

        InitializePool();
    }

    // Combined initialization logic into a single method
    private void InitializePool()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            AddObjectToPool();
        }
    }

    // Method to get an object from the pool
    public GameObject GetPooledObject()
    {
        foreach (var obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // Optionally, only expand pool if needed
        return AddObjectToPool(); // Adds a new object to the pool and returns it
    }

    // Method to return an object to the pool
    public void ReturnToPool(GameObject objectToReturn)
    {
        // First, check if the object is already in the pool to avoid duplicates
        if (!pooledObjects.Contains(objectToReturn))
        {
            return; // Exit the function as there's nothing further to do
        }

        // Deactivate the object before returning it to the pool to make it available for reuse
        objectToReturn.SetActive(false);
    }

    // Extracted method to add a new object to the pool
    private GameObject AddObjectToPool()
    {
        GameObject obj = Instantiate(objectToPool);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
