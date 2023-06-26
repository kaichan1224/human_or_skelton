using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    void Start()
    {
        startButton.onClick.AddListener(()=>
        {
            SceneManager.LoadScene("Main");
        });   
    }
}
