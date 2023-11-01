using System;
using System.Threading.Tasks;
using RestSharp;
using ApiCall.Keys;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using BookManager.Models;

namespace BookManager.Services;
public class ApiHelper
{
  public static async Task<string> BooksCall(string apiKey, string title)
  {
    //headers: Title, Author, ISBN -> 
    RestClient client = new RestClient("TODO");
    RestRequest request = new RestRequest($"home.json?api-key={apiKey}&title={title}", Method.Get);
    RestResponse response = await client.ExecuteAsync(request);
    return response.Content;
  }
}