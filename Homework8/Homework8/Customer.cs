﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    [Serializable]
    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            ID = Guid.NewGuid().ToString();
        }
        public Customer(string name) : this()
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    /*    public override bool Equals(object obj)
        {
            Customer m = obj as Customer;
            return m.Name == Name;
        }*/
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
