using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [SerializeField] private Button applyBtn;
    [SerializeField] private TMP_InputField xOffsetInput;
    [SerializeField] private TMP_InputField zOffsetInput;
    [SerializeField] private TMP_InputField speedInput;
    [SerializeField] private TMP_InputField timeToSpawnInput;
    [SerializeField] private TextMeshProUGUI log;

    private SettingsController settings;

    public static UISettings Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        applyBtn.onClick.AddListener(Apply);
    }

    public void UpdateUI()
    {
        settings = SettingsController.Instance;

        xOffsetInput.text = settings.XOffset.ToString();
        zOffsetInput.text = settings.ZOffset.ToString();
        speedInput.text = settings.Speed.ToString();
        timeToSpawnInput.text = settings.TimeToSpawn.ToString();
        log.text = "";
    }

    private void Apply()
    {
        try
        {
            float xOffset = float.Parse(xOffsetInput.text);
            float zOffset = float.Parse(zOffsetInput.text);
            float speed = float.Parse(speedInput.text);
            float spawnTime = float.Parse(timeToSpawnInput.text);

            settings.UpdateSettings(xOffset, zOffset, speed, spawnTime);
            UIManager.Instance.Toogle(UIType.HUD);
        }
        catch (FormatException)
        {
            Log("В полях можно указывать только цифры!");
        }
    }

    private void Log(string msg)
    {
        log.text = msg;
    }
}
