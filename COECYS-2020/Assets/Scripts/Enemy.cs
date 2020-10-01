using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {
        if (_gameManager.isGamePlaying)
        {
            transform.position += Vector3.down * (speed * Time.deltaTime);   
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("LoseLine"))
        {
            _gameManager.FinishGame();
        }
    }
}
