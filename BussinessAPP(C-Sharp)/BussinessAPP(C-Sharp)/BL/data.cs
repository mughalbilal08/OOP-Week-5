﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAPP_C_Sharp_.BL
{
    class data
    {
       
        
        public string names;
        public string passwords;
        public string roles;
        public string reviews;
        public int months;
        public int dates;
        public string fines;
        public string bookBorrow;
        public bool bookWidraw;
        public string userComplaints;
        public bool complaintCheck;
        public bool reviewCheck;
        public bool registeredStudents(List<data> d)
        {
            bool isCheck = false;
            for (int i = 1; i < d.Count; i++)
            {
                if (d[i].names != " " && d[i].passwords != " ")
                {
                    isCheck = true;
                }
            }
            return isCheck;
        }
        
    }
}

