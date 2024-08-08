using UnityEngine;
using UnityEngine.AI;
public class Civilian : MonoBehaviour
{
    NavMeshAgent agent;
    public string behavior;
    private Player player;
    [SerializeField] private Vector3 wanderTarget;
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<Player>();
        wanderTarget = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
    }
    private void Seek(Vector3 target)
    {
        agent.SetDestination(target);
    }
    private void Flee(Vector3 location)
    {
        Vector3 fleeDirection = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeDirection);
    }
    private void Wander()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            wanderTarget = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
        Seek(wanderTarget);
    }
    private bool canSeeTarget()
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = player.transform.position - this.transform.position;
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo)) return raycastInfo.transform.gameObject.tag == "Player";
        return false;
    }
    private bool inRange(float range)
    {
        Debug.Log(Vector3.Distance(player.transform.position, this.transform.position) < range);
        return (Vector3.Distance(player.transform.position, this.transform.position) < range);

    }
    private void Update()
    {
        float detectionRange = 10.0f;
        if (canSeeTarget() && inRange(detectionRange))
        {
            if (this.behavior == "Flee")
                Flee(player.transform.position);
        }
        else
            Wander();
    }
}