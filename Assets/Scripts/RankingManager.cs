using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> rank = new List<TextMeshProUGUI>();
    [SerializeField] private TextMeshProUGUI userName;

    IEnumerator Start()
    {
        string url = "https://ekairo.xsrv.jp/suikaGameCuston/Gateway/getBestScore.php"; // あなたのPHPスクリプトのURLに置き換える

        using (WWW www = new WWW(url))
        {
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                // PHPスクリプトからのJSONデータを取得
                string jsonData = www.text;
                //JObject obj = JObject.Parse(jsonData);

                // JSONデータを辞書型に変換
                Dictionary<string, object> dataDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);

                int i = 0;
                // 辞書型のデータを利用する
                foreach (var entry in dataDict)
                {
                    Debug.Log("Key: " + entry.Key + ", Value: " + entry.Value);
                    Dictionary<string, object> datas = JsonConvert.DeserializeObject<Dictionary<string, object>>(entry.Value.ToString());

                    rank[i].text = $"{datas["userName"]} : {datas["score"]}";
                    //foreach(var data in datas)
                    //{
                    //    Debug.Log("Key: " + data.Key + ", Value: " + data.Value);
                    //}
                    i++;
                }
            }
            else
            {
                Debug.LogError("Error while fetching data: " + www.error);
            }
        }
    }

    public void SendScore()
    {
        StartCoroutine(UploadScore(userName.text, DataScripts.Score));
    }

    IEnumerator UploadScore(string userName, int score)
    {
        string url = "https://ekairo.xsrv.jp/suikaGameCuston/Gateway/registScore.php"; // あなたのPHPスクリプトのURLに置き換える
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("score", score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error uploading score: " + www.error);
            }
            else
            {
                Debug.Log("Score uploaded successfully!");
            }
        }
    }
}
