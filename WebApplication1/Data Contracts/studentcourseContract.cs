using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Data_Contracts
{
    public partial class studentcourseContract
    {
        public int ID { get; set; }
        public int studentID { get; set; }
        public int courseID { get; set; }

        public  virtual courseContract course { get; set; }
        public  virtual studentContract student { get; set; }
    }
}