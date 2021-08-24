using katon_example.Core.Models;
using katon_example.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace katon_example.Web.Helper
{
    public static class UserModelMapping
    {
        public static UserModelDTO ToDTO(this UserModel userModel)
        {
            return new UserModelDTO
            {
                Id = userModel.Id,
                Name = userModel.Name,
                LastName = userModel.LastName
            };
        }

        public static UserModel ToEntity(this UserModelDTO userModel)
        {
            return new UserModel
            {
                Id = userModel.Id,
                Name = userModel.Name,
                LastName = userModel.LastName
            };
        }

        public static List<UserModel> ToEntity(this List<UserModelDTO> userModel)
        {
            return userModel.Select(x => x.ToEntity()).ToList();
        }
    }
}