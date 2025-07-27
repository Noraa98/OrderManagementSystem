using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Domain.Contracts.Persistence
{
    public interface IStoreContextInitializer
    {
        Task InitializeAsync();
    }
}
