using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    private int currentHealth;
    private void Start()
    {
        currentHealth = health;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //For Others Death
        if (currentHealth <= 0 && !gameObject.GetComponent<Player>()) Destroy(gameObject);
        //For Player Death
        if (currentHealth <= 0 && gameObject.GetComponent<Player>()) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public int GetHealth() { return health; }
    public int GetCurrentHealth() { return currentHealth; }
}