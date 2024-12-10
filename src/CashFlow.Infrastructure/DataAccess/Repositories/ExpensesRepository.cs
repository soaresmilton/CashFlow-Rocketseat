﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

//Aqui devemos garantir que essa classe não será utilizada dentro do projeto da API
internal class ExpensesRepository : IExpensesRepository
{
    public void Add(Expense expense)
    {
        var dbContext = new CashFlowDbContext();
        dbContext.Expenses.Add(expense);
        dbContext.SaveChanges();
    }
}
