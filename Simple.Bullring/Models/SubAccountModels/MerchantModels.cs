namespace Simple.Bullring.Models.SubAccountModels;

using System;

public record MerchantsModel
{
    public Guid id { get; set; }
    public string email { get; set; }
}
public record MerchantModel
{
    public string id { get; set; }
    public object name { get; set; }
    public string email { get; set; }
    public object phone { get; set; }
    public object country { get; set; }
    public object stateProvinceRegion { get; set; }
    public SubscriptionModel[] subscriptions { get; set; }
    public object city { get; set; }
    public object postalCode { get; set; }
    public object address { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string preferredCurrency { get; set; }
    public int balance { get; set; }
    public int withdrawalMinimum { get; set; }
}
