using UnityEngine;

public class Brick : MonoBehaviour
{
    private int points = 10;
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.PlayerScores(points);
            Destroy(this.gameObject);
        }
    }
}
