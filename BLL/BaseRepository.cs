using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseRepository<T> where T : class
    {
        public BaseRepository()
        {
            if (BlogContext.db == null) BlogContext.db = new BlogContext();
        }

        public List<T> GetAll()
        {
            List<T> liste = BlogContext.db.Set<T>().ToList();
            return liste;
        }
        public List<T> Search(string value)
        {
            List<T> liste = BlogContext.db.Set<T>().ToList();
            return liste;
        }
        public void DetachList(List<T> liste)
        {
            liste.ForEach(group => BlogContext.db.Entry(group).State = System.Data.Entity.EntityState.Detached);
        }
        public T GetById(int id)
        {
            return BlogContext.db.Set<T>().Find(id);
        }
        public void Insert(T obj)
        {
            BlogContext.db.Set<T>().Add(obj);
            BlogContext.db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = BlogContext.db.Set<T>().Find(id);
            BlogContext.db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            BlogContext.db.SaveChanges();
        }
        public void Update(T obj)
        {
            BlogContext.db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            BlogContext.db.SaveChanges();
        }
       
    }
}
