using System.Net.Http;
using UnityEngine;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class ServerWork : MonoBehaviour
{
    public static async Task GetPlayerProgress(ForPredator aPredator)
    {
        //Создание клиента для https запросов
        using var client = new HttpClient();
        //Адрес запроса для удаления данных игрока
        var url = $"https://petroinfocomplexteam-gameserver-7875.twc1.net/PlayerData/userId?userId={aPredator.UserId}";
        // Пример GET-запроса с JSON
        var getResponse = await client.GetAsync(url);
        var getResult = await getResponse.Content.ReadAsStringAsync();
        //Готовим опции для десериализации
        //var options = new JsonSerializerOptions
        //{
        //    PropertyNameCaseInsensitive = true // если в JSON поля с маленькой буквы
        //};
        //Десериализуем ответ
        aPredator = JsonConvert.DeserializeObject<ForPredator>(getResult);
        //foreach (var item in deserializedComplex.names)

    }

}




