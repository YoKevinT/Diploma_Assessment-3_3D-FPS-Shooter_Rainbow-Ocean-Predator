using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public float time = 0f;

    public void Restarts()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Fish").Length == 0)
        {
            Restarts();
        }
    }
}