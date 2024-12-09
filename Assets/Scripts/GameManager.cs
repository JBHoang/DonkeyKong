using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int level;
    private int lives;
    private int score;

    public Text scoreText;
    public Text livesText;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void Loadlevel(int index)
    {
        level = index;

        Camera camera = Camera.main;

        if (camera != null) {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;

        this.scoreText.text = score.ToString();
        this.livesText.text = lives.ToString();

        Loadlevel(1);
    }

    public void LevelComplete()
    {
        score += 1000;

        this.scoreText.text = score.ToString();

        int nextLevel = level + 1;
        
        if (nextLevel < SceneManager.sceneCountInBuildSettings) {
            Loadlevel(nextLevel);
        }
        else {
            Loadlevel(1);
        }
    }

    public void LevelFailed()
    {
        lives--;

        this.livesText.text = lives.ToString();

        if (lives <= 0) {
            NewGame();
        } 
        else {
            Loadlevel(level);
        }
    }
}
