using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ParksClient.Models
{
  public class Park 
  {
    public int ParkId { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public string Description { get; set; }
    public string Established { get; set; }

    public static List<Park> GetParks()
    {
      Task<string> apiCallTask = ApiHelper.ApiCall();
      string result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Park> parkList = JsonConvert.DeserializeObject<List<Park>>(jsonResponse.ToString());
      return parkList;
    }
    public static Park GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.Get(id);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Park park = JsonConvert.DeserializeObject<Park>(jsonResponse.ToString());
      return park;
    }
    public static void Post(Park park)
    {
      string jsonPark = JsonConvert.SerializeObject(park);
      ApiHelper.Post(jsonPark);
    }
    public static void Put(Park park)
    {
      string jsonPark = JsonConvert.SerializeObject(park);
      ApiHelper.Put(park.ParkId, jsonPark);
    }
    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}