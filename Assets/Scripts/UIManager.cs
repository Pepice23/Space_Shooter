using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText = null;
    [SerializeField]
    private Text _gameOverText = null;
    [SerializeField]
    private Text _restartText = null;


    [SerializeField]
    private Image _livesImg = null;

    [SerializeField]
    private Sprite[] _liveSprites = null;

    private GameManager _gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: 0";
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("Nincs meg a GameManager");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int points)
    {
        _scoreText.text = string.Format("Score: {0}", points);
    }
    public void UpdateLives(int live)
    {
        _livesImg.sprite = _liveSprites[live];
        if (live == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlicker());
        _restartText.gameObject.SetActive(true);
    }
    IEnumerator GameOverFlicker()
    {
        while (true)
        {
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
