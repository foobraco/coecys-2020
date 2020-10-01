using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    public float timeToLive = 10f;

    private GameManager _gameManager;
    private AudioSource _audioSource;
    private bool _gotHit;
    private GameObject _enemy;
    
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        Invoke(nameof(DestroyLaser), timeToLive);
    }

    private void Update()
    {
        if (_gameManager.isGamePlaying)
        {
            transform.position += Vector3.up * (speed * Time.deltaTime);   
        }

        if (_gotHit && !_audioSource.isPlaying)
        {
            _gameManager.AddScore(10f);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            
            Destroy(other.gameObject);
            CancelInvoke(nameof(DestroyLaser));

            _audioSource.Play();
            _gotHit = true;
        }
    }

    private void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
