using UnityEngine;

public class Uzi : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform labasan;
    [SerializeField] private Transform player;
    private float fireRate = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            fireRate += Time.deltaTime;
            if (fireRate > 0.1f)
            {
                Instantiate(bullet, labasan.position, player.rotation);
                fireRate = 0;
            }
        }
    }
}