using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfServiceTestEuqip.DAL
{
    public class EquipRepository
    {
        /// <summary>
        /// GET Equipments method. Get all equipment items from DB
        /// </summary>
        /// <returns>
        /// List of items
        /// </returns>
        public static List<EquipView> GetAll()
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                return context.Equip.Join(context.Depts,
                    e => e.DeptsId, d => d.Id, (e, d) => new
                    {
                        Name = e.EuqipName,
                        DeptsName = d.DeptName,
                        Title = e.EuqipTitle,
                        e.ManufacturesId,
                        e.EquipPrice,
                        e.DateIn,
                        e.EquipSerialNumber,
                        e.EuqipPartNumber,
                        e.Id
                    }).Join(context.Manufactures, e => e.ManufacturesId, m => m.Id, (e, m) => new EquipView
                    {
                        Name = e.Name,
                        DeptsName = e.DeptsName,
                        Title = e.Title,
                        ManufName = m.ManufName,
                        Price = e.EquipPrice,
                        DateIn = e.DateIn,
                        PNumber = e.EuqipPartNumber,
                        SNumber = e.EquipSerialNumber,
                        Id = e.Id
                    }).ToList();
            }
        }

        /// <summary>
        /// DELETE Equipment method
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns>
        /// bool value of method's execution 
        /// </returns>
        public static bool Remove(Equipment equipment)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    int id = Convert.ToInt32(equipment.Id);
                    EquipEntity equip = context.Equip.Single(e => e.Id == id);
                    context.Equip.Remove(equip);
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
        /// CREATE Equipment method
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns>
        /// bool value of method's execution
        /// </returns>
        public static bool Create(Equipment equipment)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    EquipEntity newE = new EquipEntity();
                    newE.EuqipName = equipment.Name;
                    newE.EquipPrice = equipment.Price;
                    newE.EuqipTitle = equipment.Title;
                    newE.EquipSerialNumber = equipment.SerialNumber;
                    newE.EuqipPartNumber = equipment.PartNumber;
                    newE.ManufacturesId = equipment.ManId;
                    newE.DeptsId = equipment.DepId;
                    newE.DateIn = equipment.DateIn;

                    context.Equip.Add(newE);
                    context.SaveChanges();


                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Equipment update method
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns>
        /// bool value of execution: true or false
        /// </returns>
        public static bool Update(Equipment equipment)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                try
                {
                    int id = Convert.ToInt32(equipment.Id);
                    var equip = context.Equip.SingleOrDefault(e => e.Id == id);
                    equip.EuqipName = equipment.Name;
                    equip.EuqipTitle = equipment.Title;
                    equip.EquipPrice = equipment.Price;
                    equip.EquipSerialNumber = equipment.SerialNumber;
                    equip.EuqipPartNumber = equipment.PartNumber;
                    equip.ManufacturesId = equipment.ManId;
                    equip.DeptsId = equipment.DepId;
                    equip.DateIn = equipment.DateIn;
                    context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// GET Equipment item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Equipment model with connecting data
        /// </returns>
        public static EquipView GetItem(string id)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                int nId = Convert.ToInt32(id);
                var listEquips = context.Equip.Join(context.Depts,
                    e => e.DeptsId, d => d.Id, (e, d) => new
                    {
                        Name = e.EuqipName,
                        DeptsName = d.DeptName,
                        Title = e.EuqipTitle,
                        e.ManufacturesId,
                        e.EquipPrice,
                        e.DateIn,
                        e.EquipSerialNumber,
                        e.EuqipPartNumber,
                        e.Id
                    }).Join(context.Manufactures, e => e.ManufacturesId, m => m.Id, (e, m) => new EquipView
                    {
                        Name = e.Name,
                        DeptsName = e.DeptsName,
                        Title = e.Title,
                        ManufName = m.ManufName,
                        Price = e.EquipPrice,
                        DateIn = e.DateIn,
                        PNumber = e.EuqipPartNumber,
                        SNumber = e.EquipSerialNumber,
                        Id = e.Id
                    }).ToList();

                foreach (var e in listEquips)
                {
                    if (e.Id == nId)
                        return new EquipView
                        {
                            Name = e.Name,
                            Id = e.Id,
                            Title = e.Title,
                            DateIn = e.DateIn,
                            DeptsName = e.DeptsName,
                            ManufName = e.ManufName,
                            PNumber = e.PNumber,
                            SNumber = e.SNumber,
                            Price = e.Price
                        };
                }
                return null;
            }
        }

        /// <summary>
        /// Filtering equipments method by Department name
        /// </summary>
        /// <param name="dept"></param>
        /// <returns>
        /// List of equipments
        /// </returns>
        public static List<EquipView> GetByDept(string dept)
        {
            using (EquipmentsEntities context = new EquipmentsEntities())
            {
                var listEquips = context.Equip.Join(context.Depts,
                    e => e.DeptsId, d => d.Id, (e, d) => new
                    {
                        Name = e.EuqipName,
                        DeptsName = d.DeptName,
                        Title = e.EuqipTitle,
                        e.ManufacturesId,
                        e.EquipPrice,
                        e.DateIn,
                        e.EquipSerialNumber,
                        e.EuqipPartNumber,
                        e.Id
                    }).Join(context.Manufactures, e => e.ManufacturesId, m => m.Id, (e, m) => new EquipView
                    {
                        Name = e.Name,
                        DeptsName = e.DeptsName,
                        Title = e.Title,
                        ManufName = m.ManufName,
                        Price = e.EquipPrice,
                        DateIn = e.DateIn,
                        PNumber = e.EuqipPartNumber,
                        SNumber = e.EquipSerialNumber,
                        Id = e.Id
                    }).ToList();

                List<EquipView> newListEq = new List<EquipView>();
                foreach (var e in listEquips)
                {
                    var str = e.DeptsName;
                    str = str.Replace(" ", "");
                    if (str == dept)
                    {
                        newListEq.Add(new EquipView
                        {
                            Name = e.Name,
                            Id = e.Id,
                            Title = e.Title,
                            DateIn = e.DateIn,
                            DeptsName = e.DeptsName,
                            ManufName = e.ManufName,
                            PNumber = e.PNumber,
                            SNumber = e.SNumber,
                            Price = e.Price
                        });
                    }
                }
                return newListEq;
            }
        }
    }
}