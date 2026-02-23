using UnityEngine;

public class ZombieJump : MonoBehaviour
{
    public int maxJump = 2;
    public Vector3 jumpForce;
    
    private int currentJump = 0;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (currentJump >= maxJump)
            return;
        
        rb.AddForce(jumpForce, ForceMode.Impulse);
        currentJump++;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            currentJump = 0;
        }
    }
}
