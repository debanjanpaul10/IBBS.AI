namespace IBBS.AI.API.Helpers
{
    using Azure.Identity;
    using Azure.Security.KeyVault.Secrets;
    using IBBS.AI.Shared.Constants;
    
    /// <summary>
	/// The Key Vault Helper Class.
	/// </summary>
	public static class KeyVaultHelper
	{
		/// <summary>
		/// Gets the key value asynchronous.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		/// <param name="keyName">Name of the key.</param>
		/// <returns>The key value.</returns>
		public static string GetSecretDataAsync(ConfigurationManager configuration, string keyName)
		{
			var keyVaultUri = configuration.GetValue<string>(ConfigurationConstants.KeyVaultEndpointConstant);
			if (!string.IsNullOrEmpty(keyVaultUri))
			{
				var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

				var secret = client.GetSecretAsync(keyName).GetAwaiter().GetResult();
				return secret.Value.Value;
			}

			return string.Empty;
		}
	}
}