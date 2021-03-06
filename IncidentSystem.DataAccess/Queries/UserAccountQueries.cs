﻿using IncidentSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IncidentSystem.DataAccess.Queries
{
    public static class UserAccountQueries
    {
        public static Expression<Func<UserAccount, bool>> UserAccountById(int id)
        {
            return (a => a.UserAccountId == id);
        }

        public static Expression<Func<UserAccount, bool>> UserAccountByUserName(string userName)
        {
            return (a => a.UserName == userName);
        }
    }
}
