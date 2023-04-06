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

    private float max_hp = 10.0f;
    [SerializeField]
    public int hp = 0;
    public int score = 0;
    public bool isPlaying = true;

    ArrowGenerator clone;

    private void Start()
    {
        this.hp = (int)this.max_hp;
        this.hpGauge = GameObject.Find("hpGauge");
        this.player = GameObject.Find("player");
        this.button = GameObject.Find("Reset");
        this.Score = GameObject.Find("score");

        button.SetActive(false);
        Score.SetActive(false);

        clone = FindObjectOfType<ArrowGenerator>();
    }

    public void DecreaseHp()
    {
        this.hp--;
    }

    void Update()
    {
        this.hpGauge.GetComponent<Image>().fillAmount = (float)hp / max_hp;
        if (this.hp <= 0 && isPlaying) //game status = end;
        {
            Score.SetActive(true);
            Score.GetComponent<Text>().text = "You avoided " + this.score + " arrows!";
            isPlaying = false;
            button.SetActive(true);
            player.GetComponent<PlayerController>().h = 0.0f;
        }
    }


    public void InitGame()
    {

        clone.DestroyAll();
        this.hp = (int)this.max_hp;
        this.score = 0;
        player.transform.position = new Vector3(0, -3.5f, 0);
        this.isPlaying = true;
        this.button.SetActive(false);
        this.Score.SetActive(false);
    }
}
