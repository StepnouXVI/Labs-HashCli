using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashServices;

    public interface IHashService
    {
        uint ComputeHash(string mode, string filePath); 
    }
