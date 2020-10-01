using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    
    public float speed;
    public float cadence;

    private float _timeSinceLastShoot;
    private Rigidbody2D _rigidbody2D;
    private GameManager _gameManager;
    private AudioSource _audioSource;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_gameManager.isGamePlaying)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.left * (speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.right * (speed * Time.deltaTime));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        if (Time.realtimeSinceStartup - _timeSinceLastShoot > cadence)
        {
            _audioSource.Play();
            Instantiate(laserPrefab, transform.position, transform.rotation);
            _timeSinceLastShoot = Time.realtimeSinceStartup;
        }
    }
}
