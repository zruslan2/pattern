using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    class Program
    {
        static void Main(string[] args)
        {   
            // объявление Директора и Строителя
            Director director = new Director();
            DrugBuilder drugBuider = new DrugBuilder();
            // прикрепление строителя к директору
            director.db = drugBuider;

            // создание лекарства отпускаемое без рецепта
            director.createDrugWithOutRequiredRecipe("Валидол", PharmacologicalGroup.Tranquilizing);
            Drug validol = drugBuider.GetProduct();
            // создание лекарства отпускаемое только по рецепту
            director.createDrugWithRequiredRecipe("Азитрал", PharmacologicalGroup.Antibacterial);
            Drug azitral = drugBuider.GetProduct();

            // создание пациента и списка требуемых лекарств
            Patient patient = new Patient("Вася", 58);
            patient.AddRequiredDrug(azitral);
            patient.AddRequiredDrug(validol);

            // создание аптеки и добавление лекарства в аптеку
            Pharmacy pharmacy = new Pharmacy("Маша");            
            pharmacy.AddDrug(azitral);

            // создание доктора
            Doctor doctor = new Doctor();

            // указание цепочки 
            pharmacy.pharmacist.SetNext(doctor).SetNext(pharmacy.pharmacist);

            // пациент идет в аптеку
            patient.GoToThePharmacy(pharmacy);

            // вывод списка лекарств приобретенных по рецепту
            patient.ViewListReceivedDrugsWithRecipe();
            Console.WriteLine("");
            // вывод всех лекарств приобретенных
            patient.ViewListReceivedDrugs();
            Console.WriteLine("");

            // добавление наблюдатедя в аптеку
            pharmacy.Attach(patient);

            // количество лекарств в списке запросов пациента
            Console.WriteLine(patient.RequiredDrugs.Count);
            // добавление лекарства в аптеку
            pharmacy.AddDrug(validol);
            // количество лекарств в списке запросов пациента
            Console.WriteLine(patient.RequiredDrugs.Count);
        }
    }
}
