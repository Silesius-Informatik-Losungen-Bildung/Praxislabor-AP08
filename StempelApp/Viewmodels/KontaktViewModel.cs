using StempelAppCore.Models;
using System.Collections.Generic;

namespace StempelApp.Viewmodels
{
    public class KontaktViewModel
    {
        public List<User> Mitarbeiter { get; set; } = new();
        public List<Customer> Immobilienbesitzer { get; set; } = new();
    }
}
