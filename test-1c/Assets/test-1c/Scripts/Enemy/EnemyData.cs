using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy", fileName = "SO_EnemyData_EnemyName")]
public class EnemyData : ScriptableObject
{
    /// <summary>
    /// Max enemy health
    /// </summary>
    [field:SerializeField] public int MaxHealth { get; private set; }
    /// <summary>
    /// Min enemy speed
    /// </summary>
    [field:SerializeField] public float MinSpeed { get; private set; }
    /// <summary>
    /// Max enemy speed
    /// </summary>
    [field:SerializeField] public float MaxSpeed { get; private set; }
}
