using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy", fileName = "SO_EnemyData_EnemyName")]
public class EnemyData : ScriptableObject
{
    [field:SerializeField] public int MaxHealth { get; private set; }
    [field:SerializeField] public float MinSpeed { get; private set; }
    [field:SerializeField] public float MaxSpeed { get; private set; }
}
