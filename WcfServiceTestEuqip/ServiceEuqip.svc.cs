using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceTestEuqip
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service1 : IServiceEuqip
    {
        public bool CreateEq(Equipment equipment)
        {
            return DAL.EquipRepository.Create(equipment);
        }

        public List<EquipView> GetAllEquip()
        {
            return DAL.EquipRepository.GetAll();
        }

        public bool RemoveEq(Equipment equipment)
        {
            return DAL.EquipRepository.Remove(equipment);
        }

        public bool UpdateEq(Equipment equipment)
        {
            return DAL.EquipRepository.Update(equipment);
        }

        EquipView IServiceEuqip.GetEquip(string id)
        {
            return DAL.EquipRepository.GetItem(id);
        }

        public List<EquipView> GetEquipsByDept(string dept)
        {
            return DAL.EquipRepository.GetByDept(dept);
        }

        public List<Depart> GetDeparts()
        {
            return DAL.DeptsRepository.GetAll();
        }

        public Depart GetDepart(string id)
        {
            return DAL.DeptsRepository.GetItem(id);
        }

        public bool CreateDept(Depart depart)
        {
            return DAL.DeptsRepository.Create(depart);
        }

        public bool UpdateDept(Depart deprt)
        {
            return DAL.DeptsRepository.Update(deprt);
        }

        public bool RemoveDept(Depart depart)
        {
            return DAL.DeptsRepository.Remove(depart);
        }

        public List<Manufact> GetManufacts()
        {
            return DAL.ManufRepository.GetAll();
        }

        public Manufact GetManufact(string id)
        {
            return DAL.ManufRepository.GetItem(id);
        }

        public bool CreateManuf(Manufact manufact)
        {
            return DAL.ManufRepository.Create(manufact);
        }

        public bool UpdateManuf(Manufact manufact)
        {
            return DAL.ManufRepository.Update(manufact);
        }

        public bool RemoveManuf(Manufact manufact)
        {
            return DAL.ManufRepository.Remove(manufact);
        }
    }
}
