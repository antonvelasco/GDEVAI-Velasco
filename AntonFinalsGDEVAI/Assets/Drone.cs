using UnityEngine;

public class Drone : MonoBehaviour
{
    public Transform Goal;
    [SerializeField] private float speed;
    private float speedRotation = 3;
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(Goal.position.x, this.transform.position.y, Goal.position.z);
        Vector3 direction = lookAtGoal - transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * speedRotation);
        if (Vector3.Distance(lookAtGoal, transform.position) > 3)
            transform.Translate(0, 0, speed * Time.deltaTime);
    }
}