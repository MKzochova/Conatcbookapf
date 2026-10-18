using ContactBook.Entities;
using ContactBook.Interface;

namespace ContactBook.Service
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public Contact Add(Contact contact)
        {
            var book = new Contact();
            book.FirstName = contact.FirstName;
            book.LastName = contact.LastName;
            book.Email = contact.Email;
            book.Phone = contact.Phone;
            book.FullName = contact.FirstName + " " + contact.LastName;

            _context.Contacts.Add(book);
            _context.SaveChanges();

            return book;
        }

        public bool Delete(int id)
        {
            var entity = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            _context.Contacts.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Contact> GetAll()
        {
            var contacts = _context.Contacts.ToList();
            return contacts;
        }

        public Contact GetById(int id)
        {
            var book = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return new Contact();
            }
            return book;
        }

        public Contact Update(Contact contact)
        {
            var entity = _context.Contacts.FirstOrDefault(x => x.Id == contact.Id);

            if (entity == null)
            {
                return new Contact();
            }

            entity.FirstName = contact.FirstName;
            entity.LastName = contact.LastName;
            entity.Email = contact.Email;
            entity.Phone = contact.Phone;
            entity.FullName = contact.FirstName + " " + contact.LastName;

            _context.Contacts.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}