using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelManager : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    // Start is called before the first frame update
    void Start()
    {
        retryButton.onClick.AddListener(()=>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }
}
