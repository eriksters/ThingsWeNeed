using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.DAL;
using ThingsWeNeed.Models;

namespace TestConsoleApp
{
    class RepositoryTest
    {
        public void Test() {
            IUnitOfWork uow = new UnitOfWork(new ModelContainer());
            doThing(uow);
        }

        public void doThing(IUnitOfWork unitOfWork) {
            var households = unitOfWork.HouseholdRepository.GetAll();
            foreach (Household hh in households) {
                Console.WriteLine($"{hh.Address},\n{hh.AppUsers},\n{hh.Name}");
            }
        }
    }
}
