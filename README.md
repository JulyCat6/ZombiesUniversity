Game 1 is a 3D game where the player controls zombies.
The gameplay involves controlling zombies, collecting objects (Collectibles), and trying not to fall off the platform. 
The project is built in Unity using C#, Input System, Rigidbody, Collider, and UI elements.

UI Elements
Start Game – button to start the game.
Game Over / Restart – displays “You Lose” and a Restart Game button.
Score Text – shows the player’s current score.
Timer Text – displays the time elapsed since the start of the game.

Zombie Control
There are 4 zombie game objects in the scene (tag: Player).
The player can control the selected zombie using Move actions (right, left, backward) via InputAction and Rigidbody.AddForce().
Switching between zombies is done using NextZombie / PrevZombie actions.
The selected zombie is highlighted by changing its scale (selectedSize).

Zombie Jump
Each zombie can make double jump.
Jumping is implemented via Rigidbody.AddForce(jumpForce, ForceMode.Impulse) in the ZombieJump script.
The jump counter resets only when the zombie touches an object with the Ground tag.

Collectibles
Collectible objects spawn in the game, which zombies can collect.
Spawning is handled by the Spawner script with a spawnInterval = 1.5-second and random positions on the scene (x: -6..6, y: -10..10).
When a zombie collides with a collectible: 
    The object destroys.
    A sound plays (AudioSource.PlayOneShot)
    The player gains points (10 per collectible).
The score is displayed on the UI using TextMeshProUGUI scoreText.

Timer
A timer starts at the beginning of the game and counts the time since gameplay started.
The timer is displayed on the UI via TMP_Text timerText and updates every second.

Lose State
If any zombie falls off the platform and touches an object with the KillZone tag, the game enters Game Over.
The timer stops, background music stops, and the UI displays “You Lose” with a Restart Game button.
When restarting the game, the timer and score reset, and the game starts from the initial state.

Music
Background music plays during the game via GameManager.musicSource.
Each collected object also triggers a sound effect (AudioClip).
