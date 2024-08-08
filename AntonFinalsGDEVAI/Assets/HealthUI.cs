using UnityEngine; using TMPro;
public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthT; [SerializeField] private Health health;
    private void Update() { healthT.text = health.GetCurrentHealth().ToString(); }
}