using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;


public class TelegramUser : MonoBehaviour
{
    [System.Serializable]
    public class TelegramIdUser
    {
        public long id;
        public string first_name;
        public string last_name;
        public string username;
        public string language_code;
        public bool is_premium;
        // добавь другие поля по необходимости
    }

    public void OnTelegramUserData(string json)
    {
        Debug.Log("Получены данные из Telegram: " + json);

        try
        {
            TelegramIdUser user = JsonConvert.DeserializeObject<TelegramIdUser>(json);
            gameObject.GetComponent<TextMeshPro>().text = "ID: {user.id}, Username: {user.username}, Name: {user.first_name} {user.last_name}";

            // Здесь можно сохранить user в Singleton или передать в нужную систему
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Ошибка при парсинге JSON из Telegram: " + ex.Message);
        }
    }
}
