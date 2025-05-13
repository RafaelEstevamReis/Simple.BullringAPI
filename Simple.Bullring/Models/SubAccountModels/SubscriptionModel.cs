namespace Simple.Bullring.Models.SubAccountModels;

using System;

public class SubscriptionModel
{
    public bool isActive { get; set; }
    public Plan plan { get; set; }

    public class Plan
    {
        public string id { get; set; }
        public string name { get; set; }
        public string fixedAmount { get; set; }
        public string fixedAmountCurrency { get; set; }
        public string percentageRate { get; set; }
        public string billingType { get; set; }
        public Features features { get; set; }
        public bool isActive { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public object deletedAt { get; set; }
    }

    public class Features
    {
        public string cloud { get; set; }
        public string rewards { get; set; }
        public string support { get; set; }
        public string installation { get; set; }
    }
}