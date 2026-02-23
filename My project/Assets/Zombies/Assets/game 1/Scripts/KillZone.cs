using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("KillZone triggered by " + other.name);
        
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("STAY: " + other.name);
    }
}
