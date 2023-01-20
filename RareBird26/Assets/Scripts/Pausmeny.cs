using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausmeny : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject UI;

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
              

            } else
            {
                Pause();
            }
        }
    }
   public void Resume ()
    {
        UI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        UI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("aawaagga");
    }

}
