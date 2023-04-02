using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CatchFish : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    private int score;

    void Start(){
        score = 0;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "AI Salmon"){
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
        }
    }
}
