using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace SLab
{
    public class record
    {
        internal int ID;
        internal string Note;
        internal static bool brake = false;
 
        public record(int ID, string Note)
        {
            this.ID = ID;
            this.Note = Note;
        }
    }
 
    public class Notebook
    {
        static bool brake = false;
        List<record> notebookRecords;
        List<record> NotebookRecords
        {
            get { return notebookRecords; }
            set { notebookRecords = value; }
        }
 
        public Notebook()
        {
            notebookRecords = new List<record>();
        }
 
        public List<record> SearchRecords(int ID)
        {
            Console.Write("Введите ID записи \n");
            ID = Convert.ToInt32(Console.ReadLine());
            List<record> ret = new List<record>();
            foreach (record rec in notebookRecords)
                if (rec.ID == ID)
                    ret.Add(rec);
            return ret;
        }
 
        public void printlist(List<record> ret)
        {
            foreach (record t in ret)
            {
                Console.WriteLine("note={0}", t.Note);
            }
        }

        public void AddRecord(int ID, string Note)
        {
            Console.Write("введите запись \n");
            Note = Convert.ToString(Console.ReadLine());
            record rec = new record(ID, Note);
            notebookRecords.Add(rec);
            Console.WriteLine("Note added! id={0},note={1}", ID, Note);
        }

        public void UpdateRecords(List<record> ret)
        {
            foreach (record t in ret)
            {
                    Console.Write("введите запись \n");
                    t.Note = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Note updated! id={0},note={1}", t.ID, t.Note);
            }
        }

        public void prit()
        {
            foreach (record c in notebookRecords)
            {
                Console.WriteLine("id={0},note={1}", c.ID, c.Note);
            }
        }
 
        public void DeleteRecords(int ID)
        {
            List<record> records = SearchRecords(ID);
            foreach (record rec in records)
                notebookRecords.Remove(rec);
                Console.WriteLine("Note deleted!");
        }
 
 
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            int ID = 1;  string Note = "";
            Notebook dt = new Notebook();
            do
            {
                Console.WriteLine("Введите комманду (create,update,delete,find,print,exit)");
                switch (Console.ReadLine())
                {
                    case "create": dt.AddRecord(ID, Note); ID++; break;
                    case "delete": dt.DeleteRecords(ID); break;
                    case "update": dt.UpdateRecords(dt.SearchRecords(ID)); break;
                    case "find": dt.printlist(dt.SearchRecords(ID)); break;
                    case "print": dt.prit(); break;
                    case "exit": record.brake = true; break;
                    default: Console.WriteLine("Ошибка ввода"); break;
                }
            } while (!record.brake);
 
 
        }
    }
}