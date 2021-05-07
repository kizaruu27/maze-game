using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public int score = 0;
    public float jumpForce = 5f;
    public float jumpDistance = 10f;

    public Text scoreUI, scoreText;
    public GameObject WinUI, GameOverUI, LoseUI, StartUI, PauseUI;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            GameObject cam = GameObject.FindWithTag("Camera");
            cam.GetComponent<CameraController>().enabled = true;
            StartUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            GameObject cam = GameObject.FindWithTag("Camera");
            cam.GetComponent<CameraController>().enabled = false;
            UnityEngine.Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }

        PlayerMovement();

    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.up * jumpForce * jumpDistance * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {
            score++;
            scoreUI.text = "Score: " + score.ToString();
        }
        if (col.gameObject.tag == "Good Coin")
        {
            score = score + 5;
            scoreUI.text = "Score: " + score.ToString();
        }
        if (col.gameObject.tag == "Coin Coklat")
        {
            if (score <= 0)
            {
                score = 0;
                scoreUI.text = "Score: " + score.ToString();
            }
            else
            {
                score--;
                scoreUI.text = "Score: " + score.ToString();
            }
        }
        if (col.gameObject.tag == "Obstacle")
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
            GameObject cam = GameObject.FindWithTag("Camera");
            cam.GetComponent<CameraController>().enabled = false;
            UnityEngine.Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (col.gameObject.tag == "Finish")
        {
            if (score < 15)
            {
                LoseUI.SetActive(true);
                Time.timeScale = 0;
                GameObject camera = GameObject.FindWithTag("Camera");
                camera.GetComponent<CameraController>().enabled = false;
                UnityEngine.Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                scoreText.text = "YOUR SCORE: " + score.ToString();
                WinUI.SetActive(true);
                Time.timeScale = 0;
                GameObject cam = GameObject.FindWithTag("Camera");
                cam.GetComponent<CameraController>().enabled = false;
                UnityEngine.Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        if (col.gameObject.tag == "Enemy")
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
            GameObject cam = GameObject.FindWithTag("Camera");
            cam.GetComponent<CameraController>().enabled = false;
            UnityEngine.Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        GameObject cam = GameObject.FindWithTag("Camera");
        cam.GetComponent<CameraController>().enabled = true;
        UnityEngine.Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
