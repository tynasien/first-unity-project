using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PanelMenu;

    private void Update()
    {
        
    }

    private void Start()
    {
        PanelMenu.SetActive(false);
    }

    public void Pause()
    {
        PanelMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PanelMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
