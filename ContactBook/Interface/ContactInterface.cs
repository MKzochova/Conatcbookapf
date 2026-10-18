using ContactBook.Entities;

namespace ContactBook.Interface
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        Contact Add(Contact contact);
        Contact Update(Contact contact);
        bool Delete(int id);
    }
}