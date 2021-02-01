/*Разработать класс «Счет для оплаты». В классе предусмотреть следующие поля:
    ■ оплата за день;
    ■ количество дней;
    ■ штраф за один день задержки оплаты;
    ■ количество дней задержи оплаты;
    ■ сумма к оплате без штрафа (вычисляемое поле);
    ■ штраф (вычисляемое поле);
    ■ общая сумма к оплате (вычисляемое поле).
В классе объявить статическое свойство типа bool,
значение которого влияет на процесс форматирования
объектов этого класса. Если значение этого свойства равно true, тогда сериализуются и десериализируются все
    поля, если false — вычисляемые поля не сериализуются.
    Разработать приложение, в котором необходимо продемонстрировать использование этого класса, результаты
должны записываться и считываться из файла.*/

using System;
using System.Collections.Generic;
using System.IO;

namespace Serialization1
{
    class Bill
    {
        public decimal PaymentPerDay;      
        public uint Days;                  
        public decimal FinePerDay;         
        public uint DaysDelayedPayment;    
 
        public decimal TotalScore => PaymentPerDay * Days;          
        public decimal TotalFine => FinePerDay * DaysDelayedPayment;
        public decimal ResultPayment => TotalScore + TotalFine;     
 
        public static bool SerializeComputableFields = false;
        
        
        public void Serialize(BinaryWriter bw)
        {
            var version = SerializeComputableFields ? 1 : 0;
            bw.Write(version);
 
            bw.Write(PaymentPerDay);
            bw.Write(Days);
            bw.Write(FinePerDay);
            bw.Write(DaysDelayedPayment);
 
            if (SerializeComputableFields)
            {
                bw.Write(TotalScore);
                bw.Write(TotalFine);
                bw.Write(ResultPayment);
            }
        }
 
        public static Bill Deserialize(BinaryReader br)
        {
            var res = new Bill();
 
            var version = br.ReadInt32();
 
            res.PaymentPerDay = br.ReadDecimal();
            res.Days = br.ReadUInt32();
            res.FinePerDay = br.ReadDecimal();
            res.DaysDelayedPayment = br.ReadUInt32();
 
            if (version == 1)
            {
                br.ReadDecimal();
                br.ReadDecimal();
                br.ReadDecimal();
            }
            return res;
        }
    }
    
    class Bills : List<Bill>
    {
        public void Serialize(BinaryWriter bw)
        {
            var version = 0;
            bw.Write(version);
 
            bw.Write(Count);
            foreach (var bill in this)
                bill.Serialize(bw);
        }
 
        public static Bills Deserialize(BinaryReader br)
        {
            var res = new Bills();
 
            var version = br.ReadInt32();
 
            var count = br.ReadInt32();
            for (int i = 0; i < count; i++)
                res.Add(Bill.Deserialize(br));
 
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var bill = new Bill {PaymentPerDay = 100, Days = 50, FinePerDay = 20, DaysDelayedPayment = 10};
 
            
            Bill.SerializeComputableFields = false;
            Save(bill, "testSerialization1.bill");
 
           
            Bill.SerializeComputableFields = true;
            Save(bill, "temp2.bill");
 
            
            bill = LoadBill("temp2.bill");
 
            
            var bills = new Bills();
            bills.Add(bill);
            bills.Add(bill);
            bills.Add(bill);
 
          
            Save(bills, "temp1.bills");

            bills = LoadBills("temp1.bills");
            
        }
 
        static void Save(Bill bill, string fileName)
        {
            using (var file = File.Create(fileName))
            using (var bw = new BinaryWriter(file))
                bill.Serialize(bw);
        }
 
        static Bill LoadBill(string fileName)
        {
            using (var file = File.OpenRead(fileName))
            using (var br = new BinaryReader(file))
                return Bill.Deserialize(br);
        }
 
        static void Save(Bills bills, string fileName)
        {
            using (var file = File.Create(fileName))
            using (var bw = new BinaryWriter(file))
                bills.Serialize(bw);
        }
 
        static Bills LoadBills(string fileName)
        {
            using (var file = File.OpenRead(fileName))
            using (var br = new BinaryReader(file))
                return Bills.Deserialize(br);
        }
    }
}