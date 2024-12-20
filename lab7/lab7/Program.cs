using MyVector;
class Program
{
    static string path = "C:/Users/aha haha/source/repos/lab7/lab7/bin/Debug/net6.0/input.txt";
    static string path1 = "C:/Users/aha haha/source/repos/lab7/lab7/bin/Debug/net6.0/output.txt";
    static StreamReader input = new StreamReader(path);
    static StreamWriter output = new StreamWriter(path1);
    static MyVector<string> GetIp()
    {
        string line = input.ReadLine();
        string chekline = "";
        if (line == null) Console.WriteLine("Пустая строка");
        MyVector<string> ip = new MyVector<string>(0, 1);
        while (line != null)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if ((line[i] == '.') || char.IsDigit(line[i]))
                {
                    chekline += line[i];
                }
                else
                {
                    bool flagIp = true;
                    string[] arrline = chekline.Split('.');
                    if (arrline.Length == 4)
                    {
                        for (int j = 0; j < arrline.Length; j++)
                        {
                            try
                            {
                                int x = Convert.ToInt32(arrline[j]);
                                if (x > 255) flagIp = false;
                            }
                            catch { flagIp = false; }
                        }
                    }

                    else flagIp = false;
                    if (flagIp)
                    {7щ7
                        output.WriteLine(chekline);
                        ip.Add(chekline);
                        chekline = "";

                    }
                }

            }
            line = input.ReadLine();
        }

        return ip;
    }


    static void DeleteCopy(MyVector<string> ip)
    {
        for (int i = 0; i < ip.elementCount; i++)
        {
            for (int j = i + 1; j < ip.elementCount; j++)
            {
                if (ip.Element(i) == ip.Element(j)) ip.Remove(ip.Element(j));
            }
        }
    }
    static void IpToFile(MyVector<string> ip)
    {
        DeleteCopy(ip);
        for (int i = 0; i < ip.elementCount; i++)
        {
            string addres = ip.Get(i);
            output.WriteLine(addres);
        }
        output.Close();
    }
    static void Main(string[] args)
    {
        MyVector<string> ip = new MyVector<string>();
        ip = GetIp();
        IpToFile(ip);
    }
}