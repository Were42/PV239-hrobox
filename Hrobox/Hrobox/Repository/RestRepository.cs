using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Hrobox.Repository
{
    public class RestService : IRepository
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }
public string getAll()
        {
            throw new NotImplementedException();
        }
    }
}
