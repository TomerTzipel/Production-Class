using UnityEngine;

public class EnemyMovementHandler : MonoBehaviour
{
    [SerializeField] private EnemyEdgeDetectorHandler leftEdgeDetector;
    [SerializeField] private EnemyEdgeDetectorHandler rightEdgeDetector;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private float speed;
    private float _direction = 1f;

    private void OnEnable()
    {
        leftEdgeDetector.OnEdgeDetected += ChangeDirection;
        rightEdgeDetector.OnEdgeDetected += ChangeDirection;
    }

    private void OnDisable()
    {
        leftEdgeDetector.OnEdgeDetected -= ChangeDirection;
        rightEdgeDetector.OnEdgeDetected -= ChangeDirection;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(speed * Time.deltaTime * _direction * Vector2.right);
    }

    private void ChangeDirection()
    {
        _direction *= -1f;
        renderer.flipX = !renderer.flipX;
    }
}
