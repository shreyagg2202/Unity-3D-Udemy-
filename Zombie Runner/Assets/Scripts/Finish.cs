using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] Canvas gameWonCanvas;

    private void Start()
    {
        gameWonCanvas.enabled = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        gameWonCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
