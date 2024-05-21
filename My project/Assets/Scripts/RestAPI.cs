using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class RestAPI : MonoBehaviour
{
    private const string URL = "https://664a4c03a300e8795d419292.mockapi.io/members";
    private List<Member> members = new List<Member>();

    public async Task InitializeAsync()
    {
        await GetDataAsync();
    }

    public async Task AddNewMemberAsync(Member newMember)
    {
        string newMemberJson = JsonUtility.ToJson(new
        {
            name = newMember.name,
            birthday = newMember.birthday,
            birthmonth = newMember.birthmonth,
            id = members.Count + 1 // assuming sequential IDs
        });

        using (UnityWebRequest request = new UnityWebRequest(URL, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(newMemberJson);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            var operation = request.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log("New member added: " + request.downloadHandler.text);
                await GetDataAsync();
            }
        }
    }

    public async Task GetDataAsync()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            var operation = request.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string json = request.downloadHandler.text;
                SimpleJSON.JSONNode stats = SimpleJSON.JSON.Parse(json);

                members.Clear();
                for (int i = 0; i < stats.Count; i++)
                {
                    string name = stats[i]["name"];
                    int day = stats[i]["birthday"].AsInt;
                    int month = stats[i]["birthmonth"].AsInt;
                    print(month.ToString() + " " + day.ToString() + name.ToString());
                    members.Add(new Member(name, new System.DateTime(2001, month, day)));
                }
                Debug.Log("Total number of results: " + members.Count);
            }
        }
    }

    public IEnumerator AddNewMember(string name, int birthday, int birthmonth)
    {
        string newMemberJson = JsonUtility.ToJson(new Member(name, new System.DateTime(2001, birthmonth, birthday)));
            print(newMemberJson);

        using (UnityWebRequest request = new UnityWebRequest(URL, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(newMemberJson);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log("New member added: " + request.downloadHandler.text);
                //StartCoroutine(GetData()); // Refresh the data after adding a new member
            }
        }
    }


    public List<Member> GetMembers()
    {
        return members;
    }
}
