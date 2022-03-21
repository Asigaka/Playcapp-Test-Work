using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CubeController : MonoBehaviour
{
    private SettingsController settings;
    private NavMeshAgent agent;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        settings = SettingsController.Instance;

        if (agent && settings)
        {
            agent.stoppingDistance = 0;
            agent.speed = settings.Speed;
            SetTarget();
        }
    }

    private void Update()
    {
        if (agent.remainingDistance <= 0)
        {
            Hide();
        }
    }

    private void SetTarget()
    {
        float xOffset = settings.XOffset;
        float zOffset = settings.ZOffset;

        Vector3 target = new Vector3(transform.position.x + xOffset, 0, transform.position.z + zOffset);

        agent.SetDestination(target);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
