﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl
{
    public class RentalBL
    {
        public static bool AddRental(RentalDTO rd)
        {
            Rental r = RentalDTO.ToDal(rd);
           return RentalDAL.AddRental(r);

        }
        public static bool UpdateRental(RentalDTO rd)
        {
            using(ArgamanExpressEntities db=new ArgamanExpressEntities())
            {
                Rental r = db.Rentals.Find(rd.RentalID);
                r.PropertyID = rd.PropertyID;
                r.SubPropertyID = rd.SubPropertyID;
                r.UserID = rd.UserID;
                r.RentPayment = rd.RentPayment;
                r.PaymentTypeID = rd.PaymentTypeID;
                r.EnteryDate = rd.EnteryDate;
                r.EndDate = rd.EndDate;
                r.ContactRenew = rd.ContactRenew;
                return true;
            }
            return false;
        }
        public static List<RentalDTO> ConvertListToDTO(List<Rental> rentals)
        {
            using (ArgamanExpressEntities db = new ArgamanExpressEntities())
            {
                List<RentalDTO> redto = new List<RentalDTO>();
                foreach (Rental r in rentals)
                    redto.Add(new RentalDTO(r));
                return redto;
            }
            return null;
        }
        public static List<RentalDTO> Search(Nullable<int> propertyID, String user, Nullable<DateTime> enteryDate, Nullable<DateTime> endDate)
        {

            List<Rental> rentals = RentalDAL.Search(propertyID, user, enteryDate, endDate);
            return ConvertListToDTO(rentals);
        }
        public static List<RentalDTO> GetAllRentals()
        {
            using (ArgamanExpressEntities db = new ArgamanExpressEntities())
            {
                List<Rental> pro = db.Rentals.ToList();
                return ConvertListToDTO(pro);
            }
        }
        public static void Addtask2()
        {
            TaskDTO t; /*= new TaskDTO();*/
            List<RentalDTO> pro= GetAllRentals();
            int x = pro.Count;
            int i = 0;
            while (i != x) { 
                //!!!!!!!!!!!!!
            if((pro[i].EndDate).Value== DateTime.Today.AddMonths(3))//להוריד שלושה חודשים לא הצלחתי
                {
                    t = new TaskDTO();
                    TaskBL.AddTask(t);
                   
                }


                i++;
}
            }
        }
}
