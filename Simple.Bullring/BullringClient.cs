namespace Simple.Bullring;

using Simple.Bullring.Models;
using System;
using System.Threading.Tasks;

public class BullringClient
{
    private readonly API.ClientInfo client;
    /// <summary>
    /// Internal Rest API Client
    /// </summary>
    public API.ClientInfo InternalClient => client;

    private BullringClient(string apiKey, string url)
    {
        client = new API.ClientInfo(url);
        client.SetHeader("x-api-key", apiKey);
    }

    /// <summary>
    /// Instantiates a BullringClient object for Production enviroment
    /// </summary>
    /// <param name="apiKey">Production API Key</param>
    public BullringClient(string apiKey) : this(apiKey, "https://api.bullring.finance/") { }
    /// <summary>
    /// Instantiates a BullringClient object for Staging enviroment
    /// </summary>
    /// <param name="apiKey">Staging API Key</param>
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

    #region Bank

    /// <summary>
    /// Verifies a Pix key
    /// </summary>
    /// <param name="id">Subaccount ID (UUID)</param>
    /// <param name="pixKey">BRL Account PIX Key</param>
    public async Task<Models.BankModels.VerifyPixModel> Bank_VerifyPixKey(Guid id, string pixKey)
    {
        var r = await client.PutAsync<Models.BankModels.VerifyPixModel>($"/v1/ramp/subaccount/{id}/banks", new
        {
            brlAccount = new
            {
                pixKey,
            }
        });
        r.EnsureSuccessStatusCode();
        return r.Data;
    }
    /// <summary>
    /// Merchant must first verify a Pix key before adding it to their subaccount. This endpoint is used to add a verified Pix key.
    /// </summary>
    /// <param name="id">Subaccount ID (UUID)</param>
    /// <param name="pixKey">BRL Account PIX Key</param>
    public async Task Bank_AddPixKey(Guid id, string pixKey)
    {
        var r = await client.PostAsync<string>($"/v1/ramp/subaccount/{id}/banks", new
        {
            brlAccount = new
            {
                pixKey,
            }
        });
        r.EnsureSuccessStatusCode();
    }

    #endregion

    #region Payments

    /// <summary>
    /// Retrieve all payments for a specific merchant
    /// </summary>
    /// <param name="id">Subaccount ID (UUID)</param>
    public async Task<Models.PaymentsModels.PaymentModel[]> Payments_GetAllPayments(Guid id)
    {
        var r = await client.GetAsync<Models.PaymentsModels.PaymentModel[]>($"/v1/ramp/subaccount/{id}/payments");
        r.EnsureSuccessStatusCode();
        return r.Data;
    }
    /// <summary>
    /// Retrieve details of a specific payment by ID.
    /// </summary>
    /// <param name="id">Subaccount ID (UUID)</param>
    /// <param name="paymentId">Payment ID (UUID)</param>
    public async Task<Models.PaymentsModels.PaymentModel> Payments_GetPayment(Guid id, Guid paymentId)
    {
        var r = await client.GetAsync<Models.PaymentsModels.PaymentModel>($"/v1/ramp/subaccount/{id}/payments/{paymentId}");
        r.EnsureSuccessStatusCode();
        return r.Data;
    }

    #endregion

    #region Withdrawals

    /// <summary>
    /// Retrieve a list of all withdrawals associated with a subaccount
    /// </summary>
    /// <param name="id">Subaccount ID (UUID)</param>
    public async Task<ResponseBase<Models.WithdrawalsModels.WithdrawalModel[]>> Withdrawals_GetAllWithdrawals(Guid id)
    {
        var r = await client.GetAsync<ResponseBase<Models.WithdrawalsModels.WithdrawalModel[]>>($"/v1/ramp/subaccount/{id}/withdrawals");
        r.EnsureSuccessStatusCode();
        return r.Data;
    }
    /// <summary>
    /// Retrieve the details of a specific withdrawal request
    /// </summary>
    /// <param name="id">Subaccount ID (UUID)</param>
    /// <param name="withdrawalId">Withdrawal ID (UUID)</param>
    public async Task<Models.WithdrawalsModels.WithdrawalModel> Withdrawals_GetWithdrawal(Guid id, Guid withdrawalId)
    {
        var r = await client.GetAsync<Models.WithdrawalsModels.WithdrawalModel>($"/v1/ramp/subaccount/{id}/withdrawals/{withdrawalId}");
        r.EnsureSuccessStatusCode();
        return r.Data;
    }

    #endregion

}
