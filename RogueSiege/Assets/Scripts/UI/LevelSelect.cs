using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystemRef;
    [SerializeField] private GameObject[] levelPages;
    private int currentPage;
    // This is an issue as the modularity only works while all the levels are on one page. As they are on different pages
    //I will need to rework the selection.
    public void PickLevel()
    {
        int buttonRef = eventSystemRef.currentSelectedGameObject.transform.GetSiblingIndex() +1;
        if (SceneManager.sceneCount >= buttonRef)
        {
            SceneManager.LoadScene(buttonRef);
        }
    }

    public void NextPage()
    {
        if (levelPages.Length-1 > currentPage)
        {
            levelPages[currentPage].SetActive(false);
            currentPage++;
            levelPages[currentPage].SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            levelPages[currentPage].SetActive(false);
            currentPage--;
            levelPages[currentPage].SetActive(true);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
