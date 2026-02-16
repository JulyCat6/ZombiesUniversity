using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject[] zombies; // [] massive to chouse lot of zombies
    public GameObject selectedZombie;
    public Vector3 selectedSize;
    public Vector3 pushForce;
    private InputAction next, prev, jump;
    private int selectedIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next = InputSystem.actions.FindAction("NextZombie"); // izsauk keypogu N = NextZombie
        prev = InputSystem.actions.FindAction("PrevZombie"); // izsauk keypogu V = PrevZombie
        jump = InputSystem.actions.FindAction("Jump");
        SelectZombie(selectedIndex);  //izsauksanas funkcija
    }

    void SelectZombie(int index) // funkcija
    {
        if (selectedZombie !=  null)
        {
            selectedZombie.transform.localScale = Vector3.one;
        }
        
        selectedZombie = zombies[index]; // index -> void Start() {SelectedZombie(index)}
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected: " + selectedZombie);
    }

    // Update is called once per frame
    void Update()
    {
        if (next.WasPressedThisFrame())
        {
            Debug.Log("next");
            selectedIndex++;
            if (selectedIndex >= zombies.Length) //.Length iesaka cik zombie ir masiva. masiva ir 4 Zombies
                selectedIndex = 0;
            SelectZombie(selectedIndex);
        }

        if (prev.WasPressedThisFrame())
        {
            Debug.Log("prev");
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = zombies.Length -1;  // or  selectedIndex = 3;
            SelectZombie(selectedIndex);
        }

        if (jump.WasPressedThisFrame())
        {
            Debug.Log("JUMP");
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            if(rb != null)
                rb.AddForce(pushForce);
        }
    }
}
