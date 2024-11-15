using HW_week_12.DbContect;
using HW_week_12.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_week_12.Repository
{
    public class DutyRepository : IDutyRepository
    {
        private readonly AppDbContext _appDbContext;

        public DutyRepository()
        {
            _appDbContext = new AppDbContext();
        }


        public void Add(int userId, string title, DateTime timeToDone, int order, State state)
        {
            var duty = new Duty(userId, title, timeToDone, order, state);
            _appDbContext.Duties.Add(duty);
            _appDbContext.SaveChanges();
        }

        public Result ChangeStatus(int id, State state)
        {
            Result result; // برای اینکه دوجا ریترن نکنیم 
            var tasks = _appDbContext.Duties.FirstOrDefault(t => t.Id == id);
            tasks.State = state;

            if (tasks != null)
            {
                _appDbContext.Duties.Update(tasks);
                _appDbContext.SaveChanges();
                result = new Result()
                {
                    IsSuccess = true,
                    ResultText = "Success."

                };
            }
            else
            {
                result = new Result()
                {
                    IsSuccess = false,
                    ResultText = $"Cannot found Id = {id}."

                };
            }
            return result;
        }

        public Result Delete(int id)
        {
            Result result; 
            var duty = _appDbContext.Duties.FirstOrDefault(t => t.Id == id);
            if(duty != null)
            {
                _appDbContext.Duties.Remove(duty);
                _appDbContext.SaveChanges();
                 result = new Result()
                {
                    IsSuccess = true,
                    ResultText = "Success."

                };
            }
            else
            {
                 result = new Result()
                {
                    IsSuccess = false,
                    ResultText = $"Cannot found Id = {id}."

                };
            }
            return result;
        }

        public List<Duty> GetAll()
        {
            var tasks = _appDbContext.Duties.ToList();
            return tasks;

        }

        public List<Duty> Search(string title)
        {
            var tasks = _appDbContext.Duties.Where(t => t.Title.Contains(title)).ToList();
            return tasks;

            //if(tasks != null)
            //{
            //    _appDbContext.Duties.Search(tasks);
            //    _appDbContext.SaveChanges();
            //    return tasks;
            //}
            //else
            //{
            //    throw new Exception($"cannot found task with id {title}");
            //}
        }

        public void Update(int id, string title, DateTime timeToDone, int order, State state)
        {
           
            var duties = _appDbContext.Duties.FirstOrDefault(t=>t.Id == id);
            duties.Title = title;
            duties.TimeToDone = timeToDone;
            duties.Order = order;
            duties.State = state;
            _appDbContext.Duties.Update(duties);
            _appDbContext.SaveChanges();           
        }
    }
}
