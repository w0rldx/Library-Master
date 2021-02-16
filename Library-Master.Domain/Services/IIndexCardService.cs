using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Master.Core.Models;

namespace Library_Master.Core.Services
{
    public interface IIndexCardService
    {
        Task<IndexCard> GetIndexCard(IndexCardType indextype);
    }
}
