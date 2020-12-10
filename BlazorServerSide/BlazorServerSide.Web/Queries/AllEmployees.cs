using BlazorServerSide.Shared.Entities;
using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorServerSide.Web.Queries
{
    /// <summary>
    /// in a real app, we'd add criteria properties, but we're just keeping it simple now.
    /// And I didn't actually create a test project for testing SQL like this, but I still used TestableQuery from Dapper.CX
    /// </summary>
    public class AllEmployees : TestableQuery<Employee>
    {
        public AllEmployees() : base(@"SELECT * FROM [dbo].[Employee] ORDER BY [LastName], [FirstName]")
        {
        }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new AllEmployees();
        }
    }
}
