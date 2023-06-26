using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    private bool isSoundOnce;
    [SerializeField] private GameObject gameoverSound;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject gameclearSound;
    [SerializeField] private GameObject gameclearPanel;
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private AudioSource bgm;
    void Start()
    {
        Time.timeScale = 1;
        gameoverPanel.SetActive(false);
        isSoundOnce = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && isSoundOnce == false)
        {
            gameoverPanel.SetActive(true);
            Instantiate(gameoverSound, transform.position, transform.rotation);
            isSoundOnce = true;
            Time.timeScale = 0;
        }
        else if (waveManager.IsEnd())
        {
            bgm.Stop();
            Instantiate(gameclearSound, transform.position, transform.rotation);
            gameclearPanel.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
