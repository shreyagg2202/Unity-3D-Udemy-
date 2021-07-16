using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] Canvas instructionsCanvas;
    [SerializeField] Canvas ammoCanvas;
    [SerializeField] Canvas healthCanvas;

    bool gameStarted = false;

    private void Start()
    {
        Time.timeScale = 0;
        instructionsCanvas.enabled = true;
        ammoCanvas.enabled = false;
        healthCanvas.enabled = false;
    }

    private void Update()
    {
        if ((Input.anyKeyDown || Input.GetMouseButtonDown(0)) && gameStarted  == false)
        {
            Debug.Log("Game has started");
            Time.timeScale = 1;
            gameStarted = true;
            instructionsCanvas.enabled = false;
            ammoCanvas.enabled = true;
            healthCanvas.enabled = true;
        }
    }
}
