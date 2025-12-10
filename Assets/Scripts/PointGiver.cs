using UnityEngine;

public class PointGiver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpan şey Kuş ise (Genelde zaten sadece kuş çarpar ama kontrol edelim)
        // BirdController scripti olan bir şey çarptıysa
        if (collision.GetComponent<BirdController>() != null)
        {
            // Yöneticiye söyle puanı artırsın
            GameManager.instance.IncreaseScore();
        }
    }
}