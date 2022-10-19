using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private KeyCode[] restartKeyCode;

    private void Update()
    {
        foreach (KeyCode key in restartKeyCode)
        {
            if (Input.GetKeyDown(key))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}