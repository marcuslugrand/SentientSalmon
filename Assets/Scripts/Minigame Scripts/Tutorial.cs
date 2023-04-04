using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private float countdownDuration = 5f;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject timeAndScore;
    private bool isCountingDown = true;
    private float countdownTimer = 0f;

    void Start()
    {
        Time.timeScale = 0f; // Freeze time
        countdownTimer = countdownDuration;
        tutorial.SetActive(true);
        countdownText.enabled = true;
    }

    void Update()
    {
        if (isCountingDown)
        {
            countdownTimer -= Time.unscaledDeltaTime; // Ignore time scale
            countdownText.text = Mathf.CeilToInt(countdownTimer).ToString();
            
            if (countdownTimer <= 0f)
            {
                isCountingDown = false;
                countdownText.enabled = false;
                tutorial.SetActive(false);
                timeAndScore.SetActive(true);
                Time.timeScale = 1f; // Resume time
            }
        }
    }
}