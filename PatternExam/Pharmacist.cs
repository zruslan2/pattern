using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    public class Pharmacist:IHandler
    {
        public string Name { get; set; }
        //ссылка на аптеку где работает фармацевт
        public Pharmacy WorkPharmacy { get; set; }

        //следующий обслуживающий по цепочке
        private IHandler nextHandler;

        public Pharmacist(string name)
        {
            this.Name = name;
        }
        //поиск лекарств в аптеке
        public Drug FindDrug(Drug drug)
        {
            return WorkPharmacy.Drugs.Find(x=>x.Name==drug.Name);            
        }
        //проверка нужен ли рецепт для выдачи лекарства
        public bool CheckDrugRequiredRecipe(Drug drug)
        {
            return drug.RequiredRecipe;
        }
        //проверка наличия рецепта у пациента на лекарство
        public bool CheckRecipe(Patient patient, Drug drug)
        {
            bool res = false;
            foreach (var item in patient.Recipes)
            {
                if (item == drug.Name) res = true;
            }
            return res;
        }
        //выдача лекарства пациегу
        public Drug GiveOutDrug(Patient patient, Drug drug)
        {
            WorkPharmacy.Drugs.Remove(drug);
            //patient.RequiredDrugs.Remove(drug);
            patient.ReceivedDrugs.Add(drug);
            return drug;
        }

        public IHandler SetNext(IHandler handler)
        {
            this.nextHandler = handler;
            return handler;
        }
        //обслуживание пациента
        public List<Drug> PatientCare(Patient patientRequest)
        {
            List<Drug> ld = new List<Drug>();
            foreach (Drug drug in patientRequest.RequiredDrugs)
            {
                Drug res = this.FindDrug(drug);
                if (res != null)
                {
                    if (CheckDrugRequiredRecipe(res))
                    {
                        if (CheckRecipe(patientRequest, res))
                        {
                            ld.Add(GiveOutDrug(patientRequest, res));                            
                        }
                        else
                        {
                            ld.AddRange(nextHandler.PatientCare(patientRequest));
                        }
                    }
                    else
                    {
                        ld.Add(GiveOutDrug(patientRequest, res));                        
                    }
                }
            }
            return ld;         
        }
    }
}
