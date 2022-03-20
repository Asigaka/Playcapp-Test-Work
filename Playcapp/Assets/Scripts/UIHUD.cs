using UnityEngine;
using UnityEngine.UI;

public class UIHUD : MonoBehaviour
{
    [SerializeField] private Button settingsBtn;

    public static UIHUD Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        settingsBtn.onClick.AddListener(TurnOnSettings);
    }

    private void TurnOnSettings()
    {
        UIManager.Instance.Toogle(UIType.Settings);
    }
}
