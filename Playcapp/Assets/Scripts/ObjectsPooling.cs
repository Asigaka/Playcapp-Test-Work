using System.Collections.Generic;
using UnityEngine;

public class ObjectsPooling : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int objectsForPoolingCount = 20;

    private List<GameObject> poolingObjects;

    private static ObjectsPooling Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;

        FillPool();
    }

    public void FillPool()
    {
        poolingObjects = new List<GameObject>();

        for (int i = 0; i < objectsForPoolingCount; i++)
        {
            GameObject poolingObj = Instantiate(objectPrefab);
            poolingObj.SetActive(false);
            poolingObjects.Add(poolingObj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolingObjects.Count; i++)
        {
            if (!poolingObjects[i].activeInHierarchy)
            {
                return poolingObjects[i];
            }
        }
        return null;
    }
}
