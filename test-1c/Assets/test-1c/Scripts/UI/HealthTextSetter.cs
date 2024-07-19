using TMPro;
using UnityEngine;

public class HealthTextSetter : MonoBehaviour
{
    /// <summary>
    /// Text to write before health points
    /// </summary>
    [SerializeField] private string healthText;

    /// <summary>
    /// TMP Text component of health panel
    /// </summary>
    [SerializeField] private TextMeshProUGUI healthTMP;

    #region MonoBehavior Methods

    private void OnEnable()
    {
        CharacterHealth.OnHealthChanged += SetHealthText;
    }

    private void OnDisable()
    {
        CharacterHealth.OnHealthChanged -= SetHealthText;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Sets new health text
    /// </summary>
    /// <param name="currentHealth">Health amount to write</param>
    private void SetHealthText(int currentHealth)
    {
        healthTMP.text = $"{healthText} {currentHealth}";
    }

    #endregion
}