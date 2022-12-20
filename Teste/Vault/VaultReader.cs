using System;
using Teste.Config;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace Teste.Vault
{
	public static class VaultReader
	{
		public static async void Bind(VaultConfig vault, SecureCardConfig sc)
		{
            var segredos = Read(vault);
			var propriedades = sc.GetType().GetProperties();

			foreach (var propriedade in propriedades)
			{
                if (segredos.Result.Data.Data.ContainsKey(propriedade.Name))
                {
                    propriedade.SetValue(sc, segredos.Result.Data.Data[propriedade.Name]);
                }
			}
		}

        private static async Task<Secret<SecretData>> Read(VaultConfig vault)
        {
            var vaultAddr = vault.Endereco;
            var vaultToken = vault.Token;
            IAuthMethodInfo tokenAuthMethod = new TokenAuthMethodInfo(vaultToken);
            var vaultClientSettings = new VaultClientSettings(vaultAddr, tokenAuthMethod);

            IVaultClient vaultClient = new VaultClient(vaultClientSettings);

            var segredos = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(path: "/segredinhos", mountPoint: "secret");

            return segredos;
        }
    }
}

