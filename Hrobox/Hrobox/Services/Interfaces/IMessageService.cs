using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hrobox.Services.Interfaces
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
    }
}
