namespace Simple.Bullring;

using Simple.Bullring.Models;
using System;
using System.Threading.Tasks;

public class BullringClient
{
    private readonly API.ClientInfo client;
    public API.ClientInfo InternalClient => client;

    private BullringClient(string apiKey, string url)
    {
        client = new API.ClientInfo(url);
        client.SetHeader("x-api-key", apiKey);
    }

    public BullringClient(string apiKey) : this(apiKey, "https://api.bullring.finance/") { }
    public static BullringClient FromStagingEnviroment(string apiKey) => new BullringClient(apiKey, "https://staging-api.bullring.finance/");

}
