using System.IO.Hashing;

namespace Domain;

public class SRC32HashComputer : I32BitHashComputer
{
    public uint ComputeHash(string filePath)
    {
        var hasher = new Crc32();

        using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        hasher.Append(fileStream);

        return hasher.GetCurrentHashAsUInt32();
    }
}
