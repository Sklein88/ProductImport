using Application.Client;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {        
        public Task<IClient> GetClientByName(string name)
        {
            //this could be resolve with a 
            switch (name.ToUpper()) { 
                case "CAPTERRA":
                    return Task.FromResult<IClient>(new Capterra());
                case "SOFTWAREADVICE":
                    return Task.FromResult<IClient>(new SoftwareAdvice());
                default:
                    throw new Exception("Invalid client");
            }

        }
    }
}
