using UnityEngine;

public class Ball : MonoBehaviour
{

    private int hitCount = 0;
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 200f;

    Vector2 direction;

    Vector2 defaultPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultPosition = transform.position;
    }
    
    void Start()
    {

    }

    public void IncreaseSpeed(float increment)
    {
        rb.velocity *= increment;
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.position = defaultPosition;
    }    
    public void AddStartingForce()
    {
        float x = Random.value < 0.5 ? -1f : 1f;
        float y = Random.Range(0.5f, 1f);  
        
        direction = new Vector2(x, y);
        rb.AddForce(direction * speed);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            IncreaseSpeed(1.02f);
        }
    }
    
}
