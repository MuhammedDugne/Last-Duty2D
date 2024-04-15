using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Update()
    {
        // Fare pozisyonunu dünya uzayında al
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Crosshair'ın pozisyonunu ayarla
        transform.position = new Vector3(targetPosition.x, targetPosition.y, 0f);
    }
}
