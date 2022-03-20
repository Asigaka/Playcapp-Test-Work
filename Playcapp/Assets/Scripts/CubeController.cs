using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CubeController : MonoBehaviour
{
    private SettingsController settings;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        settings = SettingsController.Instance;
    }

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        settings = SettingsController.Instance;
        agent.speed = settings.Speed;
        SetTarget();
    }

    private void SetTarget()
    {
        float xOffset = settings.XOffset;
        float zOffset = settings.ZOffset;

        Vector3 target = new Vector3(transform.position.x + xOffset, 0, transform.position.z + zOffset);

        agent.SetDestination(target);
        Invoke(nameof(Hide), 5);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
