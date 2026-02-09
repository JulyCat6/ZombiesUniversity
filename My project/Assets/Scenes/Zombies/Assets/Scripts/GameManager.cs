using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] zombies; // [] massive to chouse lot of zombies
    public GameObject selectedZombie;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectedZombie = zombies[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
