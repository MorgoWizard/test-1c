using UnityEngine;

public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T productPrefab;
    public abstract T GetProduct();
}
