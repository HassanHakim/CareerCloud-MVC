using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    { 
        public  ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }
        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107,
                        $"Major for ApplicantEducation {poco.Id} cannot be null"));
                }
                else if (poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107,
                        $"Major for ApplicantEducation {poco.Id} must be at least 3 characters."));
                }

                if (poco.StartDate.HasValue)
                {
                    if (poco.StartDate > DateTime.Now)
                    {
                        exceptions.Add(new ValidationException(108,
                            $"StartDate for ApplicantEducation {poco.Id} Cannot be greater than today."));
                    }
                }

                if (poco.CompletionDate.HasValue && poco.StartDate.HasValue)
                {
                    if (poco.CompletionDate < poco.StartDate)
                    {
                        exceptions.Add(new ValidationException(109,
                            $"CompletionDate for ApplicantEducation {poco.Id} cannot be earlier than StartDate."));
                    }
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}



