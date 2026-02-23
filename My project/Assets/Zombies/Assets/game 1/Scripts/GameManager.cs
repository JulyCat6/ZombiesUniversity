using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] zombies; // [] massive to chouse lot of zombies
    public GameObject selectedZombie;
    public Vector3 selectedSize;
    private InputAction next, prev, jump, move;
    private int selectedIndex = 0;
    
    public TMP_Text timerText;
    private float timer;
    public float moveSpeed = 5f;
    public static GameManager instance;
    public int score = 0;
    private int currentJump = 0;
    
    public TextMeshProUGUI scoreText;
    public GameObject losePanel;
    public GameState currentState = GameState.StartGame;
    public GameObject startPanel;
    
    public AudioSource musicSource;

    public enum GameState
    {
        StartGame,
        Gameplay,
        GameOver
    }
    
    void Awake() // link to object(GameManager), Awake called before game start
    {
        instance = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        
        next = InputSystem.actions.FindAction("NextZombie"); // izsauk keypogu N = NextZombie
        prev = InputSystem.actions.FindAction("PrevZombie"); // izsauk keypogu V = PrevZombie
        jump = InputSystem.actions.FindAction("Jump");
        move = InputSystem.actions.FindAction("Move");
        
        startPanel.SetActive(true);
        losePanel.SetActive(false);
    }

    public void StartGame()
    {
        currentState = GameState.Gameplay;
        timer = 0f;
        startPanel.SetActive(false);
        Time.timeScale = 1f;
        SelectZombie(selectedIndex);  //izsauksanas funkcija
        musicSource.Play();
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

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != GameState.Gameplay)
            return;
        
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
            
            ZombieJump zombie = selectedZombie.GetComponent<ZombieJump>();
            
            if (zombie != null)
                zombie.Jump();
        }

        MoveSelectedZombie();

        if (currentState == GameState.Gameplay)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F0") + "s";
        }
    }

    private void MoveSelectedZombie()
    {
        if (selectedZombie == null) 
            return;
        
        Vector2 input = move.ReadValue<Vector2>();
        
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        if (rb == null)
            return;

        Vector3 direction = new Vector3(input.x, 0f, input.y);
        
        rb.AddForce(direction * moveSpeed);
    }

    public void GameOver()
    {
        if (currentState == GameState.GameOver)
            return;
        
        currentState = GameState.GameOver;
        
        Time.timeScale = 0f;
        
        Debug.Log("You Lose Game");
        
        musicSource.Stop();
        
        losePanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
