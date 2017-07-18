using PersonRepository.CSV;
using PersonRepository.Interface;
using PersonRepository.Service;
using PersonRepository.SQL;
using System;

namespace PeopleViewer
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository(string repositoryType)
        {
            IPersonRepository repo = null;
            switch(repositoryType)
            {
                case "Service": repo = new ServiceRepository();
                    break;
                case "CSV": repo = new CSVRepository();
                    break;
                case "SQL": repo = new SQLRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid Repository Type");
            }
            return repo;
        }
    }
}
