using SecureVariables;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public SecureInt poolSize = 1;
    [ReadOnly] public List<GameObject> objectPool;
    public SecureBool allowExtraSpawning = true;

    private void Start()
    {
        // Create the object pool and prepopulate it with objects
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity, transform); // Instantiate at pool's position
            obj.SetActive(false);
            objectPool.Add(obj);
            objectPool[i].transform.position = transform.position;
        }
    }
    private GameObject newObj;
    public GameObject GetObject()
    {
        // Find the first inactive object in the pool and return it
        foreach (GameObject obj in objectPool)
        {
            if (obj != null && !obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // If no inactive objects are found, create a new one and add it to the pool
        newObj = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        objectPool.Add(newObj);
        newObj.SetActive(true);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        // Deactivate the object and return it to the pool
        obj.SetActive(false);
    }
}