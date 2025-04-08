using System;

namespace FinanceManager
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}