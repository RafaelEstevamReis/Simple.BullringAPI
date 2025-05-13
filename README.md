# Simple.BullringAPI

A simple C# client library for interacting with the [Bullring Finance](https://www.bullring.finance/) API, 
enabling developers to manage subaccounts, payments, withdrawals, bank verifications, and more.

Official Documentation: [https://docs.bullring.finance/en/introduction](https://docs.bullring.finance/en/introduction)

# Getting Started

* You must have an active account with BullRing Finance
* Familiarize yourself with BullRing Finance [official documentation](https://docs.bullring.finance/en/introduction)
* Ensure you have a valid Bullring Finance API key for production or staging environments.

## Installation

NuGet [link](https://www.nuget.org/packages/Simple.Bullring):
~~~
PM> NuGet\Install-Package Simple.Bullring
~~~

## Initializing the Client

Create a `BullringClient` instance for either production or staging environments using your API key.

~~~
using Simple.Bullring;

// Production environment
var client = new BullringClient("your-production-api-key");

// Staging environment
var stagingClient = BullringClient.FromStagingEnviroment("your-staging-api-key");
~~~

## Key Features

Below are examples demonstrating common operations with the BullringClient class.

### 1. Retrieve All Subaccounts

Fetch a paginated list of all subaccounts associated with the authenticated merchant.

~~~
var subaccounts = await client.SubAccount_GetAllMerchants();
foreach (var merchant in subaccounts.Data)
{
    Console.WriteLine($"Merchant ID: {merchant.Id}, Name: {merchant.Name}");
}
~~~

### 2. Get Subaccount Details

Retrieve details for a specific subaccount using its UUID.

~~~
var subaccountId = Guid.Parse("123e4567-e89b-12d3-a456-426614174000");
var merchant = await client.SubAccount_GetMerchant(subaccountId);
Console.WriteLine($"Subaccount Name: {merchant.Name}, Status: {merchant.Status}");
~~~

### 3. Get KYB Verification URL

Obtain a KYB verification URL for a subaccount to share with them.

~~~
var subaccountId = Guid.Parse("123e4567-e89b-12d3-a456-426614174000");
var kybUrl = await client.Verification_GetKybUrl(subaccountId);

Console.WriteLine($"KYB URL: {kybUrl.Url}");
~~~

### 4. Verify and Add a Pix Key

Verify a Pix key and add it to a subaccount’s bank details.

~~~
var subaccountId = Guid.Parse("123e4567-e89b-12d3-a456-426614174000");
var pixKey = "667.136.083-96" // documentation example

// Verify Pix key
var verificationResult = await client.Bank_VerifyPixKey(subaccountId, pixKey);
Console.WriteLine($"Pix Key Verified: {verificationResult.IsValid}");

// Add verified Pix key
await client.Bank_AddPixKey(subaccountId, pixKey);
Console.WriteLine("Pix Key added successfully.");
~~~

### 5. Retrieve All Payments

Fetch all payments for a specific subaccount.

~~~
var subaccountId = Guid.Parse("123e4567-e89b-12d3-a456-426614174000");
var payments = await client.Payments_GetAllPayments(subaccountId);
foreach (var payment in payments)
{
    Console.WriteLine($"Payment ID: {payment.Id}, Amount: {payment.Amount}");
}
~~~

### 6. Retrieve Withdrawal Details

Get details for a specific withdrawal request.

~~~
var subaccountId = Guid.Parse("123e4567-e89b-12d3-a456-426614174000");
var withdrawalId = Guid.Parse("987fcdeb-1234-5678-9012-426614174000");
var withdrawal = await client.Withdrawals_GetWithdrawal(subaccountId, withdrawalId);
Console.WriteLine($"Withdrawal ID: {withdrawal.Id}, Status: {withdrawal.Status}");
~~~

### Error Handling

All methods throw exceptions if the API request fails. Use try-catch blocks to handle errors gracefully.

~~~
try
{
    var subaccounts = await client.SubAccount_GetAllMerchants();
    // Process subaccounts
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
~~~

## API Compliance: 9/15

Current API Compliance state

* Sub Account:
  * [X] Get all merchants
  * [ ] Create merchant
  * [x] Get one merchant by ID

* Verification:
  * [x] Get KYB url

* Bank:
  * [X] Verify Pix Key
  * [x] Add Pix Key

* Payments:
  * [x] Get all payments
  * [x] Create payment
  * [x] Get one payment by ID

* Withdrawals:
  * [x] Get all withdrawals
  * [ ] Initiate withdrawal
  * [x] Get one withdrawal by ID
  * [ ] Set daily withdrawal schedule

* Webhook:
  * [ ] Add Webhook
  * [ ] Delete Webhook

## Contributing
Contributions are welcome! Please submit issues or pull requests to the repository

## License
This library is licensed under the MIT License. See the LICENSE file for details
