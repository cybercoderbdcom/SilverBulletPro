using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SilverBulletPro
{
	// Token: 0x02000016 RID: 22
	internal class CryptConfig
	{
		// Token: 0x060000CB RID: 203 RVA: 0x00008914 File Offset: 0x00006B14
		public static void Encrypt(string path, string password, string outputPath)
		{
			byte[] array = CryptConfig.GenerateRandomSalt();
			using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
			{
				byte[] bytes = Encoding.UTF8.GetBytes(password);
				using (Aes aes = Aes.Create())
				{
					aes.KeySize = 128;
					aes.BlockSize = 128;
					aes.Padding = PaddingMode.PKCS7;
					Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(bytes, array, 41560);
					aes.Key = rfc2898DeriveBytes.GetBytes(aes.KeySize / 8);
					aes.IV = rfc2898DeriveBytes.GetBytes(aes.BlockSize / 8);
					aes.Mode = CipherMode.CBC;
					fileStream.Write(array, 0, array.Length);
					using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
					{
						using (FileStream fileStream2 = new FileStream(path, FileMode.Open))
						{
							byte[] array2 = new byte[1048576];
							try
							{
								int count;
								while ((count = fileStream2.Read(array2, 0, array2.Length)) > 0)
								{
									cryptoStream.Write(array2, 0, count);
								}
								fileStream2.Close();
							}
							catch (Exception ex)
							{
								GlobalData.Logger.LogError(Components.ConfigManager, ex.Message, false, 0);
							}
							finally
							{
								cryptoStream.Close();
								fileStream.Close();
							}
						}
					}
				}
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00008AE0 File Offset: 0x00006CE0
		public static Stream Decrypt(string path, string password)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(password);
			byte[] array = new byte[55];
			FileStream fileStream = new FileStream(path, FileMode.Open);
			fileStream.Read(array, 0, array.Length);
			Stream result;
			using (Aes aes = Aes.Create())
			{
				aes.KeySize = 128;
				aes.BlockSize = 128;
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(bytes, array, 41560);
				aes.Key = rfc2898DeriveBytes.GetBytes(aes.KeySize / 8);
				aes.IV = rfc2898DeriveBytes.GetBytes(aes.BlockSize / 8);
				aes.Padding = PaddingMode.PKCS7;
				aes.Mode = CipherMode.CBC;
				CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					byte[] array2 = new byte[1048576];
					try
					{
						int count;
						while ((count = cryptoStream.Read(array2, 0, array2.Length)) > 0)
						{
							memoryStream.Write(array2, 0, count);
						}
					}
					catch (CryptographicException)
					{
						GlobalData.Logger.Log("Password is invalid!", 2, true, 0);
					}
					catch (Exception ex)
					{
						GlobalData.Logger.Log(ex.Message, 2, true, 0);
					}
					try
					{
						cryptoStream.Close();
					}
					catch (Exception ex2)
					{
						Console.WriteLine("Error by closing CryptoStream: " + ex2.Message);
					}
					finally
					{
						fileStream.Close();
					}
					MemoryStream memoryStream2 = new MemoryStream();
					memoryStream.WriteTo(memoryStream2);
					memoryStream2.Seek(0L, SeekOrigin.Begin);
					result = memoryStream2;
				}
			}
			return result;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00008CE4 File Offset: 0x00006EE4
		private static byte[] GenerateRandomSalt()
		{
			byte[] array = new byte[55];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				for (int i = 0; i < 10; i++)
				{
					randomNumberGenerator.GetBytes(array);
				}
			}
			return array;
		}
	}
}
