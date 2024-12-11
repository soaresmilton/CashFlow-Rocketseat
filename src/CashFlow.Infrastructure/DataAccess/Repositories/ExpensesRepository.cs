using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using System.Runtime.CompilerServices;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

//Aqui devemos garantir que essa classe não será utilizada dentro do projeto da API
internal class ExpensesRepository : IExpensesRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Expense expense)
    {
        _dbContext.Expenses.Add(expense);
        _dbContext.SaveChanges();
    }
}
