using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceTraveled;
    [SerializeField] GameObject canvas;
    [SerializeField] Player player;
    [SerializeField] IsTriggered IsTriggered;
    [SerializeField] TextMeshProUGUI collectedCoins;
    [SerializeField] GameObject GameOverMusic;


    public void ShowGameOverScreen()
    {
        canvas.SetActive(true);
        distanceTraveled.text = player.distanceTraveled.ToString("0.00");
        collectedCoins.text = player.collectedCoins.ToString();
        GameOverMusic.SetActive(false);
    }

    public void GameRestart()
    {
        Debug.Log("Game is Restarting");
        SceneManager.LoadScene("newone");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShowGameOverScreen();
        } 
    }
    
}
