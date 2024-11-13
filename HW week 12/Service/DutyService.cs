using HW_week_12.Entitis;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_week_12.Repository
{
    public class DutyService : IDutyService
    {
        private IDutyRepository _repository;

        public DutyService()
        {
            _repository = new DutyRepository();
        }
        public void Add(string title, DateTime timeToDone, int order, State state)
        {
            _repository.Add(title, timeToDone, order, state);
        }

        public Result ChangeStatus(int id, State state)
        {
            return _repository.ChangeStatus(id, state); 
        }

        public Result Delete(int id)
        {
           return _repository.Delete(id);
        }

        public List<Duty> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Duty> Search(string title)
        {
            return _repository.Search(title);
        }

        public void Update(int id, string title, DateTime timeToDone, int order, State state)
        {
            _repository.Update(id, title, timeToDone, order, state);

        }
    }
}
