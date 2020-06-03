namespace FlexNewsApi.Models
{
  public class PatchRequest
  {
    public int EntityId { get; set; }
    public string Field { get; set; }
    public string StringValue { get; set; }
    public int? IntValue { get; set; }
  }

}