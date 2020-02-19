using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy speed
    [SerializeField]
    private float _speed = 4.0f;

    Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Nincs meg a Player");
        }

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (transform.position.y < -5.5f)
        {
            float randomPosX = Random.Range(-8, 8);
            transform.position = new Vector3(randomPosX, 7, 0);
        }

    }
    void CalculateMovement() 
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Enemy collision with Player
        if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        //Enemy collision with the Laser
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore();
            }
            Destroy(this.gameObject);
        }
    }
}
