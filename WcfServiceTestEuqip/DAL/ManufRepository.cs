using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfServiceTestEuqip.DAL
{
    public class ManufRepository
    {
        /// <summary>
        /// GET Manufacturers method
        /// </summary>
        /// <returns></returns>
        public static List<Manufact> GetAll()
        {
            using(EquipmentsEntities context = new EquipmentsEntities())
            {
                return context.Manufactures.Select(m => new Manufact
                {
                    Id = m.Id,
                    Name = m.ManufName
                }).ToList();
            }
        }

        /// <summary>
        /// GET Manufacturer method by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Manufacturer model
        /// </returns>
        public static Manufact GetItem(string id)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                int nId = Convert.ToInt32(id);
                return context.Manufactures.Where(m => m.Id == nId).Select(m => new Manufact
                {
                    Id = m.Id,
                    Name = m.ManufName
                }).FirstOrDefault();
            }
        }

        /// <summary>
        /// CREATE Manufacturer method
        /// </summary>
        /// <param name="manufact"></param>
        /// <returns>
        /// bool value of method's execution
        /// </returns>
        public static bool Create (Manufact manufact)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    ManufactureEntity newE = new ManufactureEntity();
                    newE.ManufName = manufact.Name;

                    context.Manufactures.Add(newE);
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
        /// UPDATE Manufacturer method
        /// </summary>
        /// <param name="manufact"></param>
        /// <returns>
        /// bool value of metho's execution
        /// </returns>
        public static bool Update(Manufact manufact)
        {
            using(EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    int id = Convert.ToInt32(manufact.Id);
                    var man = context.Manufactures.SingleOrDefault(m => m.Id == id);
                    man.ManufName = manufact.Name;

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
        /// DELETE Manufacturer method
        /// </summary>
        /// <param name="manufact"></param>
        /// <returns>
        /// bool value of method's execution
        /// </returns>
        public static bool Remove (Manufact manufact)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    int id = Convert.ToInt32(manufact.Id);
                    var man = context.Manufactures.Single(m => m.Id == id);

                    var equipments = context.Equip.Where(e => e.ManufacturesId == man.Id).ToList();

                    foreach (var eq in equipments)
                    {
                        eq.ManufacturesId = null;
                    }
                    
                    context.Manufactures.Remove(man);
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