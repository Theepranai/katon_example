using katon_example.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace katon_example.Core.Services
{
    public class UserServices
    {
        private List<UserModelDTO> rto = new List<UserModelDTO>();

        public UserServices()
        {
            rto.Add(
                new UserModelDTO()
                {
                    Id = 1,
                    Name = "fristKaton",
                    LastName = "LastNameKaton",
                });

            for (var i = 2; i <= 10; i++)
            {
                rto.Add(
                new UserModelDTO()
                {
                    Id = i,
                    Name = "fristKaton" + i,
                    LastName = "LastNameKaton" + i,
                });
            }
        }

        public List<UserModelDTO> GetAll()
        {
            return rto;
        }

        public UserModelDTO GetById(int Id)
        {
            return rto.FirstOrDefault(x => x.Id == Id);
        }

        public List<UserModelDTO> Edit(UserModelDTO model)
        {
            var i = rto.FindIndex(c => c.Id == model.Id);

            if (i < 0) return new List<UserModelDTO>();

            rto[i] = new UserModelDTO()
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName
            };

            return rto;
        }

        public List<UserModelDTO> Add(UserModelDTO model)
        {
            var id = rto.Max(x => x.Id);
            model.Id = id + 1;
            rto.Add(model);
            return rto;
        }

        public List<UserModelDTO> Delete(int id)
        {
            rto.Remove(rto.FirstOrDefault(x => x.Id == id));
            return rto;
        }
    }
}