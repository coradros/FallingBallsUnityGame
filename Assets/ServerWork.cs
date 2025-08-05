using System.Net.Http;
using UnityEngine;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class ServerWork : MonoBehaviour
{
    public static async Task GetPlayerProgress(ForPredator aPredator)
    {
        //�������� ������� ��� https ��������
        using var client = new HttpClient();
        //����� ������� ��� �������� ������ ������
        var url = $"https://petroinfocomplexteam-gameserver-7875.twc1.net/PlayerData/userId?userId={aPredator.UserId}";
        // ������ GET-������� � JSON
        var getResponse = await client.GetAsync(url);
        var getResult = await getResponse.Content.ReadAsStringAsync();
        //������� ����� ��� ��������������
        //var options = new JsonSerializerOptions
        //{
        //    PropertyNameCaseInsensitive = true // ���� � JSON ���� � ��������� �����
        //};
        //������������� �����
        aPredator = JsonConvert.DeserializeObject<ForPredator>(getResult);
        //foreach (var item in deserializedComplex.names)

    }

}




