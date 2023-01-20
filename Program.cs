using System.Text;
using NameSpace;
using Newtonsoft.Json;

namespace API
{
  class Program
  {
    static string url = "YOUR URL";
    static HttpClient client = new HttpClient();
    static Model_User user = new Model_User();
    //static Model_User dataUser { get; set; }

    static async Task Main(string[] args)
    {
      await PostUser();
      await GetUsersAsync();
      await GetUser();
      await UpdateUser();
      await DeleteUser();
    }


    //======================= CREATE USER ============================
    static async Task PostUser()
    {
      user.name = "Erudito2";
      user.email = "erudito.tv@gmai6.com";
      user.phone = 0960806054;
      user.message = "Hello World..";
      user.pic = $"https://avatars.dicebear.com/api/micah/{user.name}.svg";

      try
      {
        var json = JsonConvert.SerializeObject(user);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
          var result = response.Content.ReadAsStringAsync().Result;

          Console.WriteLine(result);
        }
      }
      catch (System.Exception)
      {
        Console.WriteLine("Error");

      }
    }
    //======================= CREATE USER ============================


    //======================= GET ALL USERS ==========================
    static async Task GetUsersAsync()
    {
      try
      {
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
          var json = await response.Content.ReadAsStringAsync();
          Console.WriteLine(json);
        }
      }
      catch (System.Exception)
      {
        Console.WriteLine("Error");
      }
    }
    //======================= GET ALL USERS ===========================



    //======================= GET ONE USER ============================
    static async Task GetUser()
    {
      try
      {
        var response = client.GetAsync(url + "/63cac82fcea0d92ffb7dc2d1").Result;

        if (response.IsSuccessStatusCode)
        {
          var json = await response.Content.ReadAsStringAsync();
          Console.WriteLine(json);
        }
      }
      catch (System.Exception)
      {
        Console.WriteLine("Error");
      }
    }
    //======================= GET ONE USER ============================



    //======================= UPDATE USER =============================
    static async Task UpdateUser()
    {
      user.name = "Jorge";
      user.email = "2020@gmaid.com";
      user.phone = 1234567890;
      user.message = "que tal";
      user.pic = $"https://avatars.dicebear.com/api/micah/{user.name}.svg";

      try
      {
        var json = JsonConvert.SerializeObject(user);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync(url + "/63cac82fcea0d92ffb7dc2d1", content);

        if (response.IsSuccessStatusCode)
        {
          var result = response.Content.ReadAsStringAsync().Result;

          Console.WriteLine(result);
        }
      }
      catch (System.Exception)
      {
        Console.WriteLine("Error");
      }
    }
    //======================= UPDATE USER =============================



    //======================= DELETE USER =============================
    static async Task DeleteUser()
    {
      try
      {
        var response = await client.DeleteAsync(url + "/63cac82fcea0d92ffb7dc2d1");

        if (response.IsSuccessStatusCode)
        {
          var result = response.Content.ReadAsStringAsync().Result;

          Console.WriteLine(result);
        }
      }
      catch (System.Exception)
      {
        Console.WriteLine("Error");
      }
    }
    //======================= DELETE USER =============================
  }
}

