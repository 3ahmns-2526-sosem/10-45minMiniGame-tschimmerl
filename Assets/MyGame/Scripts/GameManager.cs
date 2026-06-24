using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 10;

    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    public Transform targetCube;

    void Start()
    {
        UpdateScoreUI();
        if (winTextObject != null) winTextObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (score >= targetScore) return;

        score++;
        UpdateScoreUI();

        if (score >= targetScore)
        {
            WinGame();
        }
        else
        {
            MoveAndChangeCube();
        }
    }

    void MoveAndChangeCube()
    {
        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(-3f, 3f);
        targetCube.position = new Vector3(randomX, randomY, 0);

        Renderer cubeRenderer = targetCube.GetComponent<Renderer>();
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score + " / " + targetScore;
        }
    }

    void WinGame()
    {
        if (winTextObject != null)
        {
            winTextObject.SetActive(true);
        }
        targetCube.gameObject.SetActive(false);
    }
}