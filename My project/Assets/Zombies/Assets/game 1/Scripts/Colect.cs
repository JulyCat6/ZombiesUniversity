using UnityEngine;

public class Colect : MonoBehaviour
{
    public int points = 10;
    public AudioClip collectSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Object Collected!");
            
            if (GameManager.instance != null)
                GameManager.instance.AddScore(points);

            if (collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }
            
            Destroy(gameObject, 0.1f);
        }
    }
}
