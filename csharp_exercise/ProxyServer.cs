using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace csharp_exercise
{
    public class ProxyServer
    {
        private int allowedNumberOfSites;
        private SortedSet<string> sortedSiteDetails = new SortedSet<string>();
        private Hashtable blockedSites = new Hashtable();
        private Hashtable allowedSites = new Hashtable();
        private string[] s = new string[] { "- youtube", "+ yahoo", "+ flipboard", "- flipkart", "- flipkaart" };

        public void Run()
        {
            //Console.WriteLine("Enter number of allowed sites");
            //allowedNumberOfSites = Convert.ToInt32(Console.ReadLine());
            allowedNumberOfSites = s.Length;

            if (ValidateAllowedNumberOfSites(allowedNumberOfSites))
            {
                //Console.WriteLine("Enter site details");
                for (int i = 0; i < allowedNumberOfSites; i++)
                {
                    //string siteName = Console.ReadLine();
                    string siteName = s[i];
                    string sitePrefix = siteName.Substring(2, 2);
                    //Console.WriteLine(sitePrefix);
                    if (siteName.StartsWith("+"))
                    {
                        allowedSites.Add(sitePrefix, siteName);
                    }
                    else
                    {
                        if (siteName.StartsWith("-") && (allowedSites[sitePrefix] == null && blockedSites[sitePrefix] == null))
                        {
                            blockedSites.Add(sitePrefix, siteName);
                        }
                        else if (siteName.StartsWith("-") && (allowedSites[sitePrefix] != null))
                        {
                            string allowedSiteName = allowedSites[sitePrefix].ToString().Replace("+ ", "");
                            string blockedSiteName = siteName.Replace("- ", "");


                            int allowedSiteLength = allowedSiteName.Length;
                            int blockedSiteLength = blockedSiteName.Length;

                            StringBuilder bPrefix = new StringBuilder();

                            if (allowedSiteLength > blockedSiteLength)
                            {
                                for(int b = 0; b < blockedSiteLength; b++)
                                {
                                    if(allowedSiteName[b] == blockedSiteName[b])
                                    {
                                        bPrefix.Append(blockedSiteName[b]);
                                    }
                                    else
                                    {
                                        bPrefix.Append(blockedSiteName[b]);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int a = 0; a < allowedSiteLength; a++)
                                {
                                    if (allowedSiteName[a] == blockedSiteName[a])
                                    {
                                        bPrefix.Append(blockedSiteName[a]);
                                    }
                                    else
                                    {
                                        bPrefix.Append(siteName[a]);
                                        break;
                                    }
                                }
                            }

                            //int sitePrefixLength = 3;
                            
                            //while ( && sitePrefixLength <= siteName.Length)
                            //{
                            //    sitePrefix = siteName.Substring(2, sitePrefixLength);
                            //    sitePrefixLength++;
                            //}

                            blockedSites.Add(bPrefix.ToString(), siteName);
                        }
                        else if (siteName.StartsWith("-") && (blockedSites[sitePrefix] != null || allowedSites[sitePrefix] != null))
                        {
                            int sitePrefixLength = 3;
                            while ((blockedSites[sitePrefix] != null || allowedSites[sitePrefix] != null) && sitePrefixLength <= siteName.Length)
                            {
                                sitePrefix = siteName.Substring(2, sitePrefixLength);
                                sitePrefixLength++;
                            }
                            Console.WriteLine(sitePrefix, allowedSites[sitePrefix]);
                            //sitePrefix = siteName.Substring(2, 5);
                            blockedSites.Add(sitePrefix, siteName);
                        }
                        else if (siteName.StartsWith("-") && blockedSites[sitePrefix] == null)
                        {
                            blockedSites.Add(sitePrefix, siteName);
                        }
                    }
                }

                Console.WriteLine(blockedSites.Count);

                foreach (string key in blockedSites.Keys)
                {
                    Console.WriteLine(key);
                }
            }
            else
            {
                Console.WriteLine("Maximum site limit reached");
            }

            Console.ReadLine();
        }
        private bool ValidateAllowedNumberOfSites(int allowedNumberOfSites)
        {
            return (allowedNumberOfSites >= 1 && allowedNumberOfSites <= Math.Pow(10, 5));
        }
    }
}
