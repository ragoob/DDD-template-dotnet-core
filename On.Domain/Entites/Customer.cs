using On.Core;
using On.Core.Entites;
using On.Domain.Events.Customers;
using System;
using System.Collections.Generic;
namespace On.Domain.Entites
{
    public record CustomerAddress(string Street, string City, string State, string Country, string Zipcode);

    public class Customer: BaseEntity<Guid>, IDomainEventEntity
    {
        private readonly List<CustomerPhoto> _photos = new List<CustomerPhoto>();
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
        public IReadOnlyCollection<CustomerPhoto> CustomerPhotos => _photos;

        public void AddCustomerPhoto(string pathUrl, string alt)
        {
            // The customer profile should not have more than 5 photos 
            if (_photos.Count  == 5)
            {
                throw new InvalidOperationException("You can not add more than 5 Photoes for the users");
            }
            _photos.Add(new CustomerPhoto(pathUrl,alt));
        }

        public void RemoveCustomerPhoto(Guid id)
        {
            _photos.Remove(_photos.Find(c=> c.Id.Equals(id)));
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
                Id = Id
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
