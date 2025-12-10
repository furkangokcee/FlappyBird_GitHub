using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    // Zeminin kayma hızı
    [SerializeField] private float speed = 3f;
    
    private float width;

    void Start()
    {
        // ARTIK POLYGON COLLIDER KULLANIYORUZ
        // PolygonCollider2D'yi bul
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        
        // PolygonCollider'da "size" yoktur, "bounds.size" vardır.
        // bounds.size bize dünya üzerindeki gerçek genişliği verir (Scale ile çarpmaya gerek kalmaz).
        width = collider.bounds.size.x;
    }

    void Update()
    {
        // 1. Sola doğru hareket et
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 2. Eğer merkezim, genişliğim kadar sola gittiyse (ekrandan çıktıysa)
        if (transform.position.x < -width)
        {
            // Kendini 2 genişlik kadar sağa at (Diğer zeminin arkasına geç)
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}