using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMatrix
{
    public class DynMatr<T>
    {
        public List<List<T>> lst = new List<List<T>>();
        private T returner =


        public DynMatr(int i, int j)
        {
            string type = typeof(T).Name;

            if (i < 1)
                i = 1;

            if (j < 1)
                j = 1;

            switch (type)
            {
                case "Int16":
                    Adder(i, j, 0);
                    break;
                case "Int32":
                    Adder(i, j, 0);
                    break;
                case "Int64":
                    Adder(i, j, 0);
                    break;
                case "UInt16":
                    Adder(i, j, 0);
                    break;
                case "UInt32":
                    Adder(i, j, 0);
                    break;
                case "UInt64":
                    Adder(i, j, 0);
                    break;
                case "Double":
                    Adder(i, j, 0);
                    break;
                case "Single":
                    Adder(i, j, 0);
                    break;
                case "Byte":
                    Adder(i, j, 0);
                    break;
                case "SByte":
                    Adder(i, j, 0);
                    break;
                case "String":
                    Adder(i, j, "");
                    break;
                case "Char":
                    Adder(i, j, '');
                    break;
                case "Decimal":
                    Adder(i, j, 0);
                    break;
                case "Boolean":
                    Adder(i, j, false);
                    break;
                default:
                    Adder(i, j, null);
                    break;
            }
            /*for (int row = 0; row < i; row++)
            {
                lst.Add(new List<T>());
                for (int col = 0; col < j; col++)
                    lst[row].Add();
                        
                }*/
            /*
            * Int32
            * Int16
            * Int64
            * UInt32
            * UInt16
            * UInt64
            * Double
            * Byte
            * SByte
            * String
            * Decimal
            * Boolean
            * Single
            * Char
            */    
        }


        public void Adder(int i, int j, object el)
        {
            for (int row = 0; row < i; row++)
            {
                lst.Add(new List<T>());
                for (int col = 0; col < j; col++)
                    lst[row].Add((T)el);

            }
        }


        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= CountRow)
                {
                    Console.WriteLine("Row index out of range");
                    return returner;
                }
                else
                    if (col < 0 || col >= CountColumn)
                {
                    Console.WriteLine("Column index out of range");
                    return returner;
                }
                else
                    return lst[row][col];
            }

            set
            {
                if (row < 0 || row >= CountRow)
                {
                    Console.WriteLine("Row index out of range");
                }
                else
                    if (col < 0 || col >= CountColumn)
                {
                    Console.WriteLine("Column index out of range");
                }
                else
                    lst[row][col] = value;
            }
        }


        public string this[int i, bool col = false]
        {
            get
            {
                if (!col)
                {
                    if (i < 0 || i >= CountRow)
                    {
                        Console.WriteLine("Index out of range");
                        return "-1";
                    }
                    else
                        return string.Join(" ", lst[i]);
                }
                else
                {
                    if (i < 0 || i >= CountColumn)
                    {
                        Console.WriteLine("Index out of range");
                        return "-1";
                    }
                    else
                    {
                        List<T> ret = new List<T>();

                        for (int row = 0; row < CountRow; row++)
                            ret.Add(lst[row][i]);

                        return string.Join(" ", ret);
                    }
                }
            }
            set
            { }
        }


        public void AddRow()
        {
            lst.Add(new List<T>());

            for (int col = 0; col < CountColumn; col++)
                lst[CountRow - 1].Add(0);
        }


        public void AddRow(params T[] arr)
        {
            lst.Add(new List<T>());

            if (arr.Length > CountColumn)
                for (int col = 0; col < lst[0].Count; col++)
                    lst[CountRow - 1].Add(arr[col]);
            else
            {
                for (int col = 0; col < arr.Length; col++)
                    lst[CountRow - 1][col] = arr[col];

                for (int col = arr.Length; col < lst[0].Count; col++)
                    lst[CountRow - 1][col] = 0;
            }
        }


        public void AddColumn()
        {
            for (int row = 0; row < CountRow; row++)
                lst[row].Add(0);
        }


        public void AddColumn(params T[] arr)
        {
            if (arr.Length > lst.Count)
                for (int row = 0; row < CountRow; row++)
                    lst[row].Add(arr[row]);
            else
            {
                for (int row = 0; row < arr.Length; row++)
                    lst[row].Add(arr[row]);

                for (int row = arr.Length; row < CountRow; row++)
                    lst[row].Add(0);
            }
        }


        public void Remove(int row, int col)
        {
            if (row < 0 || row >= CountRow)
            {
                Console.WriteLine("Index out of range");
            }
            else
                if (col < 0 || col >= CountColumn)
            {
                Console.WriteLine("Index out of range");
            }
            else
            {
                lst[row][col] = 0;
                Console.WriteLine("Element at ({0},{1}) became Zero", row, col);
            }
        }


        public void RemoveRow(int row)
        {
            if (row < 0 || row >= CountRow)
                Console.WriteLine("Index out of range");
            else
                lst.RemoveAt(row);
        }


        public void RemoveColumn(int col)
        {
            if (col < 0 || col >= CountColumn)
                Console.WriteLine("Index out of range");
            else
                for (int row = 0; row < CountRow; row++)
                    lst[row].RemoveAt(col);
        }


        public void Insert(T element)
        {
            lst[CountRow - 1][CountColumn - 1] = element;
            Console.WriteLine("Replaced \"{0}\" at the end of the last row", element);
        }


        public void Insert(T element, int i, bool col = false)
        {
            if (!col)
            {
                if (i < 0 || i >= CountRow)
                    Console.WriteLine("Index out of range");
                else
                {
                    lst[i][CountColumn - 1] = element;
                    Console.WriteLine("Replaced \"{0}\" at the end of the row \"{1}\"", element, i);
                }
            }
            else
            {
                if (i < 0 || i >= CountColumn)
                    Console.WriteLine("Index out of range");
                else
                {
                    lst[CountRow - 1][i] = element;
                    Console.WriteLine("Replaced \"{0}\" at the end of the column \"{1}\"", element, i);
                }
            }
        }


        public void Insert(T element, int row, int col)
        {
            if (row < 0 || row >= CountRow)
                Console.WriteLine("Row index out of range");
            else
                if (col < 0 || col >= CountColumn)
                Console.WriteLine("Column index out of range");
            else
            {
                lst[row][col] = element;
                Console.WriteLine("Replaced element at ({0},{1}) to \"{2}\"", row, col, element);
            }
        }


        public void Write()
        {
            for (int row = 0; row < CountRow; row++, Console.WriteLine())
                for (int col = 0; col < CountColumn; col++)
                    Console.Write("{0,3}", lst[row][col]);
        }


        public int CountRow
        {
            get
            {
                return lst.Count;
            }
        }


        public int CountColumn
        {
            get
            {
                return lst[0].Count;
            }
        }

        public int Count
        {
            get
            {
                return CountColumn * CountRow;
            }
        }
    }
}
