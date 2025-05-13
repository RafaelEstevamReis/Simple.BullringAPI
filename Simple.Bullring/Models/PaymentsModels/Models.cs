namespace Simple.Bullring.Models.PaymentsModels;

using System;

public class PaymentModel
{
    public Guid id { get; set; }
    public string lightningInvoice { get; set; }
    public string paymentHash { get; set; }
    public decimal paymentRequestAmount { get; set; }
    public string paymentRequestCurrency { get; set; }
    public string invoiceCurrency { get; set; }
    public decimal invoiceAmount { get; set; }
    public string status { get; set; }
    public string note { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}
