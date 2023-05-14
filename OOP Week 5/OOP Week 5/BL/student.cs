using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Week_5.BL
{
    class student
    {
        public string sname;
        public string RollNo;
        public float cpga;
        public float mmarks;
        public float fmarks;
        public float emarks;
        public string hometown;
        public string ishostelide;
        public bool scholarship;
        public float merit;
        public void viewdata(List<student> obj)
        {
            foreach (student stu in obj)
            {
                Console.WriteLine("Student Name : "+ stu.sname);
                Console.WriteLine("Student Roll No :  "+ stu.RollNo);
                Console.WriteLine("Student CGPA : "+ stu.cpga);
                Console.WriteLine("Student matric marks:  "+ stu.mmarks);
                Console.WriteLine("Student fsc marks :  " + stu.fmarks);
                Console.WriteLine("Student Ecat Marks : " + stu.emarks);
                Console.WriteLine("Student address :  " + stu.hometown);
                Console.WriteLine("Student status :  "+ stu.ishostelide);
            }
        }
        public  float fscpercentage()
        {
            Console.Write("Enter the percentage of fsc marks you want to include : ");
            float per = float.Parse(Console.ReadLine());
            return per;
        }
        public float ecatpercentage()
        {
            Console.Write("Enter the percentage of Ecat marks you want to include : ");
            float per1 = float.Parse(Console.ReadLine());
            return per1;
        }
        public void meritcalculator()
        {
            
            float result = 0F;
            float result1 = 0F;
            while (result + result1 < 100)
            {
                result = fscpercentage();
                result1 = ecatpercentage();
            }
            merit = (fmarks * (result / 1100)) + (emarks * (result1 / 400));
        }
        public void isScholarship()
        {
            scholarship = false;
            if (merit > 80 && ishostelide == "H")
            {
                 scholarship = true;
            }
        }
    }
}
