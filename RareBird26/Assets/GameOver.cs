using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("aawaagga");
    }
}
