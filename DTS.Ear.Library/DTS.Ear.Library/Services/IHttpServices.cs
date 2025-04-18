﻿using System.Threading.Tasks;

namespace DTS.Ear.Library.Services
{
    public interface IHttpServices<T>
    {
        Task<T> DispatchCommand(string command, string pageName, object data, bool encodeUrl);
        Task<T> DispatchCommand(string command, string pageName, object data);
        Task<T> DispatchCommand(string command, string pageName);
        Task<T> Login();
    }
}