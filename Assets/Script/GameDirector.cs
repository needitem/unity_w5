using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    GameObject player;
    GameObject button;
    GameObject Score;

    
    private int max_hp = 10;
    [SerializeField]
    public int hp = 0;
    public int score = 0;
    public bool isPlaying = true;

    private void Start()
    {
        this.hp = this.max_hp;
        this.hpGauge = GameObject.Find("hpGauge");
        this.player = GameObject.Find("player");
        this.button = GameObject.Find("Reset");
        this.Score = GameObject.Find("score");

        button.SetActive(false);
        Score.SetActive(false);
    }

    public void DecreaseHp()
    {
        this.hp--;
        this.hpGauge.GetComponent<Image>().fillAmount = (1); //fix later!
    }

    void Update()
    {
        if (this.hp <= 0) //game status = end;
        {
            Score.SetActive(true);
            Score.GetComponent<Text>().text = "You avoided" + this.score;
            isPlaying = false;
            button.SetActive(true);
            player.GetComponent<PlayerController>().h = 0.0f;
        }
    }


    public void InitGame()
    {
        this.hp = this.max_hp;
        player.transform.position = new Vector3(0, -3.5f, 0);
        this.isPlaying= true;
        this.button.SetActive(false);
        this.Score.SetActive(false);
    }
}
