using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using static TelegramUser;

public class WebAppBridge : MonoBehaviour
{
    [System.Serializable]
    public class TelegramUser
    {
        public long id;
        public string first_name;
        public string last_name;
        public string username;
        public string language_code;
        public bool is_premium;
        // добавь другие поля по необходимости
    }


    public class CreatePlayerModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
    //Старт
    //private async void Start()
    //{
    //    var createPlayerModel = new CreatePlayerModel()
    //    {
    //        UserId = 222,
    //        FirstName = "Andy1",
    //        LastName = "Alex",
    //        UserName = "Jango"
    //    };

    //    await StartPlayerWork(createPlayerModel);
    //}

    private async Task StartPlayerWork(CreatePlayerModel createPlayerModel)
    {
        StartCoroutine(PostPlayerData(createPlayerModel));
        gameObject.GetComponent<TextMeshPro>().text = $"Привет, {createPlayerModel.FirstName}";

        Predator pred = GameObject.Find("Predator").GetComponent<Predator>();

        pred.UserId = createPlayerModel.UserId;

        //await ServerWork.GetPlayerProgress(new ForPredator(pred));

        StartCoroutine(GetPlayerData(pred));

        StartCoroutine(PutPlayerData(pred));

    }

    public async void OnTelegramUserData(string json)
    {
        Debug.Log("Получены данные из Telegram: " + json);

        try
        {
            TelegramIdUser user = JsonConvert.DeserializeObject<TelegramIdUser>(json);


            if (user != null)
            {
                var createPlayerModel = new CreatePlayerModel()
                {
                    UserId = user.id,
                    FirstName = user.first_name,
                    LastName = user.last_name,
                    UserName = user.username
                };
                await StartPlayerWork(createPlayerModel);            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Ошибка при парсинге JSON из Telegram: " + ex.Message);
        }
    }

    public static IEnumerator PostPlayerData(CreatePlayerModel createPlayerModel)
    {
        var url = $"https://petroinfocomplexteam-gameserver-7875.twc1.net/PlayerData";

        var json = JsonConvert.SerializeObject(createPlayerModel);
        var jsonBytes = Encoding.UTF8.GetBytes(json);

        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(jsonBytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Отправка JSON: " + json);

        yield return request.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
        if (request.result != UnityWebRequest.Result.Success)
#else
        if (request.isNetworkError || request.isHttpError)
#endif
        {
            Debug.LogError("Ошибка запроса: " + request.error);
        }
        else
        {
            Debug.Log("Успешно! Ответ сервера: " + request.downloadHandler.text);
        }
    }

    public static IEnumerator PutPlayerData(Predator aPredator)
    {
        var url = $"https://petroinfocomplexteam-gameserver-7875.twc1.net/PlayerData/userId?userId={aPredator.UserId}";

        var json = JsonConvert.SerializeObject(new ForPredator(aPredator));
        var jsonBytes = Encoding.UTF8.GetBytes(json);

        var request = new UnityWebRequest(url, "PUT");
        request.uploadHandler = new UploadHandlerRaw(jsonBytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Отправка JSON: " + json);

        yield return request.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
        if (request.result != UnityWebRequest.Result.Success)
#else
        if (request.isNetworkError || request.isHttpError)
#endif
        {
            Debug.LogError("Ошибка запроса: " + request.error);
        }
        else
        {
            Debug.Log("Успешно! Ответ сервера: " + request.downloadHandler.text);
        }
    }


    public static IEnumerator GetPlayerData(Predator aPredator)
    {
        var url = $"https://petroinfocomplexteam-gameserver-7875.twc1.net/PlayerData/userId?userId={aPredator.UserId}";

        //var json = JsonConvert.SerializeObject(new ForPredator(aPredator));
        //var jsonBytes = Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Ошибка: " + request.error);
        }
        else
        {
            string json = request.downloadHandler.text;
            var fPred = JsonConvert.DeserializeObject<ForPredator>(json);
            aPredator.ForPredator(fPred);
        }

#if UNITY_2020_1_OR_NEWER
            if (request.result != UnityWebRequest.Result.Success)
#else
        if (request.isNetworkError || request.isHttpError)
#endif
        {
            Debug.LogError("Ошибка запроса: " + request.error);
        }
        else
        {
            Debug.Log("Успешно! Ответ сервера: " + request.downloadHandler.text);
        }
    }

}