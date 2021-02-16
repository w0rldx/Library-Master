using System.Collections.Generic;
using System.Threading.Tasks;
using Library_Master.Core.Models;
using Library_Master.EntityFramework;
using Library_Master.EntityFramework.Services;

namespace Library_Master.Core.Services
{
    public class IndexCardService : IIndexCardService
    {

        //TODO:Fix CARD DATA FROM DATABASE
        public async Task<IndexCard> GetIndexCard(IndexCardType indextype)
        {
            var test = new IndexCard(2, IndexCardType.Books);
            return test;
        }
    }
}