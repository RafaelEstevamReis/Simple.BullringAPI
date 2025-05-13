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

    #region Sub Account

    /// <summary>
    /// Retrieves a paginated list of all subaccounts associated with the authenticated parent merchant.
    /// </summary>
    public async Task<ResponseBase<Models.SubAccountModels.MerchantsModel>> SubAccount_GetAllMerchants()
    {
        var r = await client.GetAsync<ResponseBase<Models.SubAccountModels.MerchantsModel>>("/v1/ramp/subaccount");
        r.EnsureSuccessStatusCode();
        return r.Data;
    }
    /// <summary>
    /// Retrieves the details of a single subaccount using its UUID.
    /// </summary>
    /// <param name="id">Subaccount ID</param>
    public async Task<Models.SubAccountModels.MerchantModel> SubAccount_GetMerchant(Guid id)
    {
        var r = await client.GetAsync<Models.SubAccountModels.MerchantModel>("/v1/ramp/subaccount/" + id);
        r.EnsureSuccessStatusCode();
        return r.Data;
    }

    #endregion

    #region Verification

    /// <summary>
    /// Get the KYB verification url of a subaccount and share with them to fill out their details.
    /// </summary>
    /// <param name="id">Subaccount ID</param>
    public async Task<Models.VerificationModels.KYBUrlModel> Verification_GetKybUrl(Guid id)
    {
        var r = await client.GetAsync<Models.VerificationModels.KYBUrlModel>($"/v1/ramp/subaccount/{id}/kyb");
        r.EnsureSuccessStatusCode();
        return r.Data;
    }

    #endregion

}
