using UnityEngine; using UnityEngine.AI;
public class Police : MonoBehaviour
{
    private Player player;
    private NavMeshAgent agent;
    private float distanceFromPlayer;
    private bool isFleeing = false;
    [SerializeField] private Health health;
    [SerializeField] private GameObject bullet; [SerializeField] private Transform gun; private float fireRate = 0;
    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        Shoot();
        Chase();
        Flee();
    }
    private void Shoot()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceFromPlayer <= agent.stoppingDistance && !isFleeing)
        {
            fireRate += Time.deltaTime;
            if (fireRate > 1) { Instantiate(bullet, gun.position, transform.rotation); fireRate = 0; }
        }
    }
    private void Chase()
    {
        //Chase player if is not fleeing
        if (isFleeing) return;
        agent.SetDestination(player.transform.position);
    }
    private void Flee()
    {
        //If 50% flee from player
        if (health.GetCurrentHealth() <= health.GetHealth() / 2)
        {
            agent.stoppingDistance = 0;
            Vector3 fleeDirection = player.transform.position - this.transform.position;
            agent.SetDestination(this.transform.position - fleeDirection);
            isFleeing = true;
        }
    }
}