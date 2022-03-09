using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client
{
    public interface IClientService
    {
        Task<IClient> GetClientByName(string name);
    }
}
