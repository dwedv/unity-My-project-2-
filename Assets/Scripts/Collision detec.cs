using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidertest : MonoBehaviour
{
    private bool isYellow = true;
    private bool isPaused = false;
    public bool gameHasEnded = false;
    public float restartDelay = 2f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (gameHasEnded)
        {
            Move move = GetComponent<Move>();
            move.shouldMove = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isYellow = !isYellow;
        }

    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void StopCharacter()
    {
        rb.velocity = Vector3.zero; 
    }

    void OnCollisionStay(Collision collision)
    {
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();

        if (renderer != null)    
        {
            Material material = renderer.material;

            Color materialColor = material.color;

            Color yellow = new Color(1f, 1f, 0f);

            if (ColorsApproximatelyEqual(materialColor, yellow, 0.01f) && !isYellow)
            {
                Transform player1 = transform.Find("player1");   
                if (player1 != null)    
                {
                    Destroy(player1.gameObject);
                    gameHasEnded = true;
                    Invoke("RestartGame", restartDelay);
                }
            }

            if (!ColorsApproximatelyEqual(materialColor, yellow, 0.01f) && isYellow)
            {
                Transform player1 = transform.Find("player1");   
                if (player1 != null)    
                {
                    Destroy(player1.gameObject);
                    gameHasEnded = true;
                    Invoke("RestartGame", restartDelay);
                }
            }
        }
    }

    bool ColorsApproximatelyEqual(Color a, Color b, float tolerance)
    {
        return Mathf.Abs(a.r - b.r) < tolerance && Mathf.Abs(a.g - b.g) < tolerance && Mathf.Abs(a.b - b.b) < tolerance;
    }

}