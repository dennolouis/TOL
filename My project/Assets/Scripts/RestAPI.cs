using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestAPI : MonoBehaviour
{
    string URL = "https://664a4c03a300e8795d419292.mockapi.io/members";
    int totalResults;

    List<Member> members = new List<Member>();
    private void Awake()
    {
        Initialize();
        print("1");
    }
    void Start()
    {

    }
    public void Initialize()
    {
        StartCoroutine(GetData());
    }
    IEnumerator AddNewMember()
    {
        // Define the new member data
        string newMemberJson = "{\"name\":\"Dina\",\"birthday\":16,\"birthmonth\":11,\"id\":\"2\"}";

        // Create a POST request to add the new member
        using (UnityWebRequest request = UnityWebRequest.PostWwwForm(URL, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(newMemberJson);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // Send the request
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                // Log the response
                Debug.Log("New member added: " + request.downloadHandler.text);

                // Now retrieve the updated data
                StartCoroutine(GetData());
            }
        }
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string json = request.downloadHandler.text;
                SimpleJSON.JSONNode stats = SimpleJSON.JSON.Parse(json);

                // Print all names and the total number of results
                int totalCount = stats.Count;
                for (int i = 0; i < totalCount; i++)
                {
                    Debug.Log("Name: " + stats[i]["name"]);
                    members.Add(new Member(stats[i]["name"], new System.DateTime(2001, stats[i]["birthmonth"], stats[i]["birthday"])));
                }
                Debug.Log("Total number of results: " + totalCount);
            }
        }
    }
    public List<Member> GetMembers()
    {
        return members;
    }
}
