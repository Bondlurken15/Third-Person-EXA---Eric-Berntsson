using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Canvas settingsCanvas;
    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] Canvas deathCanvas;
    [SerializeField] Canvas victoryCanvas;

    bool canvasActive = false;
    void Start()
    {
        if (mainMenuCanvas == null)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanvas();
        }

        if (settingsCanvas.gameObject.activeSelf == true || (deathCanvas != null && deathCanvas.gameObject.activeSelf == true) || (victoryCanvas != null && victoryCanvas.gameObject.activeSelf == true) || mainMenuCanvas != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            return;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }

    public void ToggleCanvas()
    {
        canvasActive = !canvasActive;
        settingsCanvas.gameObject.SetActive(canvasActive);

        Debug.Log("Switched");
        
    }

    public void ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void ReloadScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }
}
