using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTime.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
