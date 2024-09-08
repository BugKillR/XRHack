using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerTG : MonoBehaviour
{
    public int score, time;
    public int startTime = 60; // Oyun süresi (saniye)

    private float startTimeStamp;
    private float elapsedTime;

    private int highScoreInt = 0;

    public GameObject coconut, cocoScore, firstPage, lastPage, inGamePage;
    public TextMeshProUGUI lastScoreText, scoreText, timeText;

    private bool coconutRotatingForward = true;
    private bool cocoScoreRotatingForward = true;

    private void Awake()
    {
        Time.timeScale = 0; // Oyun başlamadan önce zamanın durmasını sağlar
    }

    private void Update()
    {
        if (Time.timeScale > 0) // Sadece oyun oynanıyorsa zaman hesapla
        {
            RotateShyCoconut();
            RotateCocoScore();
            UpdateTime();

            // Oyun süresi dolduysa oyunu bitir
            if (elapsedTime - time >= startTime)
            {
                EndGame();
            }
        }
    }

    private void StartGame()
    {
        Time.timeScale = 1; // Oyunu başlat
        startTimeStamp = Time.time; // Başlangıç zamanını kaydet
        elapsedTime = 0; // Geçen süreyi sıfırla

        // Oyun UI'ını ve diğer bileşenleri başlat
        inGamePage.SetActive(true);
        firstPage.SetActive(false);
        lastPage.SetActive(false);
        
        // Skoru sıfırla
        score = 0;
        UpdateScoreUI();
    }

    private void UpdateTime()
    {
        elapsedTime = Time.time - startTimeStamp; // Geçen süreyi hesapla
        int remainingTime = Mathf.Max(0, startTime - (int)elapsedTime + time); // Kalan süreyi hesapla
        scoreText.text = $"Score: {score}\nTime: {remainingTime}"; // UI'yı güncelle
    }

    private void EndGame()
    {
        lastPage.SetActive(true); // Oyun sonu ekranını göster
        inGamePage.SetActive(false); // Oyun ekranını gizle
        Time.timeScale = 0; // Zamanı durdur
    }

    private float rotationSpeed = 0.3f;

private void RotateShyCoconut()
{
    float zRotation = coconut.transform.eulerAngles.z;
    if (zRotation > 180) zRotation -= 360;

    if (coconutRotatingForward && zRotation >= 20)
    {
        coconutRotatingForward = false;
    }
    else if (!coconutRotatingForward && zRotation <= -20)
    {
        coconutRotatingForward = true;
    }

    if (coconutRotatingForward)
    {
        zRotation += rotationSpeed;
    }
    else
    {
        zRotation -= rotationSpeed;
    }

    coconut.transform.rotation = Quaternion.Euler(coconut.transform.eulerAngles.x, coconut.transform.eulerAngles.y, zRotation);

    // Debug log
    Debug.Log($"Coconut Rotation: {zRotation}, Forward: {coconutRotatingForward}");
}

private void RotateCocoScore()
{
    if (score > highScoreInt)
    {
        highScoreInt = score;
    }

    lastScoreText.text = $"High Score: {highScoreInt}\nScore: {score}";

    float zRotation = cocoScore.transform.eulerAngles.z;
    if (zRotation > 180) zRotation -= 360;

    if (cocoScoreRotatingForward && zRotation >= 20)
    {
        cocoScoreRotatingForward = false;
    }
    else if (!cocoScoreRotatingForward && zRotation <= -20)
    {
        cocoScoreRotatingForward = true;
    }

    if (cocoScoreRotatingForward)
    {
        zRotation += rotationSpeed;
    }
    else
    {
        zRotation -= rotationSpeed;
    }

    cocoScore.transform.rotation = Quaternion.Euler(cocoScore.transform.eulerAngles.x, cocoScore.transform.eulerAngles.y, zRotation);

    // Debug log
    Debug.Log($"CocoScore Rotation: {zRotation}, Forward: {cocoScoreRotatingForward}");
}

    private void UpdateScoreUI()
    {
        scoreText.text = $"Score: {score}\nTime: {startTime}"; // Başlangıçta UI'yı güncelle
    }

    public void StartButton()
    {
        StartGame(); // Başlatma butonuna tıklanınca oyunu başlat
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene(1);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(2);
    }
}
