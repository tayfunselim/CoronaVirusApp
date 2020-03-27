using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaVirusApp.Data.SqlData
{
    public class DiseaseDataSql : IDiseaseData
    {
        private readonly CoronaVirusDbContext coronaVirusDbContext;

        public DiseaseDataSql(CoronaVirusDbContext coronaVirusDbContext)
        {
            this.coronaVirusDbContext = coronaVirusDbContext;
        }
        public int Commit()
        {
            return coronaVirusDbContext.SaveChanges();
        }

        public Disease Create(Disease disease)
        {
            coronaVirusDbContext.Diseases.Add(disease);
            return disease;
        }

        public Disease Delete(int id)
        {
            var tempDisease = coronaVirusDbContext.Diseases.SingleOrDefault (d => d.Id == id);
            if (tempDisease != null)
            {
                coronaVirusDbContext.Diseases.Remove(tempDisease);
            }
            return tempDisease;
        }

        public Disease GetDiseaseById(int id)
        {
            return coronaVirusDbContext.Diseases.SingleOrDefault(d=>d.Id == id);
        }

        public IEnumerable<Disease> GetDiseases()
        {
            return coronaVirusDbContext.Diseases.ToList();
        }

        public Disease Update(Disease disease)
        {
            coronaVirusDbContext.Entry(disease).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return disease;
        }
    }
}
