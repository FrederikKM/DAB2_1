using System;
using DAB2_2RDB;
using DAB2_2RDB.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace DAB2_2_RDB.Integration.Test
{


    public class RepositoryTests
    {
        private readonly Repository<Person> _uut;

        public RepositoryTests()
        {
            DbContext context = new Dab2_2RdbContext();
            _uut = new Repository<Person>(context);
        }

        [Fact]
        public void Repository_CanCreate_NoThrow()
        {
            Person be = new Person() { Id = 1 };

            _uut.Create(be);

            Assert.Equal(be, _uut.Read(be.Id));
        }

        [Fact]
        public void Repository_CanRead_NoThrow()
        {
            Person be = new Person() { Id = 1 };

            _uut.Create(be);

            Assert.Equal(be, _uut.Read(be.Id));
        }

        [Fact]
        public void Repository_CanUpdate_ExistingItem()
        {
            Person be = new Person() { Id = 1 };

            _uut.Create(be);

            be.FirstName = "name";

            _uut.Update(be.Id, be);

            Assert.Equal("name", _uut.Read(be.Id).FirstName);
        }

        [Fact]
        public void Repository_CanUpdate_NewItem()
        {
            Person be = new Person() { Id = 1 };
            Person be2 = new Person() { FirstName = "name2" };

            _uut.Create(be);

            be.FirstName = "name";

            _uut.Update(be.Id, be2);

            Assert.Equal("name2", _uut.Read(be2.Id).FirstName);
        }


    }
}
