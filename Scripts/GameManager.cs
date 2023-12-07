using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //singleton that easily allows to call GameManager from any other script only this class manages this function
    public static GameManager Instance { get; private set; }  

    //sets initial game speed
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    //UI
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public Button retryButton;

    //variables for player & spawner
    private Player player;
    private Spawner spawner;

    private float score;
    public float Score => score;

    private void Awake()
    {
        if (Instance == null){
            Instance = this;
        }   else {
                DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        NewGame();
    }

    //game restarts after game over
    public void NewGame()
    {
        //clears all objects 
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles) {
            Destroy(obstacle.gameObject);
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        
    }

    //when player loses the game
    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

       
    }

    //game speed will increase over time
    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        //score points will increase as speed increases
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

}
