using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
