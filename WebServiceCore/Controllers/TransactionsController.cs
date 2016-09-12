using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServiceCore.Models;

namespace WebServiceCore.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return _context.Transactions;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Transaction Get(int id)
        {
            return _context.Transactions.FirstOrDefault(e => e.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}
