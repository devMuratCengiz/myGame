using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int howManyHealths;
    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject gun;
    [SerializeField] private SpriteRenderer gunImage;
    [SerializeField] private Sprite gunSprite;
    [SerializeField] private SpriteRenderer[] weaponImage;
    [SerializeField] private Sprite weaponSprite;
    [SerializeField] private Player player;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Enemy enemy;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private int coin;
    [SerializeField] AudioSource levelUpSound;

    void Start()
    {
        Time.timeScale = 0;
        
        for (int i = 0; i < howManyHealths; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        coinText.text = coin.ToString();
        coin = Mathf.Clamp(coin, 0, 1000);
    }
    public void TakeDamage()
    {
        if (howManyHealths!=0)
        {
            hearts[howManyHealths - 1].gameObject.SetActive(false);
            howManyHealths--;
        }
        
        if (howManyHealths == 0)
        {
            player.Death();
            Invoke("GameOver", 2f);
          
        }
    }
    public void GameOver()
    { 
        panels[0].SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void LevelUp()
    {
        levelUpSound.Play();
        panels[1].SetActive(true);
        Time.timeScale = 0;
    }
    public void MarketResume()
    {
        panels[1].SetActive(false);
        Time.timeScale = 1;
    }
    public void Buy(string choose)
    {
        switch (choose)
        {
            case "heart":
                if (coin>=100 && howManyHealths<5)
                {
                    Debug.Log("haert buy");
                    howManyHealths++;
                    hearts[howManyHealths-1].gameObject.SetActive(true);
                    coin -= 100;
                }
                break;

            case "shoe":
                if (coin>=200)
                {
                    player.moveSpeed = 5f;
                    coin -= 200;
                }
                
                break;

            case "scythe":
                if (coin >= 300)
                {
                    foreach (var item in weaponImage)
                    {
                        item.tag = "Knife2";
                        item.sprite = weaponSprite;
                    }
                    coin -= 300;
                }
                
                break;

            case "gun":
                if (coin >= 500)
                {
                    gun.gameObject.SetActive(true);
                    gunImage.sprite = gunSprite;
                    coin -= 500;
                }
                
                break;
        }
    }
    public void EarnCoin()
    {
        coin += 10;
    }
    public void Play()
    {
        Time.timeScale = 1;
        panels[2].gameObject.SetActive(false);
    }
    public void Settings()
    {
        panels[3].gameObject.SetActive(true);
    }
    public void Settings2()
    {
        Time.timeScale = 0;
        panels[4].gameObject.SetActive(true);
    }
    public void Settings2Exit()
    {
        Time.timeScale = 1;
        panels[4].gameObject.SetActive(false);
    }
    public void QuitSettings()
    {
        panels[3].gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
