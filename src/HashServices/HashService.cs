using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace HashServices;

public class HashService : IHashService
{
    private readonly Dictionary<string, I32BitHashComputer> _computers;

    public HashService(Dictionary<string, I32BitHashComputer> computers)
    {
        _computers = computers;
    }

    public uint ComputeHash(string mode, string filePath)
    {
        if(!_computers.ContainsKey(mode))
        {
          throw new KeyNotFoundException($"Undefined mode specified.({mode})");  
        }

        return _computers[mode].ComputeHash(filePath);
    }
}
