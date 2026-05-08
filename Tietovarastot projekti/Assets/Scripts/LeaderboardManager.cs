using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    // API osoite (sinulla nyt toimiva portti)
    public string url = "http://localhost:5000/leaderboard";

    // UI
    public TMP_Text leaderboardText;

    // Nappi kutsuu tätä
    public void GetLeaderboard()
    {
        StartCoroutine(FetchLeaderboard());
    }

    IEnumerator FetchLeaderboard()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            leaderboardText.text = "Virhe: " + request.error;
            yield break;
        }

        string json = request.downloadHandler.text;

        // Muutetaan Unitylle sopivaksi
        string wrappedJson = "{\"scores\":" + json + "}";

        ScoreList list = JsonUtility.FromJson<ScoreList>(wrappedJson);

        ShowLeaderboard(list);
    }

    void ShowLeaderboard(ScoreList list)
    {
        leaderboardText.text = "TOP 5\n\n";

        for (int i = 0; i < list.scores.Length; i++)
        {
            var s = list.scores[i];
            leaderboardText.text += $"{i + 1}. {s.name} - {s.points}\n";
        }
    }
}