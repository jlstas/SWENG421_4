using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            XYZ company = new XYZ();
            List<Desk> dList = new List<Desk>();    //create new List of type Desk

            
            BubbleSort<Desk> bs = new BubbleSort<Desk>();
            QuickSort<Desk> qs = new QuickSort<Desk>();

            dList.Add(new Desk(20.30, 3, "High"));
            dList.Add(new Desk(15.25, 2, "Low"));
            dList.Add(new Desk(25.13, 4, "Executive"));
            dList.Add(new Desk(5.85, 1, "Student"));

            bs.sort(dList);
            foreach(Desk d in dList)
            {
                Console.WriteLine(d.getID() + " " + d.getName() + " $" + d.getPrice());
            }
            //qs.sort(dList);
            foreach(Desk d in dList)
            {
                Console.WriteLine("$" + d.getPrice() + " " + d.getName() + " " + d.getID());
            }

        }
    }
    class XYZ
    {
        private Utility<Desk> utd = new Utility<Desk>();
    }
    interface ProductIF
    {
        public double getPrice();
        public int getID();
        public string getName();
    }
    interface IComparable<T>
    {
        public int CompareTo(T generic)
        {
            return 0;
        }
    }
    public class Desk : IComparable<Desk>, ProductIF
    {
        private int iD;
        private string name;
        private double price;
        
        public Desk()
        {

        }
        public Desk(double price, int Id, string name)
        {
            this.iD = Id;
            this.name = name;
            this.price = price;
        }
        public int getID()
        {
            return this.iD;
        } 

        public string getName()
        {
            return this.name;
        }

        public double getPrice()
        {
            return this.price;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public void setPrice(double price)
        {
            this.price = price;
        }

        public int CompareTo(Desk comparePrice)
        {
            if (comparePrice == null)
                return 1;
            else
                return price.CompareTo(comparePrice.getPrice());
        }
    }
    public class Utility<T>
    {
        private string sortName;
        
        public Utility()
        {
            this.sortName = "bubblesort";
        }
        public Utility(string sortName)
        {
            this.sortName = sortName;
           
        }
        public List<T> sort(List<T> data)
        {                      
            return data;
        }
        public string getSortName()
        {
            return this.sortName;
        }
    }
    class BubbleSort<T> : Utility<T> where T : IComparable<T>
    {
        public BubbleSort()
        {

        }
        public List<T> Sort(List<T> data)
        {
            T temp;
            for (int i = data.Count; i > 1; i--)
            {
                for (int j = 1; j < data.Count; j++)
                {
                    if (data[j-1].CompareTo(data[j]) > 0)
                    {
                        temp = data[j];
                        data[j - 1] = data[j];
                        data[j] = temp;
                    }
                }
            }
            return data;
        }
    }
    public class QuickSort<T> : Utility<T>
    {
        public QuickSort()
        {

        }
        public List<T> Sort(List<T> data)
        {

            data.Sort();
            return data;
        }
    }
}
