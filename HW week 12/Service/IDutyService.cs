using HW_week_12.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_week_12.Repository
{
    public interface IDutyService
    {
        public void Add(int userId, string title, DateTime timeToDone, int order, State state);
        public List<Duty> GetAll();
        public void Update(int id, string title, DateTime timeToDone, int order, State state);
        public Result Delete(int id);
        public Result ChangeStatus(int id, State state);
        public List<Duty> Search(string title);
    }
}
