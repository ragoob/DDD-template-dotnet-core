using On.Core.Entites;
using On.Domain.Events.Customers;
using System;
using System.Collections.Generic;
namespace On.Domain.Entites
{
    public class Customer: BaseEntity
    {
        private List<CustomerPhoto> _photos = new List<CustomerPhoto>();
        private Customer()
        {
            
        }

        public Customer(string Name)
        {
            this.Name = Name;
            CustomerStatus = CustomerStatus.Pending; 
        }

        public Customer(Guid Id, string Name)
        {
            this.Name = Name;
            this.Id = Id;
            CustomerStatus = CustomerStatus.Pending;
        }
        public string Name { get;  set; }

        public CustomerStatus CustomerStatus { get; private set; }
        public  CustomerAddress Address { get;  private set; }
        public IReadOnlyCollection<CustomerPhoto> customerPhotos => _photos.AsReadOnly();

        public void AddCustomerPhoto(CustomerPhoto photo)
        {
            // The customer profile should not have more than 5 photos 
            if (_photos.Count  == 5)
            {
                throw new InvalidOperationException("You can not add more than 5 Photoes for the users");
            }
            _photos.Add(photo);
        }

        public void RemoveCustomerPhoto(CustomerPhoto photo)
        {
            _photos.Remove(photo);
        }

        public void ModifyAddress(CustomerAddress address)
        {
            Address = address;
        }

         public void updateCustomer(string name)
        {
            Name = name;
        }

        public void Activate()
        {
            CustomerStatus = CustomerStatus.Active;
            AddDomainEvent(new CustomerActivated()
            {
                Id = this.Id
            });
        }
    }

    public enum CustomerStatus
    {
        Pending = 0,
        Active = 1,
        Suspended = 2
    }
}
