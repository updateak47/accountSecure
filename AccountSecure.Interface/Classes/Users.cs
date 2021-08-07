using AccountSecure.DataAccess;
using AccountSecure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace AccountSecure.Interface
{
    public class Users : AppUser
    {
        public string Fullname { get; set; }
        public Users()
        {

        }
        public bool Add()
        {
            bool response = false;
            using (var context = new AccountSecureContext())
            {
                AppUser user = new AppUser
                {
                    Username = this.Username,
                    Department = this.Department,
                    Firstname = Firstname,
                    Lastname = Lastname,
                    Password = this.Password,
                    Surname = this.Surname,
                    Sex = this.Sex
                };
                //int id = context.ApplicationUsers.Add(user).UserId;
                context.ApplicationUsers.AddOrUpdate(p => p.Username, user);
                context.SaveChanges();
                response = true;
            }
            return response;
        }
        public bool Update()
        {
            AppUser user;
            bool updated = false;
            using (var context = new AccountSecureContext())
            {
                user = context.ApplicationUsers.Where(s => s.Username == this.Username).AsEnumerable().FirstOrDefault<AppUser>();
            }
            if (user != null)
            {
                user = new AppUser
                {
                    UserId = this.UserId,
                    Username = this.Username,
                    Department = this.Department,
                    Firstname = Firstname,
                    Lastname = Lastname,
                    Password = this.Password,
                    Surname = this.Surname,
                    Sex = this.Sex
                };
                using (var context = new AccountSecureContext())
                {
                    context.ApplicationUsers.Attach(user);
                    context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    updated = true;
                }
            }
            return updated;
        }
        public bool Delete()
        {
            bool deleted = false;
            using (var context = new AccountSecureContext())
            {
                context.ApplicationUsers.Remove(this);
                deleted = true;
            }
            return deleted;
        }

        public Users Login()
        {
            using (var context = new AccountSecureContext())
            {
                Users user;
                user = (from appUser in context.ApplicationUsers
                        where appUser.Username.ToLower().Trim() == this.Username.ToLower().Trim() && appUser.Password.Trim() == this.Password.Trim()
                        select new
                        {
                            userId = appUser.UserId,
                            fullname = appUser.Surname, //string.Format("{0} {1} {2}", appUser.Surname, appUser.Lastname, appUser.Firstname),
                            username = appUser.Username,
                            department = appUser.Department
                        }).Take(1).AsEnumerable().Select(x => new Users
                        {
                            UserId = x.userId,
                            Username = x.username,
                            Fullname = x.fullname,
                            Department = x.department
                        }).FirstOrDefault();
                return user;
            }
        }
        public IEnumerable<AppUser> SelectUser()
        {
            using (var context = new AccountSecureContext())
            {
                IEnumerable<AppUser> user;
                //context.ApplicationUsers.OfType<Users>()
                user = (from appUser in context.ApplicationUsers
                        where appUser.Username.ToLower() == this.Username.ToLower()
                        select appUser).AsEnumerable();

                return user.ToList();
            }
        }
        public IEnumerable<AppUser> SelectAll()
        {
            using (var context = new AccountSecureContext())
            {
                return context.ApplicationUsers.AsEnumerable().ToList();
            }
        }
    }
}

