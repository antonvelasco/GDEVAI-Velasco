using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform goal;
    public float speed = 0;
    public float rotSpeed = 1;
    public float acceleration = 5;
    public float deceleration = 5;
    public float minSpeed = 0;
    public float maxSpeed = 10;
    public float breakAngle = 10;
    private float rpm;
    private void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, goal.position.y, goal.position.z);

        Vector3 direction = lookAtGoal - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

        if (Vector3.Angle(goal.forward, transform.forward) > breakAngle && speed > 2)
        {
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
            rpm = 50;
        }
        else
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
            rpm = 300;
        }
        transform.Translate(0, 0, speed);
    }
}