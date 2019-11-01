using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    public class Pharmacy:ISubject
    {
        public List<Drug> Drugs { get; set; }
        public Pharmacist pharmacist { get; set; }

        private List<IObserver> _observers = new List<IObserver>();

        public Pharmacy(string pharmacistName)
        {
            this.pharmacist = new Pharmacist(pharmacistName);
            this.pharmacist.WorkPharmacy = this;
            this.Drugs = new List<Drug>();
        }

        public void AddDrug(Drug drug)
        {
            this.Drugs.Add(drug);
            this.Notify();
        }

        public void ViewListReceivedDrugs()
        {
            Console.WriteLine("Лекарства в наличии: ");
            foreach (Drug drug in this.Drugs)
            {
                drug.ViewInfo();
            }
        }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(Drugs.Last(),this);
            }
        }
    }
}
