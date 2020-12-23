using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBoxes : MonoBehaviour
{
    public AudioSource CollectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreSystem.Score = 10 + ScoreSystem.Score;
        }
    }
}
