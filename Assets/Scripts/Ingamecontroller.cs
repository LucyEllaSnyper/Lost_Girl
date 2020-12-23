
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingamecontroller : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public SimpleSampleCharacterControl player;

    private ScoreSystem scoreSystem;
    public GameObject WinMenuUI;


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused)
            {
                Resume();
            }
            else {
                PauseGame();
            }
        }
    }

    void FixedUpdate()
    {
         if(ScoreSystem.Score.Equals(5))
        {
            WinMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            if (SceneManager.sceneCount == 2)
            {
                SceneManager.LoadScene(0);
            }else
                SceneManager.LoadScene(2);
         }
    }


    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu... ");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start_Screen");
    }

    public void Continue(){
        SceneManager.LoadScene(2);
    }

    public void QuitGame() {
        //Application.Quit();
        SceneManager.LoadScene(0);
        Debug.Log("Quiting Game.");
    }

    public void SaveGame() {
        SaveSystem.SavePlayer(player);
        Debug.Log("Saving game");
    }
}
