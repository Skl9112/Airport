
using Airport;
using System;
using System.ComponentModel;

namespace Airport
{
    class Program
    {

        static string fileNameAviaZayavka = "aviaZayavka.txt";
        static string fileNameReis = "Reis.txt";
        static List<Reis> reis = new List<Reis>();
        static List<AviaZayavka> aviaZayavka = new List<AviaZayavka>();

        public static void returnProc()
        {
            Console.WriteLine("Ошибка ввода...");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");            
        }
        public static void saveToFileReis()
        {
            try
            {
                FileStream file = new FileStream(fileNameReis, FileMode.Create, FileAccess.Write);
                using (file)
                {
                    StreamWriter writer = new StreamWriter(file);
                    using (writer)
                    {
                        for (int i = 0; i < reis.Count; i++)
                        {
                            string str = reis[i].NOMERREISA.ToString() + "|" + reis[i].MESTO.ToString() + "|" + reis[i].TARIFF.ToString();
                            writer.WriteLine(str);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка записи данных в файл");
                Console.ReadKey();
            }
        }        
        public static void readToFileReis()
        {
            try
            {
                FileStream file = new FileStream(fileNameReis, FileMode.Open, FileAccess.Read);
                using (file)
                {
                    StreamReader reader = new StreamReader(file);
                    using (reader)
                    {
                        while (!reader.EndOfStream)
                        {
                            string strRead = reader.ReadLine();
                            string[] tempStrRead = strRead.Split('|');
                            Reis temp = new Reis(int.Parse(tempStrRead[0]), tempStrRead[1], double.Parse(tempStrRead[2]));
                            reis.Add(temp);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка чтения данных с файла");
                Console.ReadKey();
            }
        }
        public static void printReisTop()
        {
            Console.WriteLine("+-----+-------------------------------------+----------------------+---------------------+");
            Console.WriteLine("|  №  |             Номер рейса             |    Местоназначение   |        Тариф        |");
            Console.WriteLine("+-----+-------------------------------------+----------------------+---------------------+");
        }
        public static void printReisBot()
        {
            Console.WriteLine("+-----+-------------------------------------+----------------------+---------------------+");
        }
        public static void printMidReis(int k)
        {
            Console.WriteLine($"|{k,-5}|{reis[k - 1].NOMERREISA,-37}|{reis[k - 1].MESTO,-22}|{reis[k - 1].TARIFF,-21}|");
        }
        public static void printReis()
        {
            printReisTop();
            for (int i = 0; i < reis.Count(); i++)
            {
                printReisBot();
                printMidReis(i + 1);
            }
            printReisBot();
        }
        public static void createReis()
        {
            int nomerReisa;
            string mesto;
            double tariff;
            Console.WriteLine("Введите номер рейса: ");
            try
            {
                nomerReisa = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Неверный ввод");
                nomerReisa = 0;
            }
            Console.WriteLine("Введите местоназначение: ");
            try
            {
                mesto = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Неверный ввод");
                mesto = "";
            }
            Console.WriteLine("Введите тариф: ");
            try
            {
                tariff = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Неверный ввод");
                tariff = 0;
            }
            Reis temp = new Reis(nomerReisa, mesto, tariff);
            reis.Add(temp);
            saveToFileReis();
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        public static void editReis()
        {
            int nomerReisa;
            string mesto;
            double tariff;
            int k = 0;
            try
            {
                Console.WriteLine("Введите номер записи для редактирования: ");
                k = Convert.ToInt32(Console.ReadLine());
                if (k > reis.Count || k < 1) throw new SystemException();
            }
            catch
            {
                returnProc(); return;                
            }
            k--;
            Console.WriteLine("Введите номер поля для редактирования:\n 1 - Номер рейса\n 2 - Местоназначение\n 3 - Тариф");
            int f = 0;
            try
            {
                f = Convert.ToInt32(Console.ReadLine());
                if (f > 3 || f < 1) throw new SystemException();
            }
            catch
            {
                returnProc(); return;
            }
            switch (f)
            {
                case 1:
                    Console.WriteLine("Введите номер рейса: ");
                    try
                    {
                        int r = Convert.ToInt32(Console.ReadLine());
                        reis[k].NOMERREISA = r;
                    }
                    catch
                    {
                        returnProc(); return;
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите местоназначение: ");
                    try
                    {
                        string r = Console.ReadLine();
                        reis[k].MESTO = r;
                    }
                    catch
                    {
                        returnProc(); return;
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите тариф: ");
                    try
                    {
                        double r = Convert.ToDouble(Console.ReadLine());
                        reis[k].TARIFF = r;
                    }
                    catch
                    {
                        returnProc(); return;
                    }
                    break;
            }
            saveToFileReis();
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        public static void deleteReis()
        {
            Console.WriteLine("Введите номер удаляемого элемента: ");
            int deleteEdit = 0;
            try
            {
                deleteEdit = Convert.ToInt32(Console.ReadLine());
                if ((deleteEdit<1)|| (deleteEdit>reis.Count)) throw new SystemException();
            }
            catch
            {
                returnProc(); return;
            }
            deleteEdit--;
            reis.RemoveAt(deleteEdit);
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        public static void saveToFileAviaZayavka()
        {
            try
            {
                FileStream file = new FileStream(fileNameAviaZayavka, FileMode.Create, FileAccess.Write);
                using (file)
                {
                    StreamWriter writer = new StreamWriter(file); 
                    using (writer)
                    {
                        for (int i = 0; i < aviaZayavka.Count; i++)
                        {
                            string str = aviaZayavka[i].FAMIO;
                            str += "|";
                            str += aviaZayavka[i].PASSPORT;
                            str += "|";
                            str += aviaZayavka[i].COUNT.ToString();
                            int[] temp = aviaZayavka[i].NOMREISA;
                            for (int j = 0; j < aviaZayavka[i].COUNT; j++)
                            {
                                str += "|" + temp[j].ToString();
                            }
                            int[] temp2 = aviaZayavka[i].COUNTTICKET;
                            for (int j = 0; j < aviaZayavka[i].COUNT; j++)
                            {
                                str += "|" + temp2[j].ToString();
                            }
                            bool[] temp3 = aviaZayavka[i].EXEMPTION;
                            for (int j = 0; j < aviaZayavka[i].COUNT; j++)
                            {
                                str += "|" + temp3[j].ToString();
                            }
                            writer.WriteLine(str);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка записи данных в файл");
                Console.ReadKey();
            }
        }
        public static void readToFileAviaZayavka()
        {
            try
            {
                FileStream file = new FileStream(fileNameAviaZayavka, FileMode.Open, FileAccess.Read);
                using (file)
                {
                    StreamReader reader = new StreamReader(file);
                    using (reader)
                    {
                        while (!reader.EndOfStream)
                        {
                            string strRead = reader.ReadLine();
                            string[] tempStrRead = strRead.Split('|');
                            int count = int.Parse(tempStrRead[2]);
                            int[] nomReisa = new int[count];
                            for (int i = 0; i < count; i++)
                            {
                                nomReisa[i] = int.Parse(tempStrRead[3 + i]);
                            }
                            int[] countTicket = new int[count];
                            for (int i = 0; i < count; i++)
                            {
                                countTicket[i] = int.Parse(tempStrRead[3 + count + i]);
                            }
                            bool[] exemption = new bool[count];
                            for (int i = 0; i < count; i++)
                            {
                                exemption[i] = bool.Parse(tempStrRead[3 + 2 * count + i]);
                            }
                            AviaZayavka temp = new AviaZayavka(tempStrRead[0], tempStrRead[1], count, nomReisa, countTicket, exemption);
                            aviaZayavka.Add(temp);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка чтения данных с файла");
                Console.ReadKey();
            }
        }
        public static void printAviaZayavkaTop()
        {
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
            Console.WriteLine("|  №  |                 ФИО                 |    Паспортные данные   |  Номер рейса  | Количество билетов | Льгота |");
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
        }
        public static void printAviaZayavkaBot()
        {
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
        }
        public static void printMidAviaZayavka(int k)
        {
            string tempStr = "";
            Console.WriteLine($"|{k,-5}|{aviaZayavka[k - 1].FAMIO,-37}|{aviaZayavka[k - 1].PASSPORT,-25}|{tempStr,-15}|{tempStr,-20}|{tempStr,-8}|");
            int[] temp1 = aviaZayavka[k - 1].NOMREISA;
            int[] temp2 = aviaZayavka[k - 1].COUNTTICKET;
            bool[] temp3 = aviaZayavka[k - 1].EXEMPTION;
            for (int i = 0; i < aviaZayavka[k - 1].COUNT;i++)
                Console.WriteLine($"|{tempStr,-5}|{tempStr,-37}|{tempStr,-25}|{temp1[i].ToString(),-15}|{temp2[i].ToString(),-20}|{temp3[i].ToString(),-8}|");
        }
        public static void printAviaZayavka()
        {
            printAviaZayavkaTop();
            for (int i = 0; i < aviaZayavka.Count(); i++)
            {
                printAviaZayavkaBot();
                printMidAviaZayavka(i + 1);
            }
            printAviaZayavkaBot();            
        }
        public static void editAviaZayavka()
        {
            string famIO;
            string passport;
            int count;
            Console.WriteLine("Введите номер записи для редактирования: ");
            int k = 0;
            try
            {
                k = Convert.ToInt32(Console.ReadLine());
                if ((k < 1) || (k > aviaZayavka.Count)) throw new SystemException();
            }
            catch
            {
                returnProc(); return;
            }            
            k--;
            Console.WriteLine("Введите номер поля для редактирования:\n 1 - ФИО\n 2 - Пасспортные данные\n 3 - Количество\n 4 - Набор билетов");
            int f = 0;            
            try
            {
                f = Convert.ToInt32(Console.ReadLine());
                if ((f < 1) || (f > 4)) throw new SystemException();
            }
            catch
            {
                returnProc(); return;
            }
            switch (f)
            {
                case 1:
                    Console.WriteLine("ФИО покупателя: ");
                    try
                    {
                        famIO = Console.ReadLine();
                        aviaZayavka[k].FAMIO = famIO;
                    }
                    catch
                    {
                        returnProc(); return;
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите паспортные данные: ");
                    try
                    {
                        passport = Console.ReadLine();
                        aviaZayavka[k].PASSPORT = passport;
                    }
                    catch
                    {
                        returnProc(); return;
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите количество различных комплектов билетов: ");
                    try
                    {
                        count = Convert.ToInt32(Console.ReadLine());
                        if (count > aviaZayavka[k].COUNT)
                        {                            
                            int[] nomReisaNew = new int[count];
                            int[] countTicketNew = new int[count];
                            bool[] exemptionNew = new bool[count];

                            int[] nomReisaOld = aviaZayavka[k].NOMREISA;
                            int[] countTicketOld = aviaZayavka[k].COUNTTICKET;
                            bool[] exemptionOld = aviaZayavka[k].EXEMPTION;
                            for (int i=0; i< aviaZayavka[k].COUNT; i++)
                            {
                                nomReisaNew[i] = nomReisaOld[i];
                                countTicketNew[i] = countTicketOld[i];
                                exemptionNew[i] = exemptionOld[i];
                            }
                            for (int i = aviaZayavka[k].COUNT; i < count; i++)
                            {
                                nomReisaNew[i] = 0;
                                countTicketNew[i] = 0;
                                exemptionNew[i] = false;
                            }                            
                            aviaZayavka[k].NOMREISA = nomReisaNew;
                            aviaZayavka[k].COUNTTICKET = countTicketNew;
                            aviaZayavka[k].EXEMPTION = exemptionNew;
                        }
                        aviaZayavka[k].COUNT = count;
                    }
                    catch
                    {
                        returnProc(); return;
                    }
                    break;
                case 4:
                    int[] nomReisa = aviaZayavka[k].NOMREISA;
                    int[] countTicket = aviaZayavka[k].COUNTTICKET;
                    bool[] exemption = aviaZayavka[k].EXEMPTION;
                    Console.WriteLine("+-----+---------------+--------------------+--------+");
                    Console.WriteLine("|  №  |  Номер рейса  | Количество билетов | Льгота |");
                    Console.WriteLine("+-----+---------------+--------------------+--------+");                    
                    for (int i = 0; i < aviaZayavka[k].COUNT; i++)
                        Console.WriteLine($"|{i+1,-5}|{nomReisa[i].ToString(),-15}|{countTicket[i].ToString(),-20}|{exemption[i].ToString(),-8}|");
                    Console.WriteLine("+-----+---------------+--------------------+--------+");
                    Console.WriteLine("Введите номер строки для редактирования: ");
                    int d =0;
                    try
                    {
                        d = Convert.ToInt32(Console.ReadLine());
                        if ((d < 1) || (d > aviaZayavka[k].COUNT)) throw new SystemException();
                    }
                    catch
                    {
                        returnProc(); return;
                    }
                    Console.WriteLine("Введите поле для редактирования:\n 1 - Номер рейса\n 2 - Количество билетов\n 3 - Льгота");
                    int t = 0;
                    try
                    {
                        t = Convert.ToInt32(Console.ReadLine());
                        if ((t < 1) || (t > 3)) throw new SystemException();
                    }
                    catch
                    {
                        returnProc(); return;
                    }
                    switch(t)
                    {
                        case 1: 
                            printReis();
                            Console.WriteLine("Введите номер рейса: ");
                            try
                            {
                                int p = Convert.ToInt32(Console.ReadLine());
                                nomReisa[d - 1] = p;
                                aviaZayavka[k].NOMREISA = nomReisa;
                            }
                            catch
                            {
                                returnProc(); return;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Введите количество билетов: ");
                            try
                            {
                                int p = Convert.ToInt32(Console.ReadLine());
                                if (p < 1)  throw new SystemException();
                                countTicket[d - 1] = p;
                                aviaZayavka[k].COUNTTICKET = countTicket;
                            }
                            catch
                            {
                                returnProc(); return;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Билеты по льготе? (1 - да, 0 - Нет): ");
                            try
                            {

                                int tempExemption = Convert.ToInt32(Console.ReadLine());
                                if ((tempExemption < 0)||(tempExemption >1)) throw new SystemException();
                                if (tempExemption == 1)
                                    exemption[d-1] = true;
                                else exemption[d - 1] = false;
                                aviaZayavka[k].EXEMPTION = exemption;
                            }
                            catch
                            {
                                returnProc(); return;
                            }
                            break;
                    }
                    break;                    
            }            
            saveToFileAviaZayavka();
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        public static void createAviaZayavka()
        {
            string famIO;
            string passport;
            int count;
            Console.WriteLine("ФИО покупателя: ");
            try
            {
                famIO = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Неверный ввод");
                famIO = "";
            }
            Console.WriteLine("Введите паспортные данные: ");
            try
            {
                passport = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Неверный ввод");
                passport = "";
            }
            Console.WriteLine("Введите количество различных комплектов билетов: ");
            try
            {
                count = Convert.ToInt32(Console.ReadLine());
                if (count < 0) throw new SystemException();
            }
            catch
            {
                Console.WriteLine("Неверный ввод");
                count = 0;
            }
            int[] nomReisa = new int[count];
            int[] countTicket = new int[count];
            bool[] exemption = new bool[count];
            for (int i = 0; i < count; i++)
            {
                printReis();
                Console.WriteLine("Введите номер рейса: ");
                try
                {
                    nomReisa[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверный ввод");
                    nomReisa[i] = 0;
                }
                Console.WriteLine("Введите количество билетов: ");
                try
                {
                    countTicket[i] = Convert.ToInt32(Console.ReadLine());
                    if (countTicket[i]<0) throw new SystemException();
                }
                catch
                {
                    Console.WriteLine("Неверный ввод");
                    countTicket[i] = 0;
                }
                Console.WriteLine("Билеты по льготе? (1 - да, 0 - Нет): ");
                try
                {

                    int tempExemption = Convert.ToInt32(Console.ReadLine());
                    if ((tempExemption < 0) || (tempExemption > 1)) throw new SystemException();
                    if (tempExemption == 1)
                        exemption[i] = true;
                    else exemption[i] = false;
                }
                catch
                {
                    Console.WriteLine("Неверный ввод");
                    exemption[i] = false;
                }
            }
            AviaZayavka temp = new AviaZayavka(famIO, passport, count, nomReisa, countTicket, exemption);
            aviaZayavka.Add(temp);
            saveToFileAviaZayavka();
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        public static void deleteAviaZayavka()
        {
            Console.WriteLine("Введите номер удаляемого записи: ");
            int deleteEdit = Convert.ToInt32(Console.ReadLine());
            deleteEdit--;
            aviaZayavka.RemoveAt(deleteEdit);
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        public static void printAviaZayavkaTopReport()
        {
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
            Console.WriteLine("|  №  |                 ФИО                 |    Паспортные данные   |      Тариф    | Количество билетов | Льгота |");
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
        }
        public static void printMidAviaZayavkaReport(int numb, int k)
        {
            string tempStr = "";
            Console.WriteLine($"|{numb,-5}|{aviaZayavka[k - 1].FAMIO,-37}|{aviaZayavka[k - 1].PASSPORT,-25}|{tempStr,-15}|{tempStr,-20}|{tempStr,-8}|");
            int[] temp1 = aviaZayavka[k - 1].NOMREISA;
            int[] temp2 = aviaZayavka[k - 1].COUNTTICKET;
            bool[] temp3 = aviaZayavka[k - 1].EXEMPTION;
            for (int i = 0; i < aviaZayavka[k - 1].COUNT; i++)
            {
                double tariff = 0;
                for (int j = 0; j < reis.Count; j++)
                {
                    if (reis[j].NOMERREISA == temp1[i]) { tariff = reis[j].getExemption(temp3[i]); break; }
                }
                Console.WriteLine($"|{tempStr,-5}|{tempStr,-37}|{tempStr,-25}|{tariff.ToString(),-15}|{temp2[i].ToString(),-20}|{temp3[i].ToString(),-8}|");
            }
        }
        public static void printAviaZayavkaReport1()
        {
            printAviaZayavkaTopReport();
            for (int i = 0; i < aviaZayavka.Count(); i++)
            {
                printAviaZayavkaBot();
                printMidAviaZayavkaReport(i+1, i + 1);
            }
            printAviaZayavkaBot();

        }
        public static void printAviaZayavkaReport23(string temp)
        {
            printAviaZayavkaTopReport();
            int k = 0;
            for (int i = 0; i < aviaZayavka.Count(); i++)
            {
                if ((aviaZayavka[i].FAMIO == temp) || (aviaZayavka[i].PASSPORT == temp))
                {
                    printAviaZayavkaBot();
                    k++;
                    printMidAviaZayavkaReport(k,i+1);
                }
            }
            printAviaZayavkaBot();

        }
        public static void report1()
        {
            double sum = 0;
            for (int i=0; i<aviaZayavka.Count; i++)
            {
                int[] temp1 = aviaZayavka[i].NOMREISA;
                int[] temp2 = aviaZayavka[i].COUNTTICKET;
                bool[] temp3 = aviaZayavka[i].EXEMPTION;
                for (int k = 0; k < aviaZayavka[i].COUNT; k++)
                {
                    double tariff = 0;
                    for (int j = 0; j < reis.Count; j++)
                    {
                        if (reis[j].NOMERREISA == temp1[k]) { tariff = reis[j].getExemption(temp3[k]); break;}
                    }
                    sum += temp2[k] * tariff;
                }
            }
            printAviaZayavkaReport1();
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
            Console.WriteLine($"|                                                                                                    ИТОГО |{sum,-8 }|");
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        public static void report2()
        {
            Console.WriteLine("Введите ФИО");
            string famIO;
            famIO = Console.ReadLine();
            double sum = 0;
            for (int i = 0; i < aviaZayavka.Count; i++)
            {
                if (aviaZayavka[i].FAMIO == famIO)
                {
                    int[] temp1 = aviaZayavka[i].NOMREISA;
                    int[] temp2 = aviaZayavka[i].COUNTTICKET;
                    bool[] temp3 = aviaZayavka[i].EXEMPTION;
                    for (int k = 0; k < aviaZayavka[i].COUNT; k++)
                    {
                        double tariff = 0;
                        for (int j = 0; j < reis.Count; j++)
                        {
                            if (reis[j].NOMERREISA == temp1[k]) { tariff = reis[j].getExemption(temp3[k]); break; }
                        }
                        sum += temp2[k] * tariff;
                    }
                }
            }
            printAviaZayavkaReport23(famIO);
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
            Console.WriteLine($"|                                                                                                    ИТОГО |{sum,-8}|");
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        public static void report3()
        {
            Console.WriteLine("Введите паспортные данные");
            string passport;
            passport = Console.ReadLine();
            double sum = 0;
            for (int i = 0; i < aviaZayavka.Count; i++)
            {
                if (aviaZayavka[i].PASSPORT == passport)
                {                    
                        int[] temp1 = aviaZayavka[i].NOMREISA;
                        int[] temp2 = aviaZayavka[i].COUNTTICKET;
                        bool[] temp3 = aviaZayavka[i].EXEMPTION;
                        for (int k = 0; k < aviaZayavka[i].COUNT; k++)
                        {

                            double tariff = 0;
                            for (int j = 0; j < reis.Count; j++)
                            {
                                if (reis[j].NOMERREISA == temp1[k]) { tariff = reis[j].getExemption(temp3[k]); break; }
                            }
                            sum += temp2[k] * tariff;
                        }                   
                }
            }
            printAviaZayavkaReport23(passport);
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
            Console.WriteLine($"|                                                                                                    ИТОГО |{sum,-8}|");
            Console.WriteLine("+-----+-------------------------------------+-------------------------+---------------+--------------------+--------+");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
        }
        static void menu()
        {
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|                              Меню                           |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|                              Рейсы                          |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|  1 - Вывести рейсы                                          |");
            Console.WriteLine("|  2 - Добавить рейс                                          |");
            Console.WriteLine("|  3 - Удалить рейс                                           |");
            Console.WriteLine("|  4 - Редактировать рейс                                     |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|                              Билеты                         |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|  5 - Вывести купленные билеты                               |");
            Console.WriteLine("|  6 - Купить билеты                                          |");
            Console.WriteLine("|  7 - Удалить купленные билеты                               |");
            Console.WriteLine("|  8 - Редактировать купленные билеты                         |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|                              Отчеты                         |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|  9 - Рассчитывать стоимость всех проданных билетов          |");
            Console.WriteLine("| 10 - Рассчитать стоимость билетов по фамилии               |");
            Console.WriteLine("| 11 - Рассчитать стоиомость билетов по паспортным данным    |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("| 12 - Выход                                                  |");
            Console.WriteLine("+-------------------------------------------------------------+");
        }
        static void Main(string[] args)
        {
            readToFileReis();
            readToFileAviaZayavka();
            while (true)
            {
                int d = 0;
                Console.Clear();
                menu();
                Console.WriteLine("Введите пункт меню: ");
                try
                {
                    d = Convert.ToInt32(Console.ReadLine());
                    if (d > 12 || d < 1) throw new SystemException();
                }
                catch
                {
                    Console.WriteLine("Неверный ввод");
                    Console.ReadKey();
                    continue;
                }
                switch (d)
                {
                    case 1:
                        Console.Clear();
                        printReis();
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        createReis();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        printReis();
                        deleteReis();
                        saveToFileReis();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        printReis();
                        editReis();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        printAviaZayavka();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        createAviaZayavka();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        printAviaZayavka();
                        deleteAviaZayavka();
                        saveToFileAviaZayavka();
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        printAviaZayavka();
                        editAviaZayavka();
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.Clear();
                        report1();
                        Console.ReadKey();
                        break;
                    case 10:
                        Console.Clear();
                        report2();
                        Console.ReadKey();
                        break;
                    case 11:
                        Console.Clear();
                        report3();
                        Console.ReadKey();
                        break;
                    case 12:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Введено неверно");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}