using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectsPooling))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform ground;

    private SettingsController settings;
    private ObjectsPooling pooling;

    public static CubeSpawner Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        settings = SettingsController.Instance;
        pooling = GetComponent<ObjectsPooling>();

        StartCoroutine(CubesSpawnerCoroutine());
    }

    private IEnumerator CubesSpawnerCoroutine()
    {
        while (true)
        {
            SpawnNewCube();
            yield return new WaitForSeconds(settings.TimeToSpawn);
        }
    }

    private void SpawnNewCube()
    {
        GameObject cube = pooling.GetPooledObject();

        if (cube != null)
        {
            cube.transform.position = GetPositionOnGround();
            cube.SetActive(true);
        }
    }

    private Vector3 GetPositionOnGround()
    {
        float x = Random.Range(ground.localScale.x * -5, ground.localScale.x * 5);
        float z = Random.Range(ground.localScale.z * -5, ground.localScale.z * 5);
        return new Vector3(x, 0, z);
    }
}
