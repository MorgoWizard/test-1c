using UnityEngine;

public class SafeAreaFitter : MonoBehaviour
{
    private void Awake()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Rect safeaArea = Screen.safeArea;
        Vector2 anchorMin = safeaArea.position;
        Vector2 anchorMax = anchorMin + safeaArea.size;

        anchorMin.x /= Screen.width;
        anchorMax.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.y /= Screen.height;

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }
}
