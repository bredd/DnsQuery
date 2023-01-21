
Console.WriteLine(IntPtr.Size.ToString());
var list = Bredd.WinDnsQuery.GetTxtRecords("_dir.bredd.tech");
if (list == null)
{
    Console.WriteLine("Not Found");
}
else
{
    foreach (var str in list)
    {
        Console.WriteLine(str);
    }
}
