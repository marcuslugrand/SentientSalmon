using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnSalmon : MonoBehaviour
{
    public GameObject salmonPrefab;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public float initialSpawnInterval;
    public float finalSpawnInterval;
    public float gameTime;
    private float elapsedTime;
    private float spawnTimer;

    public  TMP_Text timerText;

    private void Start()
    {
        spawnTimer = 0f;
        UpdateTimerText(gameTime);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            spawnTimer = spawnInterval();

            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);

            Instantiate(salmonPrefab, new Vector3(x, y, 0), Quaternion.identity);
        }

        UpdateTimerText(gameTime - elapsedTime);
    }

    private float spawnInterval()
    {
        float t = elapsedTime / gameTime;
        return Mathf.Lerp(initialSpawnInterval, finalSpawnInterval, t);
    }

    private void UpdateTimerText(float timeRemaining)
    {
        string formattedTime = timeRemaining.ToString("N0");
        timerText.text = formattedTime;
    }
}