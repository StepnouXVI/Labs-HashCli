namespace Domain;

public class SumHashComputer : I32BitHashComputer
{
    public uint ComputeHash(string filePath)
    {
        uint hash = 0;

        using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        using var reader = new BinaryReader(fileStream);

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            hash+=reader.ReadUInt32();
        }

        return hash;
    }
}