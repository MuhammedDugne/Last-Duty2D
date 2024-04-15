using UnityEngine;

public class CharacterLookAtMouse : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = false;
        // Karakterin başlangıçta yukarıya bakmasını sağla
        /* transform.up = Vector3.up; */
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Cursor.visible = false;
        // Fare pozisyonunu dünya koordinatlarına dönüştür
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Karakterin bulunduğu düzlemde olduğundan emin olmak için z ekseni sıfırlanır

        // Fare konumuna doğru bak
        if (Cursor.visible == false)
            transform.up = (mousePosition - transform.position).normalized;
    }
}
