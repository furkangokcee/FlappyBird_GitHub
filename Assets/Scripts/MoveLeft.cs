using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Hızın zeminle aynı olması görsel bütünlük için iyidir (Örn: 2f)
    [SerializeField] private float speed = 3f;

    void Update()
    {
        // 1. Sola doğru git
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 2. Eğer çok fazla sola gittiyse (Ekrandan çıktıysa) yok et.
        // -15 değeri ekranın solundan bayağı uzak bir nokta.
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
