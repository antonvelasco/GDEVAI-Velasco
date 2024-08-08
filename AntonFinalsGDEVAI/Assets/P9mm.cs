using UnityEngine;

public class P9mm : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private void Start()
    {
        //Destroy bullet in 5 seconds if it hits nothing
        Destroy(gameObject, 5);
    }
    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Give damage to anything it hits with a health component
        if (collision.gameObject.GetComponent<Health>())
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        //Destroy bullet if it hits anything with a collider
        Destroy(gameObject);
    }
}