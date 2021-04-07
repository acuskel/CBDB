using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface ICollectionDAO
    {
        List<Collection> GetCollections(int userId);
        List<Collection> GetPublicCollections();

        bool AddCollection(Collection collection);
    }
}
