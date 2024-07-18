using TMPro;
using UnityEngine;

public class HealthTextSetter : MonoBehaviour
{
    [SerializeField] private string healthText;
    [SerializeField] private TextMeshProUGUI healthTMP;

    private void OnEnable()
    {
        CharacterHealth.OnHealthChanged += SetHealthText;
    }

    private void OnDisable()
    {
        CharacterHealth.OnHealthChanged -= SetHealthText;
    }

    private void SetHealthText(int currentHealth)
    {
        healthTMP.text = $"{healthText} {currentHealth}";
    }
}
