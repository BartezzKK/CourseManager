using CourseManager.Models;
using System.Collections.Generic;

namespace CourseManager.Repositories.Interfaces
{
    public interface IPaymentsRepository
    {

        bool Save();
        bool Delete(int id);
        void Create(Payment payment);
        List<Payment> GetPayments();
        List<Payment> GetPaymentsByUserId(string userId);
        Payment GetPaymentById(int? id);
        bool CheckPaymentForUser(string userId);
    }
}
