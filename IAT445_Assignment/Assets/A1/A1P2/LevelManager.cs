using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace A1.A1P2
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        public int score;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI highestText;
        public TextMeshProUGUI currentText;
        public GameObject gameOverPanel;

        private void Awake()
        {
            InitializeSingleton();
        }

        private void InitializeSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void IncreaseScore(int amount)
        {
            score += amount;
            scoreText.text = "Score: " + score.ToString();
        }

        public void ActiveGameOverPanel(bool result)
        {
            gameOverPanel.SetActive(result);
        }

        public void LoadLevel(bool isNewGame)
        {
            if (isNewGame) PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Scene_A1P2_Level");
        }

        public void LoadTittle()
        {
            SceneManager.LoadScene("A1/A1P2/Scene_A1P2_Tittle");
        }

        public void RecordScore()
        {
            var highestStr = "Highest Score: ";
            var currentStr = "Current Score: ";
            
            if (!PlayerPrefs.HasKey("HighestScore"))
            {
                PlayerPrefs.SetInt("HighestScore", score);
                PlayerPrefs.Save();
                highestStr += 0;
                currentStr += score + " (New Record)";
            }
            else
            {
                var highestScore = PlayerPrefs.GetInt("HighestScore");
                highestStr += highestScore;
                if (score > highestScore)
                {
                    currentStr += score + " (New Record)";
                    PlayerPrefs.SetInt("HighestScore", score);
                    PlayerPrefs.Save(); 
                }
                else currentStr += score;
            }

            highestText.text = highestStr;
            currentText.text = currentStr;
        }
    }
}
