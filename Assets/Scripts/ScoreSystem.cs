using UnityEngine.UI;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public GameObject ScoreText;
    public static int Score = 0;

    void Update()
    {
       ScoreText.GetComponent<Text>().text = Score.ToString()  ; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddScore();
        }
    }

    void AddScore() {
        Score++;
    }
}
