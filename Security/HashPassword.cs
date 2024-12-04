using System.Security.Cryptography;

public class Hashing
{
    private int SaltSize = 16;
    private int HashSize = 32;
    private int Iterations = 100000;
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithm,
            HashSize
        );
        return $"{Convert.ToHexString(salt)}.{Convert.ToHexString(hash)}";
    }

    public bool Verify(string password, string hash)
    {
        string[] parts = hash.Split('.');
        byte[] salt = Convert.FromHexString(parts[0]);
        byte[] hashToCheck = Convert.FromHexString(parts[1]);
        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithm,
            HashSize
        );
        return CryptographicOperations.FixedTimeEquals(inputHash, hashToCheck);
    }
}
