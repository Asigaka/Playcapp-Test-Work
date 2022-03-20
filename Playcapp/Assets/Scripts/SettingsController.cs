using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private float startXOffset = 1;
    [SerializeField] private float startZOffset = 0;
    [SerializeField] private float startSpeed = 5;
    [SerializeField] private float startTimeToSpawn = 3;

    private float xOffset;
    private float zOffset;
    private float speed;
    private float timeToSpawn;

    private UISettings uiSettings;

    public static SettingsController Instance;

    public float XOffset { get => xOffset; }
    public float ZOffset { get => zOffset; }
    public float Speed { get => speed; }
    public float TimeToSpawn { get => timeToSpawn; }

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        uiSettings = UISettings.Instance;

        UpdateSettings(startXOffset, startZOffset, startSpeed, startTimeToSpawn);
    }

    public void UpdateSettings(float xOffset, float zOffset, float speed, float timeToSpawn)
    {
        this.xOffset = xOffset;
        this.zOffset = zOffset;
        this.speed = speed;
        this.timeToSpawn = timeToSpawn;
    }
}
