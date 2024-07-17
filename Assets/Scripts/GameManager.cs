using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameVictoryUI;

    [SerializeField] TextMeshProUGUI timeText;
    float timeLeft;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

      
    }

    public void Victory()
    {
        gameVictoryUI.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }


}
