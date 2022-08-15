using System;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Contracts
{
    public interface IFileTextReader : IDisposable
    {
        IFileTextReader OpenFile(string fullFilePath);
        string ReadLine();
        string[] ReadAllLines(string fullFilePath);
    }
}