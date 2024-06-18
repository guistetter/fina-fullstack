using System.Text.Json.Serialization;

namespace Fina.Core.Responses;

public  class Response<TData>//<� o generics> 
{
    private int _code = Configuration.DefaultStatusCode;

    [JsonConstructor]
    public Response() => _code = Configuration.DefaultStatusCode;
     
    public Response(
    //metodo construtor da classe
        TData? data,
        int code = Configuration.DefaultStatusCode,
        //parametro que tem o = � um opcional qdo for instanciar a classe � opcional colocar no c# isso � um optional parameters
        string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }

    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}