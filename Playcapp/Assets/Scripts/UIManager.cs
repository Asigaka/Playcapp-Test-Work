using System.Collections.Generic;
using UnityEngine;

public enum UIType { Settings, HUD }
public class UIManager : MonoBehaviour
{
    [SerializeField] private UIType startType = UIType.Settings;
    [SerializeField] private List<UIObject> uiObjects;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        Toogle(startType);
    }

    public void Toogle(UIType type)
    {
        foreach (UIObject ui in uiObjects)
        {
            ui.gameObject.SetActive(type == ui.Type);
        }

        switch (type)
        {
            case UIType.Settings:
                UISettings.Instance.UpdateUI();
                break;
        }
    }
}
