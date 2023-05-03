using ApplicationDevelopment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.Common.Interfaces
{
    public interface IApplicationDbContext: IDisposable
    {
     
        DbSet<Customer> Customer { get; set; }
        DbSet<Car> Car { get; set; }
        DbSet<CarRequest> CarRequest { get; set; }
        DbSet <DamageRequest> DamageRequest { get; set; }
        DbSet<RepairBill> RepairBill{ get; set; }
        DbSet<Staff> Staff{ get; set; }
        DbSet<Offer> Offer { get; set; }
        DbSet<UserRole> UserRole { get; set; }
        DbSet<Address> Address { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}