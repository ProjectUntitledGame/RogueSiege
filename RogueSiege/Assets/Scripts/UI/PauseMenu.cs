using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private QuitPanel quitMenuRef;

    public void Resume()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void OpenQuitMenu()
    {
        quitMenuRef.gameObject.SetActive(true);
    }
}
