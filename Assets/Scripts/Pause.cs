
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public SimpleSampleCharacterControl player;

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

    public void LoadMenu() {
        Debug.Log("Loading menu... ");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start_Screen");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quiting Game.");
    }

    public void SaveGame() {
        SaveSystem.SavePlayer(player);
        Debug.Log("Saving game");
    }
}
