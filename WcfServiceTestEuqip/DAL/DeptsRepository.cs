using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfServiceTestEuqip.DAL
{
    public class DeptsRepository
    {
        /// <summary>
        /// GET all Departments items method
        /// </summary>
        /// <returns>
        /// list of Departments items from DB
        /// </returns>
        public static List<Depart> GetAll()
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                return context.Depts.Select(d => new Depart
                {
                    Id = d.Id,
                    Name = d.DeptName
                }).ToList();
            }
        }

        /// <summary>
        /// GET Department by Id method
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Department model
        /// </returns>
        public static Depart GetItem(string id)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                int nId = Convert.ToInt32(id);
                return context.Depts.Where(d => d.Id == nId).Select(d => new Depart
                {
                    Id = d.Id,
                    Name = d.DeptName
                }).FirstOrDefault();
            }
        }

        /// <summary>
        /// CREATE Department method
        /// </summary>
        /// <param name="depart"></param>
        /// <returns>
        /// bool value of method's execution
        /// </returns>
        public static bool Create(Depart depart)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    DeptEntity newE = new DeptEntity();
                    newE.DeptName = depart.Name;

                    context.Depts.Add(newE);
                    context.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// UPDATE Department method
        /// </summary>
        /// <param name="depart"></param>
        /// <returns>
        /// bool value of method's execution
        /// </returns>
        public static bool Update(Depart depart)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    int id = Convert.ToInt32(depart.Id);
                    var dep = context.Depts.SingleOrDefault(d => d.Id == id);
                    dep.DeptName = depart.Name;
                    context.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// DELETE Department method
        /// </summary>
        /// <param name="depart"></param>
        /// <returns>
        /// bool value of method's execution
        /// </returns>
        public static bool Remove(Depart depart)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    int id = Convert.ToInt32(depart.Id);
                    DeptEntity dept = context.Depts.Single(d => d.Id == id);

                    context.Depts.Remove(dept);

                    var equipments = context.Equip.Where(e => e.DeptsId == dept.Id).ToList();

                    foreach (var eq in equipments)
                    {
                        eq.DeptsId = null;
                    }

                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}