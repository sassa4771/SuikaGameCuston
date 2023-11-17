using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class resultManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "最終Score：" + DataScripts.Score.ToString();
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if(bestScore < DataScripts.Score)
        {
            PlayerPrefs.SetInt("BestScore", DataScripts.Score);
            bestScore = DataScripts.Score;
        }
        bestScoreText.text = "Best Score：" + bestScore.ToString();
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene("Main");
    }
}
