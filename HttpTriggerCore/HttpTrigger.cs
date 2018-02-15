using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace HttpTriggerCore
{
    public class HttpTrigger
    {
        public static async Task Run(string input, TraceWriter log)
        {
            log.Info($"C# function executed: {input}");
            var connection = new HubConnectionBuilder()
                .WithUrl("https://sidneywebapptest.azurewebsites.net/chat")
                .Build();
                
            await connection.StartAsync();

            await connection.InvokeAsync<object>("send", input);
        }
    }
}
