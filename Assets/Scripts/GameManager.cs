using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Text movesCounter;

    public GameObject panelWin;
    public GameObject panelLose;

    public GameObject buttonNext;

    private int moveCount;

    private void OnEnable()
    {
        PlayerMove.PlayerMoved += AddMove;
    }

    private void OnDisable()
    {
        PlayerMove.PlayerMoved -= AddMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        moveCount = 0;
        movesCounter.text = moveCount.ToString();

        panelLose.SetActive(false);
        panelWin.SetActive(false);
        buttonNext.SetActive(false);
    }

    public void AddMove()
    {
        moveCount++;
        UpdateMovesCounter(moveCount);
    }

    void UpdateMovesCounter(int number)
    {
        movesCounter.text = moveCount.ToString();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void WinLevel()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMove>().StopMotion();
        player.GetComponent<PlayerMove>().enabled = false;

        panelWin.SetActive(true);
        buttonNext.SetActive(true);
    }

    public void LoseLevel()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMove>().StopMotion();
        player.GetComponent<PlayerMove>().enabled = false;

        panelLose.SetActive(true);
    }
}
