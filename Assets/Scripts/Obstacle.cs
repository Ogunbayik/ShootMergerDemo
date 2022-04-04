using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleData obstacleType;

    private Renderer _renderer;

    private int _currentHealth;
    private int _bulletDamage = 10;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Start()
    {
        _currentHealth = obstacleType.health;
        _renderer.material.color = obstacleType.color;
        transform.localScale = obstacleType.scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentHealth <= 0)
            Destroy(gameObject);

        _bulletDamage = Collector.collectorInstance.bulletDamage;

        Debug.Log(_bulletDamage);

    }
    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(_bulletDamage);
        }
    }
}
