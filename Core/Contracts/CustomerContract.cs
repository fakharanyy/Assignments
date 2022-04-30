using System;
using ITS_Technical_Test.Core.Data.Entity.Interfaces;
using ITS_Technical_Test.Core.Misc;
using ITS_Technical_Test.Presentation.Models;

namespace ITS_Technical_Test.Core.Contracts
{
    public class CustomerContract : ICustomer
    {
        private readonly CustomerModel ViewModel;
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public CustomerClass Class { get; private set; }

        public string Comment { get; private set; }
        public string PhoneNumber { get; private set; }


        public CustomerContract(CustomerModel model)
        {
            ViewModel = model;
            Id = ViewModel.Id;
            Name = ViewModel.Name;
            Email = ViewModel.Email;
            Class = (CustomerClass)Enum.Parse(typeof(CustomerClass), ViewModel.Class);
            PhoneNumber = ViewModel.PhoneNumber;
            Comment = ViewModel.Comment;



        }
    }
}
