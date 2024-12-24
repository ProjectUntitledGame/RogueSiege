using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private QuitPanel QuitPanelRef;
    [SerializeField] private LevelSelect levelSelectRef;
    public void StartGame()
    {
        levelSelectRef.gameObject.SetActive(true);
    }

    public void OpenQuitPanel()
    {
        QuitPanelRef.gameObject.SetActive(true);
    }

}
