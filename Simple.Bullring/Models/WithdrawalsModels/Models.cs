namespace Simple.Bullring.Models.WithdrawalsModels;

using System;

public record WithdrawalModel
{
    public Guid id { get; set; }
    public string payoutAmountDueInCrypto { get; set; }
    public string payoutAmountDueCurrency { get; set; }
    public string payoutDueTime { get; set; }
    public string status { get; set; }
    public object bankAccountId { get; set; }
    public string paymentRequestCurrency { get; set; }
    public string amountStoreReceives { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}
