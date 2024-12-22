using Models.Enums;
using Models.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Factory
{
    public class UserFactoryRegistry
    {
        private static readonly Dictionary<UserRole, IUserFactory> factories = new();

        static UserFactoryRegistry()
        {
            factories[UserRole.Doctor] = new DoctorFactory();
            factories[UserRole.Administrator] = new AdministratorFactory();
        }

        public static User CreateUser(UserRole role, Dictionary<string, object> parameters)
        {
            if (!factories.TryGetValue(role, out var factory))
                throw new InvalidOperationException($"Error: No factory registered for role {role}");

            return factory.CreateUser(parameters);
        }
    }
}
