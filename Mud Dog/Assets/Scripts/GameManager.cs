using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { TITLE, INGAME, WIN, LOSE}
public class GameManager : Singleton<GameManager> {
    public int mudLevel = 0;
    public GameState gameState;
    public Color mudColor;
    public GameObject win;
    public GameObject lose;
    public GameObject zaWordo;
    private void Start()
    {
        mudLevel = GameObject.FindGameObjectsWithTag("Floor").Length;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameWin()
    {
        zaWordo.SetActive(false);
        win.SetActive(true);
    }

    public void GameOver()
    {
        zaWordo.SetActive(false);
        lose.SetActive(true);
    }

    public void IncreaseMud(Renderer mudTile)
    {
        if (mudTile.material.color == mudColor)
            return;
        mudLevel -= 1;
        mudTile.material.color = mudColor;
        Debug.Log("Mud Level: " +mudLevel.ToString());
        if (mudLevel <= 0)
            GameWin();
    }

}
