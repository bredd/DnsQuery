/* Unit tests for DnsQuery.cs
 * 
 * These tests are sensitive to the appropriate TXT records existing on
 * the domains _dir.bredd.tech, _dir.filemeta.tech, and _dnsquerytest.dicax.org.
 * If those change, the tests will fail even though the code is still
 * functioning.
 */

using Bredd;

int testFailures = 0;

bool TestDnsTxt(string domainName, IEnumerable<string> expected)
{
    Console.WriteLine($"Testing TXT record for domain '{domainName}':");
    var listFound = WinDnsQuery.GetTxtRecords(domainName);
    if (listFound == null)
    {
        Console.WriteLine("  Failed to find TXT record.");
        ++testFailures;
        return false;
    }

    int failures = 0;
    var listExpected = new List<string>(expected);
    foreach (var str in listFound)
    {
        int index = listExpected.IndexOf(str);
        if (index < 0)
        {
            Console.WriteLine($"  Error: Value '{str}' is unexpected.");
            ++failures;
        }
        else
        {
            Console.WriteLine($"  {str}");
            listExpected.RemoveAt(index);
        }
    }

    foreach(var str in listExpected)
    {
        Console.WriteLine($"  Error: Expected value '{str}' not found.");
        ++failures;
    }

    testFailures += failures;
    return failures == 0;
}

bool TestDnsTxtNotFound(string domainName)
{
    Console.WriteLine($"Testing TXT record for domain '{domainName}':");
    var listFound = WinDnsQuery.GetTxtRecords(domainName);
    if (listFound != null && listFound.Length > 0)
    {
        Console.WriteLine($"  Found value '{listFound[0]}' when expected no record to be found.");
        ++testFailures;
        return false;
    }
    Console.WriteLine($" As expected, no value found.");
    return true;
}

TestDnsTxt("_dir.bredd.tech", new string[] { "dir=https://brandtredd.org/directory.json" });
TestDnsTxt("_dnsquerytest.dicax.org", new string[]
{
    "https://ofthat.com",
    "https://edmatrix.org",
    "https://brandtredd.org"
});
TestDnsTxt("_dir.filemeta.org", new string[] { "dir=https://www.filemeta.org/directory.json" });
TestDnsTxtNotFound("_notpresent.dicax.org");

if (testFailures == 0)
{
    Console.WriteLine("All tests succeeded.");
}
else
{
    Console.WriteLine($"{testFailures} tests failed.");
}
