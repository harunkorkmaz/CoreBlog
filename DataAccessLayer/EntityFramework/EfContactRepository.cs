﻿using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfContactRepository(BlogContext context)
{
    public void Insert(Contact contact)
    {
        context.Contacts.Add(contact);
        context.SaveChanges();
    }
}
