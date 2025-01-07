using UnityEngine;

public class Paddle : MonoBehaviour
{
    static public int lives = 3;

    private Rigidbody2D rb;
    Vector2 defaultPosition;

    [SerializeField]
    private float speed = 8;
    private float horizontal;
    private Vector2 direction = new Vector2();

    public bool input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultPosition = transform.position;
        input = true;
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.position = defaultPosition;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = input == true ? Input.GetAxisRaw("Horizontal") : 0;
    }

    void FixedUpdate()
    {
        direction = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = direction;
    }

    public void DecrementLives()
    {
        if (lives > 0)
        {
            lives--;
            Debug.Log("Lives: " + lives);
        }
    }

    public void ResetLives()
    {
        lives = 3;
    }
}
