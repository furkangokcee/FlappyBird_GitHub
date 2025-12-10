using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Üreteceğimiz boru kalıbı (Prefab)
    [SerializeField] private GameObject pipePrefab;

    // Kaç saniyede bir boru çıksın?
    [SerializeField] private float spawnRate = 2f;

    // Boruların yükseklik ayarı (Ne kadar yukarıda veya aşağıda doğabilir)
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 2f;

    // Zaman sayacı
    private float timer = 0f;

    void Start()
    {
        // Oyun başlar başlamaz ilk boruyu üretelim
        SpawnPipe();
    }

    void Update()
    {
        // Sayacı artır
        timer += Time.deltaTime;

        // Eğer süre dolduysa
        if (timer > spawnRate)
        {
            SpawnPipe();
            timer = 0; // Sayacı sıfırla
        }
    }

    void SpawnPipe()
    {
        // Rastgele bir yükseklik belirle
        float randomY = Random.Range(minHeight, maxHeight);

        // Doğacağı pozisyon: 
        // X: Bu Spawner nesnesinin olduğu yer (Ekranın sağında tutacağız)
        // Y: Rastgele yükseklik
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);

        // Yarat! (Ne, Nerede, Hangi Açıda)
        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }
}