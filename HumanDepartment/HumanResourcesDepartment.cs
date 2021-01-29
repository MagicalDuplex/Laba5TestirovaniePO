using System;
using System.Collections.Generic;

namespace HumanResourcesDepartment
{
    public class HumanResourcesDepartment
    {
        private List<Worker> _workers;
        public string errorText;

        public IReadOnlyCollection<Worker> Workers => _workers;

        public HumanResourcesDepartment()
        {
            _workers = new List<Worker>();
        }

        public int Count => _workers.Count;

        public void AddNewWorker(Worker worker)
        {
            if (!(worker.name == null || worker.secondname == null || worker.age == null || worker.monthsWorkedOut == null || worker.position == null))
            {
                if ( !_workers.Exists(c =>c.passport == worker.passport))
                {
                    if (int.TryParse(worker.age, out int n) && !(worker.age == null) && int.TryParse(worker.monthsWorkedOut, out int k) && !(worker.monthsWorkedOut == null) && int.TryParse(worker.position, out int l) && !(worker.position == null))
                    {
                        if (Convert.ToInt32(worker.age) > 0 && Convert.ToInt32(worker.monthsWorkedOut) >= 0 && Convert.ToInt32(worker.position) >= 0)
                        {
                            if (worker.passport.Length == 10)
                            {
                                _workers.Add(worker);
                                errorText = "";
                            }
                            else
                            {
                                errorText = "Wrong_Passport";
                            }
                        }
                        else
                        {
                            errorText = "Digits_MustBePositive";
                        }
                    }
                    else
                    {
                        errorText = "Fields_Filled_Wrong";
                    }
                }
                else
                {
                    errorText = "Worker_already_exist";
                }
            }
            else
            {
                errorText = "All_Fields_MustBe_Filled";
            }

        }

        

        public void UpdateWorkedOutHours(Worker worker)
        {
            if (worker.passport != null)
            { if (worker.passport.Length == 10)
                {
                    if (_workers.Exists(a => a.passport == worker.passport))
                    {
                        if (worker.monthsWorkedOut != null && int.TryParse(worker.monthsWorkedOut, out int n))
                        {
                            if (Convert.ToInt32(worker.monthsWorkedOut) >= 0)
                            {
                                _workers.Find(a => a.passport == worker.passport).monthsWorkedOut = worker.monthsWorkedOut;
                            }
                            else
                            {
                                errorText = "MonthsCount_Is_SubZero";
                            }
                        }
                        else
                        {
                            errorText = "MonthsCount_Is_Not_Number";
                        }
                    }
                    else
                    {
                        errorText = "Worker_Not_Found";
                    }
                }
                else
                {
                    errorText = "Wrong_passport";
                }
            }
            else
            {
                errorText = "Passport_IsNull";
            }
        }

        

        public bool Exists(Worker worker)
        {
            return _workers.Contains(worker);
        }

        public void RemoveIfExists(Worker worker)
        {
            _workers.Remove(worker);
        }

        public void RemoveWithpassport(string passport)
        {
            if (!(passport == null))
            { if (passport.Length == 10)
                {
                    var count = _workers.FindAll(a => a.passport == passport).Count;
                    if (count > 0)
                    {
                        foreach (var pr in _workers.FindAll(a => a.passport == passport))
                        {
                            _workers.Remove(pr);
                            errorText = "";
                        }
                    }
                    else
                    {
                        errorText = "Worker_not_found";
                    }
                }
                else
                {
                    errorText = "Wrong_passport";
                }
            }
            else
            {
                errorText = "Passport_IsNull";
            }
        }
    }
}


