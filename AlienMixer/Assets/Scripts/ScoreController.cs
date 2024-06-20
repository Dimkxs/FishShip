using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score;

    
    void Update()
    {
       scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bomb")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (target.tag == "Fish")
        {
            Destroy(target.gameObject);
            score++;
        }
    }
    }
