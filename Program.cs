void ReportDnsTxt(string domainName)
{
    Console.WriteLine($"Reading TXT or {domainName}:");
    var list = Bredd.WinDnsQuery.GetTxtRecords(domainName);
    if (list == null)
    {
        Console.WriteLine("  Not Found");
    }
    else
    {
        Console.WriteLine($"  {list.Length} values.");
        foreach (var str in list)
        {
            Console.WriteLine($"  {str}");
        }
    }
}

ReportDnsTxt("_dir.bredd.tech");
ReportDnsTxt("_dnsquerytest.dicax.org");
ReportDnsTxt("_notpresent.dicax.org");