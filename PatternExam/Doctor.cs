using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    public class Doctor:IHandler
    {
        public string Name { get; set; }

        //следующий обслуживающий по цепочке
        private IHandler nextHandler;
        
        //обслуживание пациента
        public List<Drug> PatientCare(Patient patientRequest)
        {
            List<Drug> ld = new List<Drug>();
            ld.AddRange(this.WritingRecipe(patientRequest));
            nextHandler.PatientCare(patientRequest);
            return ld;
        }

        public IHandler SetNext(IHandler handler)
        {
            this.nextHandler = handler;
            return handler;
        }
        //выписывание лекарства пациенту
        private List<Drug> WritingRecipe(Patient patient)
        {
            List<Drug> ld = new List<Drug>();
            foreach (Drug drug in patient.RequiredDrugs)
            {
                if (drug.RequiredRecipe)
                {
                    patient.Recipes.Add(drug.Name);
                    ld.Add(drug);
                }
            }
            return ld;
        }
    }
}
