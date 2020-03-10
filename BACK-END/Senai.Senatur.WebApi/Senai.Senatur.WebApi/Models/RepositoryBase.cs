using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Models
{
    public class RepositoryBase
    {
       protected SenaturContext dbo = new SenaturContext();
    }
}
