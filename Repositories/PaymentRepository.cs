using CourseManager.Data;
using CourseManager.Models;
using CourseManager.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CourseManager.Repositories
{
    public class PaymentRepository : IPaymentsRepository
    {
        private readonly ApplicationDbContext context;

        public PaymentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Payment payment)
        {
            context.Payments.Add(payment);
            Save();
        }

        public bool Delete(int id)
        {
            Payment payment = context.Payments.Find(id);
            if(payment != null)
            {
                context.Remove(payment);
            }
            return false;
        }

        public Payment GetPaymentById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public List<Payment> GetPayments()
        {
            return context.Payments.ToList();
        }

        public List<Payment> GetPaymentsByUserId(string userId)
        {
            return context.Payments.Where(p => p.UserId == userId).ToList();
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool CheckPaymentForUser(string userId)
        {
            return context.Payments.Where(p => p.UserId == userId && p.EndSubscription > System.DateTime.Now && p.PaymentDate < System.DateTime.Now).Any();
        }
    }
}
