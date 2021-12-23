using System;
namespace On.Domain.Entites
{
    public class CustomerPhoto
    {
        private CustomerPhoto()
        {

        }

        public CustomerPhoto(string pathUrl,string alt)
        {
            this.PathUrl = pathUrl;
            this.Alt = alt;
        }

     
        public Guid Id { get; private set; }
        public string PathUrl { get; private set; }

        public string Alt { get; private set; }

    
    }
}
