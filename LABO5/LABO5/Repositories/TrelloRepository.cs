using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LABO5.Models;
using Newtonsoft.Json;

namespace LABO5.Repositories
{
    public static class TrelloRepository
    {

        private const string _APIKEY = "b5128c8a3d416d0183221889892b6d2b";
        private const string _USERTOKEN = "5655cf5dd64410ec8f392ade7055f9bc0c6bca47b4dd467363bf55be8c465547";
        private const string _BASEURI = "https://api.trello.com/1";
        private static HttpClient GetHttpClient()
        {


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
            //curl 'https://api.trello.com/1/members/me/boards?key={yourKey}&token={yourToken}'

        }

        public static async Task <List<TrelloBoard>> GetTrelloBoardsAsync() {

            string url = $"https://api.trello.com/1/members/me/boards?key={_APIKEY}&token={_USERTOKEN}";
            using(HttpClient client=GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<TrelloBoard> list = JsonConvert.DeserializeObject<List<TrelloBoard>>(json);// De data ophalen 
                    return list;
                }
                catch(Exception ex)
                {
                    throw ex;
                }


            }
 }

        public static async Task<List<TrelloList>> GetTrelloListAsync(string boardId)
        {

            string url = $"{_BASEURI}/boards/{boardId}/lists?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<TrelloList> list = JsonConvert.DeserializeObject<List<TrelloList>>(json);// De data ophalen 
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public static async Task<List<TrelloCard>> GetTrelloCardAsync(string cardId)
        {

            string url = $"{_BASEURI}/lists/{cardId}/cards/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<TrelloCard> item = JsonConvert.DeserializeObject<List<TrelloCard>>(json);// De data ophalen 
                    return item ;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public static async Task<TrelloCard> GetTrelloCardByIdAsync(string cardId)
        {

            string url = $"{_BASEURI}/cards/{cardId}/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    TrelloCard item = JsonConvert.DeserializeObject<TrelloCard>(json);// De data ophalen 
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public static async Task<TrelloList> GetTrellListByIdAsync(string ListId)
        {

            string url = $"{_BASEURI}/lists/{ListId}/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    TrelloList item = JsonConvert.DeserializeObject<TrelloList>(json);// De data ophalen 
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public static async Task UpdateCardAsync(TrelloCard card)
        {
            string url = $"{_BASEURI}/cards/{card.CardId}/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //string json = await client.GetStringAsync(url);
                    //TrelloCard item = JsonConvert.DeserializeObject<TrelloCard>(json);// De data ophalen 
                    //return item;

                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response= await client.PutAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errormsg = $"Unsucessfull PUT to url {url} , object:{json}";
                        throw new Exception(errormsg); // Springt automatisch naar de catch function 
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public static async Task AddCardAsync(string listid,TrelloCard card)
        {
            string url = $"{_BASEURI}/cards?idList={listid}&key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //string json = await client.GetStringAsync(url);
                    //TrelloCard item = JsonConvert.DeserializeObject<TrelloCard>(json);// De data ophalen 
                    //return item;

                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errormsg = $"Unsucessfull POST to url {url} , object:{json}";
                        throw new Exception(errormsg); // Springt automatisch naar de catch function
                        
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }





    }

}