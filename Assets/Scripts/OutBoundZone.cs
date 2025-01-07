using UnityEngine;
using UnityEngine.Events;

public class OutBoundZone : MonoBehaviour
{
    public UnityEvent deathTrigger;

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            deathTrigger.Invoke();
        }
    }
}
