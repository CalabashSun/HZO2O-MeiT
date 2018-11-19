using System;
using System.Data;

namespace MeituanApi.Core.DbContext
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Conn { get; }

        void InitConnection();
    }
}
