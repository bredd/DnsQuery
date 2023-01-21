# DnsQuery
This is a C# Class to perform DNS lookups of TXT records. It would be easy to adapt to read other
record types such as MX, SRV, or PTR.

Distributed as a [CodeBit](http://www.filemeta.org/CodeBit) for easy incorporation into projects.

# License
Licensed under a BSD 3-clause license.

# Limitations and Opportunities
The DNS lookup is implemented through p/invoke to the Win32
[DnsQuery](https://learn.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsquery_w)
system call. Therefore, it only works only on Windows. So, while this code can be complied
for .Net Core or .Net Framework, it will only work when running on a Windows operating system.

A cross-platform .Net Core version would require implementing a DNS client rather than
relying on the operating system. A promising option would be to use DNS over Https (DoH)
thereby achieving greater security. Such an implementation would be limited to
DoH servers but there are several available such as
[CloudFlare DoH](https://developers.cloudflare.com/1.1.1.1/encryption/dns-over-https/make-api-requests),
[Google Public DNS](https://developers.google.com/speed/public-dns/docs/doh/), and
[Many Others](https://dnscrypt.info/public-servers/).
