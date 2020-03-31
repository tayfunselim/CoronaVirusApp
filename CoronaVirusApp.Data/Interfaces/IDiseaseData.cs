using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IDiseaseData
    {
        Disease Create(Disease disease);
        Disease GetDiseaseById(int id);
        Disease Update(Disease disease);
        Disease Delete(int id);
        int Commit();
        IEnumerable<Disease> GetDiseases();
    }
}
