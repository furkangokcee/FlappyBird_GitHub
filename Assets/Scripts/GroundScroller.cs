using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    // Zeminin kayma hızı
    [SerializeField] private float speed = 2f;
    
    // Zeminin genişliği (Otomatik hesaplayacağız)
    private float width;

    void Start()
    {
        // Nesnenin üzerindeki BoxCollider2D'ye bakıp genişliğini öğreniyoruz.
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        width = collider.size.x * transform.localScale.x; 
        // Not: Scale ile çarptık çünkü zemini büyüttüysen genişlik de artmıştır.
    }

    void Update()
    {
        // 1. Sola doğru hareket et
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 2. Eğer merkezim, genişliğim kadar sola gittiyse (ekrandan çıktıysa)
        if (transform.position.x < -width)
        {
            // Kendini 2 genişlik kadar sağa at (Diğer zeminin arkasına geç)
            // Neden 2 * width? Çünkü sahnede 2 tane zemin var.
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}