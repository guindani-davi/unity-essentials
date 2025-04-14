using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffectPrefab; // Prefab to instantiate on collection

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationSpeed = .5f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the collectible when the player collides with it
            Destroy(gameObject);
            // Instantiate the effect prefab at the collectible's position
            Instantiate(onCollectEffectPrefab, transform.position, transform.rotation);
        }
    }
}
