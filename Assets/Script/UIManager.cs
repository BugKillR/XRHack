using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject menu, endPage, scoreUI;
    public InputActionProperty showBtn;

    public TextMeshProUGUI endScoreText;
    public TextMeshPro scoreHoldert;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreHoldert.text = $"Score: {FindAnyObjectByType<GameManager>().score.ToString()}\nHealth: {FindAnyObjectByType<GameManager>().health.ToString()}";

        if (showBtn.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
        }

        if (menu.activeSelf == false)
        {
            Time.timeScale = 1;

            scoreUI.SetActive(true);
        }
        else if(menu.activeSelf == true)
        {
            Time.timeScale = 0;
        }

        EndPage();
    }

    private void EndPage()
    {
        if(FindAnyObjectByType<GameManager>().health <= 0)
        {
            endScoreText.text = $"Score: {FindAnyObjectByType<GameManager>().score.ToString()}";

            scoreUI.SetActive(false);

            endPage.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene(1);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(3);
    }

    public void StartGame()
    {
        Time.timeScale = 1;

        menu.SetActive(false);
    }
}
