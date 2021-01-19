using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    public GameObject End;
    public GameObject[] playerNum; //玩家數量
    public Text whoWin;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //whoWin = GameObject.Find("WhoWin").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerNum[0])
        {
            Time.timeScale = 0;
            End.SetActive(true);
            whoWin.text = "<color=red>Player2 Win</color>";
        }

        if (!playerNum[1])
        {
            Time.timeScale = 0;
            End.SetActive(true);
            whoWin.text = "<color=blue>Player1 Win</color>";
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
