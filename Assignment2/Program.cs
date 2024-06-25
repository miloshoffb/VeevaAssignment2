namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Patient> patientList = new List<Patient>() {
                new Patient() { PatientID = 1, PatientName = "John", Age = 18, SiteID = 1 } ,
                new Patient() { PatientID = 2, PatientName = "Steve",  Age = 21, SiteID = 1 } ,
                new Patient() { PatientID = 3, PatientName = "Bill",  Age = 18, SiteID = 2 } ,
                new Patient() { PatientID = 4, PatientName = "Ram" , Age = 20, SiteID = 2 } ,
                new Patient() { PatientID = 5, PatientName = "Ron" , Age = 21 }
            };

            IList<Site> siteList = new List<Site>() {
                new Site(){ SiteID = 1, SiteName="Site Number 1"},
                new Site(){ SiteID = 2, SiteName="Site Number 2"},
                new Site(){ SiteID = 3, SiteName="Site Number 3"}
            };

            // Filter patients by age and valid site.
            IList<Patient> filteredPatients = patientList
                .Where(p => p.Age > 18)
                .Where(p => p.SiteID > 0)
                .ToList();           

            // Group patients by site.
            IEnumerable<string> patientsGroupedBySite = patientList
                .OrderBy(p => p.SiteID)
                .GroupBy(p => p.SiteID,
                (siteId, patientsOnSite) => $"SiteID {siteId}:\n{string.Join('\n', patientsOnSite.Select(a => a.PatientName))}");

            string output1 = string.Join('\n', filteredPatients.Select(p => p.PatientName));
            string output2 = string.Join('\n', patientsGroupedBySite);

            Console.WriteLine($"Q1)\n{output1}");
            Console.WriteLine($"\nQ2)\n{output2}");
        }

        private class Patient
        {
            public int PatientID { get; set; }

            public string PatientName { get; set; }

            public byte Age { get; set; }

            public int SiteID { get; set; }
        }

        private class Site
        {
            public int SiteID { get; set; }

            public string SiteName { get; set; }
        }
    }
}
