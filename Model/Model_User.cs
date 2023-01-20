namespace NameSpace
{
  public class Model_User
  {
    //public string _id { get; set; }
    public string name { get; set; } = "";
    public string email { get; set; } = "";
    public int phone { get; set; } = 0;
    public string message { get; set; } = "";
    public string pic { get; set; } = "";
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
  }
}
