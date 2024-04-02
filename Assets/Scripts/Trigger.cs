using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnter : MonoBehaviour
{
    private int currentLevelIndex;

    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentLevelIndex = scene.buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        SwitchLevel();
    }

    private void SwitchLevel()
    {
        currentLevelIndex = (currentLevelIndex + 1) % 2;
        SceneManager.LoadScene(currentLevelIndex);
    }
}