using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;
    public bool playerIsOnTheGround = true;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    private void FixedUpdate ()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            Die();
        }

        if (Input.GetButtonDown("Jump") && playerIsOnTheGround) {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            playerIsOnTheGround = false;
        }


	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
            playerIsOnTheGround = true;
    }

    public void Die ()
    {
        alive = false;
        // restarteaza jocul
        Invoke("Restart", 0.2f);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}