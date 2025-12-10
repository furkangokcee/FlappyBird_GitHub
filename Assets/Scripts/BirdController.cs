using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Uçağın ne kadar güçlü zıplayacağını buradan ayarlayacağız.
    // [SerializeField] yazmamızın sebebi: Unity editöründen bu sayıyı değiştirebilmek.
    [SerializeField] private float jumpForce = 5f;

    // Fizik motoruna erişmek için bir değişken.
    private Rigidbody2D rb;

    void Start()
    {
        // Oyun başlarken uçağın üzerindeki Rigidbody 2D bileşenini bulup hafızaya alıyoruz.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Eğer Mouse'un sol tuşuna basılırsa (Telefonda dokunmaya denk gelir)
        if (Input.GetMouseButtonDown(0)) 
        {
            // Mevcut hızı sıfırla (yoksa düşerken basarsan yukarı çıkması zorlaşır)
            // Sonra yukarı doğru kuvvet uygula (Vector2.up = (0, 1))
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    // Unity'nin özel çarpışma fonksiyonu
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarptığı şey ne olursa olsun (Zemin veya Boru) oyunu bitir.
        GameManager.instance.GameOver();
    }
}
